using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	void Start () 
	{

	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		Vector3 mouse = Input.mousePosition;
		mouse.z = 10;
		transform.position = Camera.main.ScreenToWorldPoint(mouse);	
	}
}
