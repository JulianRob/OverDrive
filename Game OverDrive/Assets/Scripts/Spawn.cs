using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {

	public GameObject BlueEnemy;
	public bool start = false;
	int count;

	// Use this for initialization
	void Start () 
	{
		count = 60;
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if (start == true) 
		{
			if (count == 60) 
			{
				Instantiate(BlueEnemy, new Vector3(Random.Range(-2.4f,2.4f), 7f, 0f), Quaternion.identity);
				count = 0;
			}
			count += 1;
		}
	}
}
