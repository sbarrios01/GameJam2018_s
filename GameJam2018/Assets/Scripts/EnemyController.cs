using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyController : MonoBehaviour 
{

    private AStar m_aStar;
    public float breakTime = 1.0f;
    public float scapeTime = 2.0f;
    private bool isFollow = true;

    private void Awake()
    {
        m_aStar = GetComponent<AStar>();
    }

    // Use this for initialization
    void Start () 
    {
        m_aStar.state = AStar.States.FollowToTarget;
	}

     void FixedUpdate()
    {
        try
        {
            //Si un sensor toco al jugador
            bool sensonr1 = m_aStar.sensors[0].GetComponent<Sensors>().sensor;
            bool sensonr2 = m_aStar.sensors[1].GetComponent<Sensors>().sensor;
            bool sensonr3 = m_aStar.sensors[2].GetComponent<Sensors>().sensor;
            bool sensonr4 = m_aStar.sensors[3].GetComponent<Sensors>().sensor;

            if ((sensonr1 || sensonr2 || sensonr3 || sensonr4) && isFollow)
            {

                isFollow = false;
                //inicia el escape
                StartCoroutine(Escape());
            }
        }catch(Exception e)
        {
            Debug.LogWarning(e.Message);
        }
     }
	
    private IEnumerator Escape()
    {
        for (int i = 0; i < 3; i++) {
            m_aStar.state = AStar.States.DoNotFollowTheTarget;
            yield return new WaitForSeconds(scapeTime);
            m_aStar.state = AStar.States.Stand;
            yield return new WaitForSeconds(breakTime);
        }
        m_aStar.state = AStar.States.DoNotFollowTheTarget;
    }
}
