using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {

	public GameObject BlueEnemy;
	public GameObject PowerUp;
	public bool start = false;
	int count;
	int collect;

	// Use this for initialization
	void Start () 
	{
		count = 60;
		collect = 30;
	}

	// Update is called once per frame
	void FixedUpdate () 
	{
		/*
		if (start == true) 
		{
			if (count == 60) 
			{
				Instantiate(BlueEnemy, new Vector3(Random.Range(-2.4f,2.4f), 7f, 0f), Quaternion.identity);
				count = 0;
			}
			if (collect == 30)
			{
				Instantiate (PowerUp, new Vector3 (Random.Range (-2.4f, 2.4f), 7f, 0f), Quaternion.identity);
				collect = 0;
			}
			count += 1;
			collect += 1;
		}
		*/
	}
}
