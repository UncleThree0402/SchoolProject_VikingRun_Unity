using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class PlatObstaclerSpawner : MonoBehaviour
{
    private Vector3 spwanpoint;
    [SerializeField] private GameObject[] obstacles;

    private Random _Random = new Random();

    // Start is called before the first frame update
    void Start()
    {
        spwanpoint = transform.GetChild(1).transform.position;
        if (_Random.Next(0, 3) % 2 == 1)
        {
            var temp = Instantiate(obstacles[0], spwanpoint, transform.parent.localRotation);
            temp.transform.parent = transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}