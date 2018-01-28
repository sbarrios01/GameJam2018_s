using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject player; //player debe tener un rigidbody
    private Rigidbody2D myRigidBody;

    private float _EjeX;      //movimiento en el eje x por velocidad
    private float _EjeY;      //movimiento en el eje y por velocidad

     Animator _Animations;

    [SerializeField]
    public float LocationX;
    [SerializeField]
    public float LocationY;

    private Vector3 _LastMovement;
    [SerializeField]
    private GameObject _Atack;
    private float _atackCooldown;

    [SerializeField]
    private int _Speed;      //velocidad en cuandros por segundo
                             // Use this for initialization
    [SerializeField]
    private int _distance_player_attack;

    private char _Direction; //a <-, w up, d ->, s down;

    [SerializeField]
    private float _DeltaTime;
    const int Screen_Width = 1115;
    const int Screen_Heigth = 1115;
    void Start()
    {
        _Animations = GetComponent<Animator>();
        myRigidBody = player.GetComponent<Rigidbody2D>();
        _LastMovement = new Vector3(0, _distance_player_attack + 30, 0);
        _atackCooldown = 0;
 
    }


    /*
    void Update()
    {
        LocationX = transform.position.x;
        LocationY = transform.position.y;
        Movement();
        Atack();
    }*/

    void FixedUpdate()
    {
        
        Movement();
        Attack();
    }

    private void Attack()
    {
        _atackCooldown += Time.deltaTime;
        if (Input.GetButton("Fire1") && _atackCooldown > _DeltaTime && _Direction == 'a')
        {
            _atackCooldown = 0;
            Instantiate(_Atack, transform.position + _LastMovement, Quaternion.Euler(new Vector3(0, 0, 0)));
        }
        else if (Input.GetButton("Fire1") && _atackCooldown > _DeltaTime && _Direction == 'w')
        {
            _atackCooldown = 0;
            Instantiate(_Atack, transform.position + _LastMovement, Quaternion.Euler(new Vector3(180, 180, 90)));
        }
        else if (Input.GetButton("Fire1") && _atackCooldown > _DeltaTime && _Direction == 'd')
        {
            _atackCooldown = 0;
            Instantiate(_Atack, transform.position + _LastMovement, Quaternion.Euler(new Vector3(0, 180, 0)));
        }
        else if (Input.GetButton("Fire1") && _atackCooldown > _DeltaTime && _Direction == 's')
        {
            _atackCooldown = 0;
            Instantiate(_Atack, transform.position + _LastMovement, Quaternion.Euler(new Vector3(-180, -180, -90)));
        }
        else if (Input.GetButton("Fire1") && _atackCooldown > _DeltaTime)
        {
            _atackCooldown = 0;
            Instantiate(_Atack, transform.position + _LastMovement, Quaternion.identity);
        }
    }

    private void SetAnimation(string name)
    {
        _Animations.SetBool("left", false);
        _Animations.SetBool("up", false);
        _Animations.SetBool("rigth", false);
        _Animations.SetBool("down", false);
        _Animations.SetBool(name, true);
    }

    private void Movement()
    {
        //_EjeX = Input.GetAxis("Horizontal");
        //_EjeY = Input.GetAxis("Vertical");
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            SetAnimation("left");
            myRigidBody.velocity = new Vector3(-200, 0, 0);
            _LastMovement = new Vector3(-_distance_player_attack, 0, 0);

        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            SetAnimation("rigth");
            myRigidBody.velocity = new Vector3(200, 0, 0);
            _LastMovement = new Vector3(_distance_player_attack, 0, 0);
        }
        else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            SetAnimation("up");
            myRigidBody.velocity = new Vector3(0, 200, 0);
            _LastMovement = new Vector3(0, _distance_player_attack + 30, 0);
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            SetAnimation("down");
            myRigidBody.velocity = new Vector3(0, -200, 0);
            _LastMovement = new Vector3(0, -_distance_player_attack - 30, 0);
        }
		

        /*
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
        */
    }
}