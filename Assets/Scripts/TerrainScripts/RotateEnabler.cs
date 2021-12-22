using System;
using System.Collections;
using System.Collections.Generic;
using EnemyStateMachineScripts;
using UnityEngine;

public class RotateEnabler : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<PlayerStateMachine>().AbleToRotate = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<PlayerStateMachine>().AbleToRotate = false;
        }
    }
}
