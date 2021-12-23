using UnityEngine;

public class RoadController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<GroundSpawner>().SpawnTile();
            Destroy(FindObjectOfType<GroundSpawner>().AntepenultimateTile);
        }
    }
}