using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    public float moveSpeed;
    private Rigidbody2D m_rigidBody2d;
    private Vector3 moveInput;
    private Vector3 moveVelocity;
    public Animator m_animator;
    public AudioClip soundMuerte;
    public AudioClip soundCoin;

    // Use this for initialization
    void Start()
    {
        m_rigidBody2d = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        moveInput = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);
        moveVelocity = moveInput * moveSpeed;

        /*Vector3 finalPos = transform.position;

        finalPos.x = Mathf.Min(7f, Mathf.Max(-7f, finalPos.x));
        finalPos.y = Mathf.Min(3.5f, Mathf.Max(-3.5f, finalPos.y));

        transform.position = finalPos;*/

    }

    void FixedUpdate()
    {
        //if (!perdiste)
        //{
            m_rigidBody2d.velocity = moveVelocity;
        //}
        //else
        //{
        //    m_rigidBody2d.velocity = Vector2.zero;
        //}
    }

    /*void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy" && !m_generalVars.perdiste)
        {
            m_generalVars.perdiste = true;
            m_animator.SetTrigger("perdiste");
            m_generalVars.DetenerlMusica();
            m_generalVars.ReproducirSFX(soundMuerte);
        }
        else if (other.gameObject.tag == "HopeAzul")
        {
            m_generalVars.puntos += 10;
            Destroy(other.gameObject);
            m_generalVars.ReproducirSFX(soundCoin);
        }
    }*/

}
