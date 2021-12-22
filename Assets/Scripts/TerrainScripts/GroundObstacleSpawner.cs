using System;
using UnityEngine;
using Random = System.Random;

namespace TerrianSpawner
{
    public class GroundObstacleSpawner : MonoBehaviour
    {
        private Vector3 []spawnPoints;
        [SerializeField]
        private GameObject[] obstacles;

        private Random _rand = new Random();

        private void Awake()
        {
            spawnPoints = new Vector3[6];
            for (int i = 0; i < 6; i++)
            {
                spawnPoints[i] = transform.GetChild(i + 1).transform.position;
            }
            
        }

        private void Start()
        {
            foreach (var VARIABLE in spawnPoints)
            {
                GameObject temp;
                int randN = _rand.Next(0, 10);
                if (randN%10 < 7)
                {
                    temp= Instantiate(obstacles[0], VARIABLE, Quaternion.identity);
                    temp.transform.parent = transform;
                    temp.transform.localScale = new Vector3(0.3f,0.5f,0.5f);
                    temp.transform.Rotate(Vector3.right * 90);
                }else if (randN%10 >= 7)
                {
                    temp = Instantiate(obstacles[1], VARIABLE, Quaternion.identity);
                    temp.transform.parent = transform;
                    temp.transform.localScale = new Vector3(0.5f,1f,0.5f);
                    
                    var position = temp.transform.localPosition;
                    position.y -= 0.5f ;
                    temp.transform.localPosition = position;
                }
                else
                {
                   continue;
                }
                
                
                int randI = _rand.Next(0, 3);
                
                if (randI % 3 == 1)
                {
                    var position = temp.transform.localPosition;
                    position.x = 1 ;
                    temp.transform.localPosition = position;
                }
                else if(randI % 3 == 2)
                {
                    var position = temp.transform.localPosition;
                    position.x = -1;
                    temp.transform.localPosition = position;
                }
                
               
            }
        }
    }
}