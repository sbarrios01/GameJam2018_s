using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float _EjeX;      //movimiento en el eje x por velocidad
    private float _EjeY;      //movimiento en el eje y por velocidad

    public float LocationX;
    public float LocationY;

    [SerializeField]
    private float _Speed;      //velocidad en cuandros por segundo
                               // Use this for initialization
    void Start()
    {
        _Speed = 6.0f;

    }

    // Update is called once per frame
    void Update()
    {
        LocationX = transform.position.x;
        LocationY = transform.position.y;
        Movement();
    }

    private void Movement()
    {
        _EjeX = Input.GetAxis("Horizontal");
        _EjeY = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(_EjeX, _EjeY, 0f) * _Speed * Time.deltaTime);

        if (transform.position.x > 6.15)
        {
            transform.position = new Vector3(6.15f, transform.position.y, 0f);
        }
        else if (transform.position.x < -6.15)
        {
            transform.position = new Vector3(-6.15f, transform.position.y, 0f);
        }
        if (transform.position.y > 4.5)
        {
            transform.position = new Vector3(transform.position.x, 4.5f, 0f);
        }
        else if (transform.position.y < -4.5)
        {
            transform.position = new Vector3(transform.position.x, -4.5f, 0f);
        }

    }
}