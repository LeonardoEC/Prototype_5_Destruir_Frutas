using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensor_Controller : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Target"))
        {
            other.gameObject.SetActive(false);
        }
        if(other.CompareTag("Target_Good"))
        {
            other.gameObject.SetActive(false);
            Game_Manager.instance.IsGameOver();
        }
    }
}
