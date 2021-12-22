using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadController : MonoBehaviour
{
    void Start()
    {
    }


    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameObject.FindObjectOfType<GroundSpawner>().SpawnTile();
            Destroy(GameObject.FindObjectOfType<GroundSpawner>().PpTile);
        }
    }
}