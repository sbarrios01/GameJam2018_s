using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Sensors : MonoBehaviour 
{
    public bool sensor = true;
    public Vector3 scopeOfSensor = Vector3.zero;

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Wall" || other.gameObject.tag == "Player")
            sensor = false;
    }

     void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Wall" || other.gameObject.tag == "Player")
        sensor = true;
    }

}
