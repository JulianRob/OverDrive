using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour {

	public void NextLevelButton(string index)
	{
		SceneManager.LoadScene (index);
	}

	public void Restart(string index)
	{
		SceneManager.LoadScene (index);
	}

	public void MainMenu(string index)
	{
		SceneManager.LoadScene (index);
	}
}
