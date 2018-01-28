using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/*
 Hecho por: Uriel Robles Cervantes
 */

[Serializable]
public class AStar : MonoBehaviour 
{
    public enum States
    {
        FollowToTarget,
        DoNotFollowTheTarget,
        Stand
    }

    public enum Movement
    {
        Vertical,
        Horizontal
    }

    public GameObject[] sensors;
    public Transform target;
    public States state = States.FollowToTarget;
    public Movement movement = Movement.Horizontal;
    public float speed=0.05f;
    public float distanceMiniumToTarget = 2.3f;

    Animator _Animations;

    private List<int> sensorsActive= new List<int>();
    private float[] f;
    private float[] g;
    private float[] h;
    private int bestSensor;
    private Vector3 directionV3;
    
     //f = g + h 
    // f:  valor numérico del movimiento estudiado
    // g:  coste de llegar del estado inicial al estado actual
    // h:  coste de llegar desde el estado actual al estado final o objetivo
    // sensor 1 y 2 es vertical (0,1)
    // sensor 3 y 4 es horizontal (2,3)

    void Awake()
    {
        _Animations = GetComponent<Animator>();
        bestSensor = -1;
        g = new float[sensors.Length];
        speed = Mathf.Abs(speed);
        //Aplicamos por primera vez el algoritmo A*
        Ax();
    }

    void FixedUpdate()
    {
        Direction();
        //----------------------------
        if (state == States.Stand)
            return;
        //---------------------------
        if (sensors[sensorsActive[bestSensor]].GetComponent<Sensors>().sensor)
        {
            //Nos movemos al mejor camino
            transform.position += directionV3 * speed;
            //---------------------------------------
            PossibleDirection();

            //no se en que momento se programara el "intersect with player" pero 
            //cuando lo hagan implementen el siguiente codigo para las animaciones:
            //cuando ataca por la derecha: 
            //_Animations.SetBool("RigthAttack", true);
            //cuando ataca por la izquierda: 
            //_Animations.SetBool("LeftAttack", true);
            /*una vez que se ejecuto el codigo anterior se ejecutara el siguiente:
                _Animations.SetBool("stolen", true);
              aleatoriamente segun hernan entrara en cansancio despues de un tiempo,
              ejecutar el siguiente codigo para la animacion de cansancio:
              _Animations.SetBool("stolen", false)
              _Animations.SetBool("tired", true)
              (despues de un corto tiempo regresar al estado anterior:)
             _Animations.SetBool("stolen", true)
              _Animations.SetBool("tired", false) */
        }
        else
        {
            //Aplicamos nuevamente el algoritmo A*
            Ax();
        }
    }

    void Ax() 
    {
       //Verificamos que haya sensores disponibles
        if (!SensorsActive())
            return;
        //-----------------------------------------------
        
        f = new float[sensorsActive.Count];
        h = new float[sensorsActive.Count];
        float []_g=new float[sensorsActive.Count];
        //Calculamos los costos posibles
        for(int i=0;i<sensorsActive.Count;i++)
        {
            //----------------------------------------------------------------------------------------------------
            h[i] = Vector3.Distance(sensors[sensorsActive[i]].transform.position, target.position);
            //----------------------------------------------------------------------------------------------------
            _g[i] = Vector3.Distance(sensors[sensorsActive[i]].transform.position, transform.position);
            Debug.DrawLine(sensors[sensorsActive[i]].transform.position, transform.position,Color.red);
        }
        //Calculamos el valor numerico
        for (int i = 0; i < sensorsActive.Count; i++)
        {
            f[i]=h[i] + _g[i] + g[sensorsActive[i]];
        }  
        //Buscamos el mejor camino
        bestSensor = 0;
        float bestF=f[bestSensor];
        for (int i = 1; i < sensorsActive.Count; i++)
        {
           if(state==States.FollowToTarget)
           {
               if(bestF>f[i])
               {
                   bestF = f[i];
                   bestSensor = i;
               }
           }else if(state==States.DoNotFollowTheTarget)
           {
               if (bestF < f[i])
               {
                   bestF = f[i];
                   bestSensor = i;
               }
           }
        }
        //
        directionV3 = sensors[sensorsActive[bestSensor]].GetComponent<Sensors>().scopeOfSensor;
        //Sumamos el valor g al camino ya recorrido
        g[sensorsActive[bestSensor]] += g[bestSensor];
    }

    bool SensorsActive()
    {
        sensorsActive.Clear();
        for(int i=0;i<sensors.Length;i++)
        {
            if(sensors[i].GetComponent<Sensors>().sensor)
            {
                sensorsActive.Add(i);
            }
        }
        //-------------------------------
        if (sensorsActive.Count != 0)
            return true;
        else
            return false;
    }

    void Direction()
    {
        int h = (int)sensors[sensorsActive[bestSensor]].GetComponent<Sensors>().scopeOfSensor.x;
        int v = (int)sensors[sensorsActive[bestSensor]].GetComponent<Sensors>().scopeOfSensor.y;
        if (Mathf.Abs(h) == 1)
            movement = Movement.Horizontal;
        else if (Mathf.Abs(v) == 1)
            movement = Movement.Vertical;      
    }

    void PossibleDirection()
    {
        float distance1 = Vector3.Distance(sensors[0].transform.position, target.position);
        float distance2 = Vector3.Distance(sensors[1].transform.position, target.position);
        float distance3 = Vector3.Distance(sensors[2].transform.position, target.position);
        float distance4 = Vector3.Distance(sensors[3].transform.position, target.position);
        //--------------------------------------------------------------------------
        if (distance1 < distanceMiniumToTarget || distance2 < distanceMiniumToTarget || distance3 < distanceMiniumToTarget || distance4 < distanceMiniumToTarget)
            Ax();
    }

     void OnDrawGizmos()
    {
        Gizmos.DrawLine(target.transform.position,transform.position);
    }


}
