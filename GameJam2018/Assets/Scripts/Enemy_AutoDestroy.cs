using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_AutoDestroy : MonoBehaviour {


    public float Timer;

	// Use this for initialization
	void Start () {
        Destroy(this.gameObject, Timer);
	}
    void Update()
    {
        //this.gameObject.transform.position.x = Player.LocationX;
    }
	
	// Update is called once per frame

}
