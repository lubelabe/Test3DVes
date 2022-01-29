using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using SimpleJSON;
using TMPro;

public class RequestDetailOfPokemon : MonoBehaviour
{
    [SerializeField] private string namePokemon;

    [SerializeField] private GameObject prefabTextTitle;
    [SerializeField] private GameObject prefabTextItem;
    
    [SerializeField] private Transform parentToTextDetail;

    [SerializeField] private TextMeshProUGUI textName;

    private string urlPokeApi = "https://pokeapi.co/api/v2/pokemon/";
    
    private void Start()
    {
        StartCoroutine(GetDetailsToPokemon());
    }

    IEnumerator GetDetailsToPokemon()
    {
        using (UnityWebRequest requestDetailPokemon = UnityWebRequest.Get(urlPokeApi + namePokemon))
        {
            yield return requestDetailPokemon.SendWebRequest();

            if (requestDetailPokemon.isNetworkError || requestDetailPokemon.isHttpError)
            {
                Debug.Log(requestDetailPokemon.error);
                yield break;
            }
            else
            {
                JSONNode detailsPoke = JSON.Parse(requestDetailPokemon.downloadHandler.text);
                SetDataInTextUI(detailsPoke);
            }
        }
    }

    private void SetDataInTextUI(JSONNode nodesTemp)
    {
        string namePokemon = nodesTemp["name"];
        textName.text = "Nombre: " + namePokemon.ToUpper();
        
        foreach (var child in nodesTemp)
        {
            string[] stringCombined = CheckIfIsInformationToUse(child.Key).Split(',');
            if (stringCombined[0] != "")
            {
                if (child.Value.Count > 1)
                {
                    InstantiateTextInUI(stringCombined[0], child.Value);
                    JSONNode newNode = nodesTemp[child.Key];
                    for (int i = 0; i < newNode.Count; i++)
                    {
                        InstantiateTextInUI(newNode[i][stringCombined[1]]["name"], newNode[i]["base_stat"], false);
                    }

                }
                else
                {
                    InstantiateTextInUI(CheckIfIsInformationToUse(child.Key), child.Value);
                }
            }
        }
    }

    private string CheckIfIsInformationToUse(string nameKeyOfJson)
    {
        string translateName = "";
        switch (nameKeyOfJson)
        {
            case "abilities":
                translateName = "Habilidades,ability";
                break;
            case "base_experience":
                translateName = "Experiencia";
                break;
            case "height":
                translateName = "Altura";
                break;
            case "stats":
                translateName = "Estadisticas,stat";
                break;
            case "weight":
                translateName = "Ancho";
                break;
            case "types":
                translateName = "Tipos,type";
                break;
        }

        return translateName;
    }

    private void InstantiateTextInUI(string textToSet, string value, bool isTitle = true)
    {
        GameObject prefabTextToInstance;
        if (isTitle)
            prefabTextToInstance = prefabTextTitle;
        else
            prefabTextToInstance = prefabTextItem;

        GameObject textFinal =  Instantiate(prefabTextToInstance, Vector3.zero, Quaternion.identity, parentToTextDetail);
        textFinal.GetComponent<TextMeshProUGUI>().text = textToSet + " " + value;
    }
}
