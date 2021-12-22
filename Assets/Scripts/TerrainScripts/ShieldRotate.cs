using System;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace TerrianSpawner
{
    public class ShieldRotate : MonoBehaviour
    {
        private void Update()
        {
            transform.Rotate(Vector3.back * 90 * Time.deltaTime);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                Destroy(gameObject);
            }
        }
    }
}