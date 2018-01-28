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
    private bool isFollow;
    public bool isFinish;
    public bool stolenLife;

    private void Awake()
    {
        m_aStar = GetComponent<AStar>();
    }

    // Use this for initialization
    void Start () 
    {
        isFinish = false;
        stolenLife=false;
        isFollow = true;
        m_aStar.state = AStar.States.FollowToTarget;
	}

     void FixedUpdate()
    {

    }

      void OnTriggerEnter2D(Collider2D other)
     {
         if (other.gameObject.tag == "Player" && isFollow)
         {
             stolenLife = true;
             isFollow = false;
             //inicia el escape
             StartCoroutine(Escape());
         }
         if(other.gameObject.tag == "Wall" && isFinish)
         {
             isFinish = false;
             //
             Invoke("DestroyEnemy", deadTime);
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
