using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	public GameObject restart;
	public GameObject quit;
	public Text scoreText;
	public Text begin;
	bool start = false;
	int scoreNumber;
	Vector3 mouse;
	public float speed = 0.1F;

	void Start () 
	{
		scoreNumber = 0;
	}

	void Death()
	{
		restart.SetActive (true);
		quit.SetActive (true);
		DestroyObject (gameObject);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (start == false && Input.GetMouseButton(0)) 
		{
			start = true;
			begin.enabled = false;
			GameObject.Find("Spawn").GetComponent<Spawn> ().start = true;
			mouse = Input.mousePosition;
			mouse.z = 10;
		}

		if (start == true) 
		{
			if (Input.GetMouseButton (0)) 
			{
				mouse = Input.mousePosition;
				mouse.z = 10;
				transform.position = Camera.main.ScreenToWorldPoint(mouse);	//finalposition + newposition)
				scoreText.text = " Score:" + scoreNumber;
				scoreNumber += 1;
			} 
			else 
			{
				Death ();
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		Death ();
	}
}

/*
finalPosition = mouse;
newPosition = (finalPosition - initialPosition)/1.1f;
if((Mathf.Abs(newPosition.x) + Mathf.Abs(newPosition.y)) <= 900)
{
	Debug.Log (Mathf.Abs(newPosition.x)+Mathf.Abs(newPosition.y));
	newPosition = newPosition / (1+ Mathf.Rad2Deg*(Mathf.Cos((Mathf.Abs(newPosition.x)+Mathf.Abs(newPosition.y))/5f)));
}
*/