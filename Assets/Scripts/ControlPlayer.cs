using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ControlPlayer : MonoBehaviour
{
    private List<Color> colorsPlayer = new List<Color>(){Color.blue, Color.black, Color.cyan, Color.gray, Color.green, Color.red, Color.yellow, Color.magenta, Color.white};
    private List<Material> materialsPlayer = new List<Material>();

    private void Start()
    {
        foreach (Transform child in transform)
        {
            materialsPlayer.Add(child.GetComponent<Renderer>().material);
        }        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.CompareTag("Bullet"))
        {
            Color colorTemp = colorsPlayer[Random.Range(0, colorsPlayer.Count)];
            foreach (Material materialTemp in materialsPlayer)
            {
                materialTemp.color = colorTemp;
            }
        }
    }
}
