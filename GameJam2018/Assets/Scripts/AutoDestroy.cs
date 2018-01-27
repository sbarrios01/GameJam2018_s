using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour {


    public float Timer;

	// Use this for initialization
	void Start () {
        Destroy(this.gameObject, Timer);
	}
	
	// Update is called once per frame

}
