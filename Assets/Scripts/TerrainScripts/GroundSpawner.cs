using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Random = System.Random;

public class GroundSpawner : MonoBehaviour
{
    public GameObject []roadType;
    Vector3 nextSpwanPoint;
    private GameObject pTile = null;
    private GameObject ppTile = null;
    private GameObject cTile = null;
    private bool isInit = false;

    [SerializeField]
    private Transform _player;

    private float[] angleList =
    {
        0, 90, 270
    };

    //Util
    private Random _rand = new Random();

    public void SpawnTile()
    {
        try
        {
            ppTile = pTile;
            pTile = cTile;
            GameObject temp;
            if (_rand.Next(0, 4) == 0 || !isInit)
            {
                temp  = Instantiate(roadType[0], nextSpwanPoint, Quaternion.Euler(0,_player.eulerAngles.y + angleList[0],0));
            }else if (_rand.Next(0, 4) == 1)
            {
                temp = Instantiate(roadType[1], nextSpwanPoint, Quaternion.Euler(0,_player.eulerAngles.y + angleList[1],0));
            }
            else if(_rand.Next(0, 4) == 2)
            {
                temp = Instantiate(roadType[2], nextSpwanPoint, Quaternion.Euler(0,_player.eulerAngles.y + angleList[2],0));
            }
            else
            {
                temp = Instantiate(roadType[3], nextSpwanPoint, Quaternion.Euler(0,_player.eulerAngles.y + angleList[0],0));
            }

            temp.transform.parent = transform;
            nextSpwanPoint = temp.transform.GetChild(0).transform.position;
            cTile = temp;
        }
        catch (Exception)
        {
            throw;
        }
        
    }


    private void Awake()
    {
        
    }

    void Start()
    {
        SpawnTile();
        isInit = true;
    }

    
    void Update()
    {
        
    }

    public GameObject PTile => pTile;

    public GameObject PpTile => ppTile;

    public GameObject CTile => cTile;

}
