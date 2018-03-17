using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueEnemy : MonoBehaviour {

	Rigidbody2D rb2d;
	// Use this for initialization
	void Start () 
	{
		rb2d = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		rb2d.transform.position = new Vector3 (rb2d.transform.position.x, rb2d.transform.position.y-0.06f, rb2d.transform.position.z);
		if (transform.position.y <= -9) 
		{
			DestroyObject (gameObject);
		}
	}
}
