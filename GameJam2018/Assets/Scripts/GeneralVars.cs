using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralVars : MonoBehaviour {

    public int health = 3;

    [HideInInspector]
    public bool isDead = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (health > 3)
            health = 3;

        if (health <= 0 && !isDead)
        {
            isDead = true;
            Restart();
        }

	}

    void Restart()
    {
        string sceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }
}
