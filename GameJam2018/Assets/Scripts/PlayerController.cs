using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed;
    private Rigidbody2D m_rigidBody2d;
    private Vector3 moveInput;
    private Vector3 moveVelocity;
    private GeneralVars m_GeneralVars;
    private Animator m_animator;
    private string direction = "";
    public AtackController[] ataques;
    //public AudioClip soundMuerte;
    //public AudioClip soundCoin;

    public void Awake()
    {
        m_rigidBody2d = gameObject.GetComponent<Rigidbody2D>();
        m_GeneralVars = GameObject.Find("Scripts").GetComponent<GeneralVars>();
        m_animator = GetComponent<Animator>();
    }

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButton("Horizontal"))
        {
            moveInput = new Vector3(Input.GetAxis("Horizontal"), 0, 0f);
            if (Input.GetAxis("Horizontal") > 0)
            {
                //DERECHA
                SetAnimation("rigth");
                direction = "rigth";
            }
            else
            {
                //IZQUIERDA
                SetAnimation("left");
                direction = "left";
            }
        }

        if (Input.GetButton("Vertical"))
        {
            moveInput = new Vector3(0, Input.GetAxis("Vertical"), 0f);
            if (Input.GetAxis("Vertical") > 0)
            {
                //ARRIBA
                SetAnimation("up");
                direction = "up";
            }
            else
            {
                //ABAJO
                SetAnimation("down");
                direction = "down";
            }
        }

        if (!Input.GetButton("Horizontal") && !Input.GetButton("Vertical"))
        {
            moveInput = Vector3.zero;
        }

        moveVelocity = moveInput * moveSpeed;

        if (Input.GetButtonDown("Jump"))
        {
            Atack();
        }

    }

    void FixedUpdate()
    {
        if (!m_GeneralVars.isDead)
        {
            m_rigidBody2d.velocity = moveVelocity;
        }
        else
        {
            m_rigidBody2d.velocity = Vector2.zero;
        }
    }

    private void SetAnimation(string name)
    {
        m_animator.SetBool("rigth", false);
        m_animator.SetBool("left", false);
        m_animator.SetBool("up", false);
        m_animator.SetBool("down", false);
        m_animator.SetBool(name, true);
    }
    private void SetAttack(string name)
    {
        EndAnimation();
        m_animator.SetBool(name, true);
        Invoke("EndAnimation", .5f);
    }
    private void EndAnimation()
    {
        m_animator.SetBool("rigthAttack", false);
        m_animator.SetBool("leftAttack", false);
        m_animator.SetBool("upAttack", false);
        m_animator.SetBool("downAttack", false);
    }

    public void Atack()
    {
        if (direction == "rigth")
        {
            m_animator.StopPlayback();
            SetAttack("rigthAttack");
            
            ataques[0].StartAtack(m_GeneralVars.healht);
        }else if (direction == "left")
        {
            SetAttack("leftAttack");
            ataques[1].StartAtack(m_GeneralVars.healht);
        }
        else if (direction == "up")
        {
            SetAttack("upAttack");
            ataques[2].StartAtack(m_GeneralVars.healht);
        }
        else if (direction == "down")
        {
            SetAttack("downAttack");
            ataques[3].StartAtack(m_GeneralVars.healht);
        }
        //yield return new WaitForSeconds(0.5f);
    }

}
