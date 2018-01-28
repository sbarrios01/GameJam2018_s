using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerController : MonoBehaviour {
	public GameObject spawner; 
	public GameObject [] enemy;
	private Rigidbody2D myRigidBody;
	[SerializeField]
	private int speed;
	[SerializeField]
	private float spawnTime;
	[SerializeField]
	private int distancefromspawner;

    private bool direction;
	[SerializeField]
	private Vector2 Startposition = new Vector2 (-800, 800);

    Animator _Animations;
    private float _EjeX;
    private float _EjeY;
    private float _random;

    // Use this for initialization
    void Start () {
        _Animations = GetComponent<Animator>();
        myRigidBody = GetComponent<Rigidbody2D>();
		Random.seed = (int)System.DateTime.Now.Ticks;
		Invoke("Spawn", spawnTime);
        direction = true;

    }

    void FixedUpdate()
	{
		Movement();
	}

	private void Movement()
	{
        if(this.transform.position.x < 0)
        {
            _Animations.SetBool("Rigth", false);
        }
        else
        {
            _Animations.SetBool("Rigth", true);
        }

        //movimientos aleatorios 
		if (direction) {
			myRigidBody.velocity = new Vector3 (speed, 0, 0);
		} else {
			myRigidBody.velocity = new Vector3 (-speed, 0, 0);
		}
		/*
		 *  if (_random < 5)
            {
                //myRigidBody.velocity = new Vector3 (speed, 0, 0);
                this.transform.Translate(new Vector3(speed, 0, 0)  * Time.deltaTime);
            }
            else if(_random > 5)
            {
               // myRigidBody.velocity = new Vector3(-speed, 0, 0);
                this.transform.Translate(new Vector3(-speed, 0, 0)  * Time.deltaTime);
            }
        else{
                if (_random < 5)
                {
                    //myRigidBody.velocity = new Vector3(0, speed, 0);
                    this.transform.Translate(new Vector3(0, speed, 0)  * Time.deltaTime);
                }
                else if (_random > 5)
                {
                    //myRigidBody.velocity = new Vector3(0, -speed, 0);
                    this.transform.Translate(new Vector3(0, -speed, 0)  * Time.deltaTime);
                }
		 */
    }

	void Spawn ()
	{

		Instantiate (enemy[Random.Range(0,enemy.Length)], myRigidBody.position+new Vector2(0,-distancefromspawner),new Quaternion(0,0,0,0.0f));
		Invoke("Spawn", spawnTime+Random.value*spawnTime);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
        if (other.gameObject.tag == "Wall")
        {
            direction = !direction;
            //_random = Random.Range(0f, 10f);
        }
		if (other.gameObject.tag == "BORDER") {
			Instantiate (spawner, Startposition,new Quaternion(0,0,0,0.0f));
			Destroy(this.gameObject);
        }
	}

}
