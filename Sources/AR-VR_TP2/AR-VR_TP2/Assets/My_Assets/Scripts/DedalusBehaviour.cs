using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DedalusBehaviour : MonoBehaviour
{
	void Start()
	{
		GameObject.Find("EndScreen").gameObject.SetActive(false);
	}

	public void endGame()
	{
		Application.Quit();
	}
	public void restart()
	{
		Time.timeScale = 1;
		SceneManager.LoadScene("Accueil");
	}
}
