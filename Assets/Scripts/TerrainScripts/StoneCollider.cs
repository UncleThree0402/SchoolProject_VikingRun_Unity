using System;
using Controller;
using UnityEngine;

namespace TerrianSpawner
{
    public class StoneCollider : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                other.GetComponent<PlayerStatController>().Psvm.ChangeAliveBool(false);
            }
        }
    }
}