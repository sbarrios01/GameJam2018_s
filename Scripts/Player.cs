using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed = 0.05f;
    private Vector3 posInit;



    void Start()
    {
        speed = Mathf.Abs(speed);
        posInit = transform.position;
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        //Estamos evitando que se pulse las teclas hacia arriba y hacia abajo
        if (Mathf.Abs(h) > 0 && Mathf.Abs(v) > 0)
            return;
        //-------------------------------------------------------------------
        if (Mathf.Abs(h) > 0)
            Movement(h, 0f);
        else if (Mathf.Abs(v) > 0)
            Movement(0f, v);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
            transform.position = posInit;
    }

    void Movement(float h, float v)
    {
        Vector3 pos = transform.position;
        pos.x += (h * speed);
        pos.y += (v * speed);
        transform.position = pos;
    }

}
