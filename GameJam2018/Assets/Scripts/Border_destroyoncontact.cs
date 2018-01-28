using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Border_destroyoncontact : MonoBehaviour {

	// Use this for initialization
	void OnCollisionExit (Collision col)
	{
		Debug.Log ("On collision " + col.gameObject.name);
			Destroy(col.gameObject);

	}
}
