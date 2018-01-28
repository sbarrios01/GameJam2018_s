using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthAndDamage : MonoBehaviour {

    public int playerHitPoints;
    public GameObject heart;
    private bool isDead;

    private int spriteSize = 150;
    private List<Vector3> hearthsVectors;
	// Use this for initialization
	void Start () {
        Vector3 coordenadas = new Vector3(-1500, 1000, 0);

        for(int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                Instantiate<GameObject>(heart, coordenadas, Quaternion.identity);
                coordenadas.x += spriteSize;
            }
            coordenadas.y -= spriteSize;
            coordenadas.x = -1500;
        }
        isDead = false;
	}

    public void takeDamage(int damage)
    {
        Debug.Log("Tengo " + playerHitPoints + " de vida, tomando " + damage + " de daño");
        playerHitPoints -= damage;
        if (playerHitPoints <= 0)
        {
            isDead = true;
            string sceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
        }
    }
}
