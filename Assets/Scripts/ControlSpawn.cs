using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlSpawn : MonoBehaviour
{
    [SerializeField] private GameObject prefabSphere;
    [SerializeField] private Transform pokemonTransform;

    private Rigidbody rbSphere;

    public void ButtonSpawnSphere()
    {
        GameObject sphereTemp = Instantiate(prefabSphere);
        rbSphere = sphereTemp.GetComponent<Rigidbody>();
    }
}
