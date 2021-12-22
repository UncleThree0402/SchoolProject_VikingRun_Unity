using Controller;
using UnityEngine;

namespace TerrianSpawner
{
    public class ObstacleCollider : MonoBehaviour
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