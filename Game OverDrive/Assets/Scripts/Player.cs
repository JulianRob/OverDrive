using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	public GameObject restart;
	public GameObject quit;
	public GameObject score;
	public Text scoreText;
	public Text begin;
	bool start = false;
	int scoreNumber;
	Vector3 mouse;
	Vector3 recordPosition;

	Vector3 position1 = new Vector3 (0, 0,10);
	Vector3 position2 = new Vector3 (0, 0,10);
	Vector3 position3 = new Vector3 (0, 0,10);
	Vector3 position4 = new Vector3 (0, 0,10);

	Vector3 velocity1 = new Vector3(0, 0,10);
	Vector3 velocity2 = new Vector3(0, 0,10);
	Vector3 velocity3 = new Vector3(0, 0,10);

	Vector3 acceleration1 = new Vector3(0, 0,10);
	Vector3 acceleration2 = new Vector3(0, 0,10);

	Vector3 jerk1 = new Vector3(0, 0,10);

	float magnitude;
	float slideScale;
	float timeChange;

	void Awake()
	{
		Application.targetFrameRate = 60; //60
	}

	void Start () 
	{
		scoreNumber = 0;
		score.SetActive (false);
		slideScale = 300; //400
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
		if (start == false && Input.GetMouseButton(0)) //&& counter >= 200
		{
			start = true;
			begin.enabled = false;
			score.SetActive (true);
			GameObject.Find("Spawn").GetComponent<Spawn> ().start = true;
			mouse = Input.mousePosition;
			mouse.z = 10;
		}

		if (start == true) 
		{
			timeChange = Time.fixedDeltaTime;

			if (Input.GetMouseButton (0)) 
			{
				mouse = Input.mousePosition;
				mouse.z = 10;
				transform.position = Camera.main.ScreenToWorldPoint(mouse); //finalposition + newposition)
				/*
				if (recordPosition != mouse)
				{
					recordPosition = mouse;
					position1 = position2; //x1 oldest
					position2 = position3;
					position3 = position4;
					position4 = new Vector3 (mouse.x, mouse.y,10); //x4 latest
					if(position1.x != 0 && position1.y != 0)
					{
						velocity3 = (position4 - position3) / (timeChange); 
						velocity2 = (position3 - position2) / (timeChange);
						velocity1 = (position2 - position1) / (timeChange);

						acceleration2 = (velocity3 - velocity2) / (timeChange);
						acceleration1 = (velocity2 - velocity1) / (timeChange);

						jerk1 = (acceleration2 - acceleration1) / (timeChange);

						magnitude = Mathf.Sqrt(Mathf.Pow(velocity3.x,2)+Mathf.Pow(velocity3.y,2));

						if (magnitude <= 300) {
							transform.position = Camera.main.ScreenToWorldPoint (mouse + (((timeChange * velocity3) + (0.5f * acceleration2 * Mathf.Pow (timeChange, 2f)) + ((1f / 3f) * Mathf.Pow (timeChange, 3f) * jerk1))));
						} else {
							transform.position = Camera.main.ScreenToWorldPoint (mouse + (slideScale/(magnitude/3.5f))*(((timeChange * velocity3) + (0.5f * acceleration2 * Mathf.Pow (timeChange, 2f)) + ((1f / 3f) * Mathf.Pow (timeChange, 3f) * jerk1))));
						}
					}

				}
				*/
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
		if(other.CompareTag("BlueEnemy"))
			{
				Death ();
			}

		if(other.CompareTag("Collectable"))
			{
				Destroy (other.gameObject);
				scoreNumber += 100;
			}
	}
}