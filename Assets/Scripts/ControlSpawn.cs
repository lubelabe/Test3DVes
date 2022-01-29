using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlSpawn : MonoBehaviour
{
    [SerializeField] private GameObject prefabSphere;
    [SerializeField] private Transform pokemonTarget;
    [SerializeField] private Transform parentSpheres;
    [SerializeField] private Transform spherePositionStart;

    [SerializeField] private float forceToThrownSphere;

    private Rigidbody rbSphere;

    public void ButtonSpawnSphere()
    {
        GameObject sphereTemp = Instantiate(prefabSphere, spherePositionStart.position, Quaternion.identity, parentSpheres);
        rbSphere = sphereTemp.GetComponent<Rigidbody>();
        sphereTemp.transform.LookAt(pokemonTarget);
        ThrowSphereBullet(sphereTemp);
    }

    private void ThrowSphereBullet(GameObject sphereBulletTemp)
    {
        rbSphere.AddForce(sphereBulletTemp.transform.forward * forceToThrownSphere, ForceMode.Impulse);
    }
}
