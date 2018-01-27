using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    private float _EjeX;      //movimiento en el eje x por velocidad
    private float _EjeY;      //movimiento en el eje y por velocidad

    private float LocationX;
	private float LocationY;
    private Vector3 _LastMovement;
    [SerializeField]
    private GameObject _Atack;

    [SerializeField]
    private int _Speed;      //velocidad en cuandros por segundo
                               // Use this for initialization
	[SerializeField]
	private int _distance_player_attack;

	const int Screen_Width = 1115;
	const int Screen_Heigth = 1115;
    void Start()
    {
        

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
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            _LastMovement = new Vector3(-_distance_player_attack, 0, 0);
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
			_LastMovement = new Vector3(_distance_player_attack, 0, 0);
        }
        if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.UpArrow))
        {
			_LastMovement = new Vector3(0, -_distance_player_attack, 0);
        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.DownArrow))
        {
			_LastMovement = new Vector3(0, _distance_player_attack, 0);
        }

        transform.Translate(new Vector3(_EjeX, _EjeY, 0) * _Speed * Time.deltaTime);

		if (transform.position.x > Screen_Width)
        {
			transform.position = new Vector3(Screen_Width, transform.position.y, 0);
        }
		else if (transform.position.x < -Screen_Width)
        {
			transform.position = new Vector3(-Screen_Width, transform.position.y, 0);
        }
		if (transform.position.y > Screen_Heigth)
        {
			transform.position = new Vector3(transform.position.x, Screen_Heigth, 0);
        }
		else if (transform.position.y < -Screen_Heigth)
        {
			transform.position = new Vector3(transform.position.x, -Screen_Heigth, 0);
        }

    }
}