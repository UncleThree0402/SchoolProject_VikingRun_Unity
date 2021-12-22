using System;
using System.Collections;
using System.Collections.Generic;
using Controller;
using UnityEngine;
using ViewModel;

public class ShieldScores : MonoBehaviour
{
    private PlayerStatsViewModel psvm;
    
    private void Awake()
    {
        psvm = FindObjectOfType<PlayerStatController>().Psvm;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            psvm.AddScoresInt(1);
        }
    }
}
