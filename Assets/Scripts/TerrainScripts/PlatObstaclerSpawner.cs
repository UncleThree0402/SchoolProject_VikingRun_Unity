using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class PlatObstaclerSpawner : MonoBehaviour
{
    private Vector3 _spwanpoint;
    [SerializeField] private GameObject[] obstacles;

    private Random _Random = new Random();

    // Start is called before the first frame update
    void Start()
    {
        _spwanpoint = transform.GetChild(1).transform.position;

        switch (_Random.Next(0, 3))
        {
            case 1:
            {
                var temp = Instantiate(obstacles[0], _spwanpoint, transform.parent.localRotation);
                temp.transform.parent = transform;
                break;
            }
            
            default:
                break;
        }
    }
}