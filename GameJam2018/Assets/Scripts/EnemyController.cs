using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;

public class EnemyController : MonoBehaviour 
{

    private AStar m_aStar;
    public float breakTime = 1.0f;
    public float scapeTime = 2.0f;
    public float deadTime = 5f;
    public int enemyHealth = 3;
    private bool isFollow;
    private bool isFinish;
    public bool stolenLife;
    private GeneralVars m_generalVars;

    public GameObject score;

    private void Awake()
    {
        m_generalVars = GameObject.Find("Scripts").GetComponent<GeneralVars>();
        m_aStar = GetComponent<AStar>();

    }

    // Use this for initialization
    void Start () 
    {
        isFinish = false;
        stolenLife = false;
        isFollow = true;
        m_aStar.state = AStar.States.FollowToTarget;
	}

     void Update()
    {
        //Muere
        if (enemyHealth <= 0)
        {
            //Retorna el corazon al jugador
            m_generalVars.recoverDamage(1);
            m_generalVars.addOnePoint();
            //m_generalVars.health++;
           // Debug.Log("Vida: " + m_generalVars.health + ", se recupera a: " + (m_generalVars.health + 1));
           // m_generalVars.player.GetComponent<HealthAndDamage>().recoverDamage(1);
            DestroyEnemy();
     
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //realiza un ataque
        if (other.gameObject.tag == "Player" && isFollow)
        {
            //quita una vida
            //m_generalVars.health--;
            //se adueña de la vida
            stolenLife = true;
            isFollow = false;
            StartCoroutine(Escape());
            //Esta parte es necesaria para mostrar los corazones
            //Si sale un error por referencia nula solo agrega el script "HealthAndDamage" al player
            m_generalVars.takeDamage(1);
            
        }

        if(other.gameObject.tag == "Wall" && isFinish)
        {
            isFinish = false;
            Invoke("DestroyEnemy", deadTime);
        }

		if (other.gameObject.tag == "BORDER") {
			Destroy(this.gameObject);
		}

        //Recibe daño
        if (other.gameObject.tag == "HitBox" && enemyHealth > 0)
        {
            other.gameObject.SetActive(false);
            if (m_generalVars.health == 3)
            {
                enemyHealth -= 1 ;
            }else if (m_generalVars.health == 2)
            {
                enemyHealth -= 2;
            }else if(m_generalVars.health == 1)
            {
                enemyHealth -= 3;
            }

        }
    }

    
	
    private IEnumerator Escape()
    {
        for (int i = 0; i < 3; i++) 
        {
            m_aStar.state = AStar.States.DoNotFollowTheTarget;
            yield return new WaitForSeconds(scapeTime);
            m_aStar.state = AStar.States.Stand;
            yield return new WaitForSeconds(breakTime);
        }
        //Desabilitamos todo los sensores
        for (int i = 0; i < m_aStar.sensors.Length; i++)
        {
            m_aStar.sensors[i].SetActive(false);
        }
        //----------------------------------
        isFinish = true;
        m_aStar.state = AStar.States.DoNotFollowTheTarget;
    }

    
    void DestroyEnemy()
    {
        Destroy(this.gameObject);
    }
}
