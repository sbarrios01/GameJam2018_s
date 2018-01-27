using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float _EjeX;      //movimiento en el eje x por velocidad
    private float _EjeY;      //movimiento en el eje y por velocidad

    private float LocationX = 1.0f;
    private float LocationY = 1.0f;

    [SerializeField]
    private float _Speed;      //velocidad en cuandros por segundo
                               // Use this for initialization
    void Start()
    {
        LocationX = transform.position.x;
        LocationY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        _EjeX = Input.GetAxis("Horizontal");
        _EjeY = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(_EjeX, _EjeY, 0f) * _Speed * Time.deltaTime);

        if (transform.position.x > 8.30)
        {
            transform.position = new Vector3(8.30f, transform.position.y, 0f);
        }
        else if (transform.position.x < -8.30)
        {
            transform.position = new Vector3(-8.30f, transform.position.y, 0f);
        }
        if (transform.position.y > 0)
        {
            transform.position = new Vector3(transform.position.x, 0f, 0f);
        }
        else if (transform.position.y < -4.20)
        {
            transform.position = new Vector3(transform.position.x, -4.20f, 0f);
        }
    }
}