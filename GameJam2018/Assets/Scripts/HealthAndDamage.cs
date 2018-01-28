using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthAndDamage : MonoBehaviour {

    public int playerHitPoints;

	// Use this for initialization
	void Start () {
		
	}
	void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Hubo una colision");
    }

	// Update is called once per frame
	void Update () {
		
	}
}
