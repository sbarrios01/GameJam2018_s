using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _EjeX;      //movimiento en el eje x por velocidad
    [SerializeField]
    private float _EjeY;      //movimiento en el eje y por velocidad

    public float LocationX;
    public float LocationY;
    private Vector3 _LastMovement;
    [SerializeField]
    private GameObject _Atack;

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
        Atack();
    }

    private void Atack()
    {
        if (Input.GetButton("Fire1"))
        {
            Instantiate(_Atack, transform.position + _LastMovement, Quaternion.identity);
        }
    }

    private void Movement()
    {
        _EjeX = Input.GetAxis("Horizontal");
        _EjeY = Input.GetAxis("Vertical");
        if (_EjeX < 0)
        {
            _LastMovement = new Vector3(-1, 0, 0);
        }
        else if (_EjeX > 0)
        {
            _LastMovement = new Vector3(1, 0, 0);
        }
        if(_EjeY < 0)
        {
            _LastMovement = new Vector3(0, -1, 0);
        }
        if (_EjeY > 0)
        {
            _LastMovement = new Vector3(0, 1, 0);
        }

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