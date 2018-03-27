using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	public GameObject restart;
	public GameObject quit;
	public GameObject score;
	public Slider slider;
	public float NumberScale = 10;
	public Text TimeFrame;
	public Text scoreText;
	public Text adjustmentText;
	public Text begin;
	bool start = false;
	int scoreNumber;
	Vector3 mouse;
	Vector3 recordPosition;
	//to calculate velocity divide by the time of 1 frame. 

	//higher the number the latest it is.

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
	float timeManipulation;
	float timeChange;
	float adjustment;
	public float adjustmentNumber;

	float average;
	int countMagnitude;

	int counter = 0;

	void Awake()
	{
		Application.targetFrameRate = 60; //60
		//QualitySettings.vSyncCount = 0;
	}

	void Start () 
	{
		scoreNumber = 0;
		score.SetActive (false);
		slideScale = 300; //400
		timeManipulation = 1; //1
		average = 0;
		countMagnitude = 1;
		adjustmentNumber = 1;
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
		//if(Application.targetFrameRate != 60)
		//	Application.targetFrameRate = 60;

		//counter += 1;

		NumberScale = slider.value;
		TimeFrame.text = "" + slider.value;

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
			//timeManipulation = slider.value;
			timeChange = Time.fixedDeltaTime*timeManipulation; //Time.FixedDeltaTime

			if (Input.GetMouseButton (0)) 
			{
				mouse = Input.mousePosition;
				mouse.z = 10;
				transform.position = Camera.main.ScreenToWorldPoint(mouse); //finalposition + newposition)

				/////

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

						//adjustmentText.text = "" + adjustmentNumber;

						/*
						//adjustment = Mathf.Exp (.0001f * magnitude);

						//if (adjustment >= 10) 
						//{
						//	adjustment = 10;
						//}

						if (magnitude >= 2000)
						{
							adjustment = 1;
							//magnitude/375
							//Mathf.Exp (magnitude/ 932);
							// magnitude/300
						} 
						else 
						{
							adjustment = 1;
					    }
						*/

						//adjustment = 1;

						//adjustment = (2*Mathf.Exp(-0.00001f*Mathf.Pow(magnitude-2000,2))) + 1;
						//Debug.Log (adjustment);
						//average += magnitude;
						//TimeFrame.text = "" + average/countMagnitude;
						//TimeFrame.text = "" + magnitude;
						//countMagnitude += 1;

						//transform.position = Camera.main.ScreenToWorldPoint (mouse + adjustment*(((timeChange * velocity3) + (0.5f * acceleration2 * Mathf.Pow (timeChange, 2f)) + ((1f / 3f) * Mathf.Pow (timeChange, 3f) * jerk1))));



						//Test this after you have ran, studied, and completed your homework. 130 is the latest one :) 
						if (magnitude <= 300) {
							transform.position = Camera.main.ScreenToWorldPoint (mouse + (((timeChange * velocity3) + (0.5f * acceleration2 * Mathf.Pow (timeChange, 2f)) + ((1f / 3f) * Mathf.Pow (timeChange, 3f) * jerk1))));
						} else {
							transform.position = Camera.main.ScreenToWorldPoint (mouse + (slideScale/(magnitude/NumberScale))*(((timeChange * velocity3) + (0.5f * acceleration2 * Mathf.Pow (timeChange, 2f)) + ((1f / 3f) * Mathf.Pow (timeChange, 3f) * jerk1))));
						}
					
						//THIS NEARLY HAS NO LATENCY BUT JITTERS TOO MUCH.
						/*
						if (magnitude <= 1000) {
							transform.position = Camera.main.ScreenToWorldPoint (mouse + 3*(((timeChange * velocity3) + (0.5f * acceleration2 * Mathf.Pow (timeChange, 2f)) + ((1f / 3f) * Mathf.Pow (timeChange, 3f) * jerk1))));
						} else {
							transform.position = Camera.main.ScreenToWorldPoint (mouse + (slideScale/(magnitude/10))*(((timeChange * velocity3) + (0.5f * acceleration2 * Mathf.Pow (timeChange, 2f)) + ((1f / 3f) * Mathf.Pow (timeChange, 3f) * jerk1))));
						}
						*/

						//THIS LAGS BEHIND THE FINGER BUT DOES NOT JITTER
						/*
						slideScale = 400;
				
						if (magnitude >= 400)
						{
							transform.position = Camera.main.ScreenToWorldPoint (mouse + ((slideScale / magnitude) * ((timeChange * velocity3) + (0.5f * acceleration2 * Mathf.Pow (timeChange, 2f)) + ((1f / 3f) * Mathf.Pow (timeChange, 3f) * jerk1))));
						} 
						else 
						{
							transform.position = Camera.main.ScreenToWorldPoint (mouse + (((timeChange * velocity3) + (0.5f * acceleration2 * Mathf.Pow (timeChange, 2f)) + ((1f / 3f) * Mathf.Pow (timeChange, 3f) * jerk1))));
						}
						*/

					}
				}

				/////

				scoreText.text = " Score:" + scoreNumber;
				scoreNumber += 1;
			} 
			else 
			{
			//	Death ();
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.CompareTag("BlueEnemy"))
			{
				Death ();
			}

		if(other.CompareTag("BlueEnemy"))
			{
				
			}
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