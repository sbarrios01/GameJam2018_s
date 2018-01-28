using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralVars : MonoBehaviour {

    public int healht = 3;

    [HideInInspector]
    public bool isDead = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (healht > 3)
            healht = 3;

        if (healht <= 0 && !isDead)
        {
            isDead = true;
        }

	}
}
