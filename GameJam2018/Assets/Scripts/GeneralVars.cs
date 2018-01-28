using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralVars : MonoBehaviour {

    public GameObject player;

    public int health;

    [HideInInspector]
    public bool isDead = false;

	// Use this for initialization
	void Start () {

        health = 3;
        Debug.Log("1.- Health:" +health);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        
        Debug.Log("2.- Health:" + health);
        if (health > 3)
            health = 3;

        if (health <= 0 && !isDead)
        {
            isDead = true;
           // Restart();
        }

	}

    void Restart()
    {
        string sceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }
}
