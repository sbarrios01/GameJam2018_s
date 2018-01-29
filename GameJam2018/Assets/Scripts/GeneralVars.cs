using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GeneralVars : MonoBehaviour {

    public GameObject player;
    public Text score;

    public Text txtTime;

    public int health;
    public int maxHealth;
    public GameObject heart;

    private int spriteSize = 150;
    private List<GameObject> hearts;
    [HideInInspector]
    public bool isDead = false;
    public int tiempoPartida = 0;

	// Use this for initialization
	void Start () {

        StartCoroutine(TiempoPartida());

        maxHealth = health;

        score.text = "0";

        Debug.Log("1.- Health:" +health);
        Vector3 coordenadas = new Vector3(-1500, 1000, 0);
        hearts = new List<GameObject>();
        GameObject newHeart;

        for (int i = 0; i < health;)
        {
            for (int j = 0; j < 2; j++)
            {
                if (i < health)
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
        Debug.Log("- Tenia " + health + " de vida, ahora tengo " + (health - damage));
        hearts[health - 1].SetActive(false);
        health -= damage;
        if (health <= 0)
        {
            isDead = true;
            //string sceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
            //UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
            SceneManager.LoadScene(3, LoadSceneMode.Single);
        }
    }

    // Update is called once per frame
    void FixedUpdate () {
        
        Debug.Log("2.- Health:" + health);
        if (health > 3)
            health = 3;

        if (health <= 0 && !isDead)
        {
            isDead = true;
            Restart();
        }

	}

    public void recoverDamage(int damage)
    {
        Debug.Log("+ Tenia " + health + " de vida, ahora tengo " + (health + damage));

        if (health + damage <= maxHealth)
        {
            health += damage;
            hearts[health-1].SetActive(true);
        }
    }

    void Restart()
    {
        //string sceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
        //UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
        SceneManager.LoadScene(3, LoadSceneMode.Single);
    }

    public void addOnePoint()
    {
        int myScore = Convert.ToInt32(score.text) + 1;

        score.text = myScore.ToString();
    }

    IEnumerator TiempoPartida()
    {
        do
        {
            tiempoPartida++;
            yield return new WaitForSeconds(1);
            txtTime.text = tiempoPartida + "";
        } while (true);
    }
}
