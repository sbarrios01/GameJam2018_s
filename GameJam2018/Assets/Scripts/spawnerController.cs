using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerController : MonoBehaviour {
	public GameObject spawner; 
	public GameObject enemy;
	private Rigidbody2D myRigidBody;
	[SerializeField]
	private int speed;
	[SerializeField]
	private float spawnTime;
	[SerializeField]
	private int distancefromspawner;
	private bool direction = true;
	// Use this for initialization
	void Start () {
		myRigidBody = spawner.GetComponent<Rigidbody2D>();
		InvokeRepeating ("Spawn", spawnTime, spawnTime);
	}
	
	void FixedUpdate()
	{
		Movement();
	}

	private void Movement()
	{
		//_EjeX = Input.GetAxis("Horizontal");
		//_EjeY = Input.GetAxis("Vertical");
		if (direction) {
			myRigidBody.velocity = new Vector3 (speed, 0, 0);


		} else {
			myRigidBody.velocity = new Vector3 (-speed, 0, 0);
		} 
	}

	void Spawn ()
	{

		Instantiate (enemy, myRigidBody.position+new Vector2(0,-distancefromspawner),new Quaternion(0,0,0,0.0f));
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Wall" )
			direction=!direction;
	}

}
