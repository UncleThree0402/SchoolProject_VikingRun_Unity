using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Random = System.Random;

public class GroundSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _roadType;
    private Vector3 _nextSpwanPoint;
    
    // Tile position
    private GameObject _previousTile = null;
    private GameObject _antepenultimateTile = null;
    private GameObject _currentTile = null;
    
    private bool _isInit = false;

    [SerializeField] private Transform _player;

    private float[] _angleList = {0, 90, 270};

    //Util
    private Random _rand = new Random();

    public void SpawnTile()
    {
        _antepenultimateTile = _previousTile;
        _previousTile = _currentTile;
        GameObject nextTile;
        if (_rand.Next(0, 4) == 0 || !_isInit)
        {
            nextTile = Instantiate(_roadType[0], _nextSpwanPoint,
                Quaternion.Euler(0, _player.eulerAngles.y + _angleList[0], 0));
        }
        else if (_rand.Next(0, 4) == 1)
        {
            nextTile = Instantiate(_roadType[1], _nextSpwanPoint,
                Quaternion.Euler(0, _player.eulerAngles.y + _angleList[1], 0));
        }
        else if (_rand.Next(0, 4) == 2)
        {
            nextTile = Instantiate(_roadType[2], _nextSpwanPoint,
                Quaternion.Euler(0, _player.eulerAngles.y + _angleList[2], 0));
        }
        else
        {
            nextTile = Instantiate(_roadType[3], _nextSpwanPoint,
                Quaternion.Euler(0, _player.eulerAngles.y + _angleList[0], 0));
        }

        nextTile.transform.parent = transform;
        _nextSpwanPoint = nextTile.transform.GetChild(0).transform.position;
        _currentTile = nextTile;
    }

    void Start()
    {
        SpawnTile();
        _isInit = true;
    }
    

    public GameObject PreviousTile => _previousTile;

    public GameObject AntepenultimateTile => _antepenultimateTile;

    public GameObject CurrentTile => _currentTile;
}