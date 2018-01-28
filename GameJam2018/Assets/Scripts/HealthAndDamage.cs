using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthAndDamage : MonoBehaviour {

    public int playerHitPoints;
    private int maxHealth;
    public GameObject heart;
    private bool isDead;

    private int spriteSize = 150;
    private List<GameObject> hearts;
	// Use this for initialization
	void Start ()
    {
        maxHealth = playerHitPoints;
        Vector3 coordenadas = new Vector3(-1500, 1000, 0);
        hearts = new List<GameObject>();
        GameObject newHeart; 

        for(int i = 0; i < playerHitPoints;)
        {
            for (int j = 0; j < 2; j++)
            {
                if (i < playerHitPoints)
                {
                    newHeart = Instantiate<GameObject>(heart, coordenadas, Quaternion.identity);
                    hearts.Add(newHeart);
                    i++;
                }
                coordenadas.x += spriteSize;
            }
            coordenadas.y -= spriteSize;
            coordenadas.x = -1500;
        }
        isDead = false;
	}

    public void takeDamage(int damage)
    {
        Debug.Log("- Tenia " + playerHitPoints + " de vida, ahora tengo " + (playerHitPoints - damage) );
        hearts[playerHitPoints - 1].SetActive(false);
        playerHitPoints -= damage;
        if (playerHitPoints <= 0)
        {
            isDead = true;
            string sceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
        }
    }

    public void recoverDamage(int damage)
    {
        Debug.Log("+ Tenia " + playerHitPoints + " de vida, ahora tengo " + (playerHitPoints + damage));
        int recover = playerHitPoints;
        if (playerHitPoints + damage < maxHealth)
        {
            playerHitPoints += damage;
            hearts[playerHitPoints].SetActive(true);
        }
    }
}
