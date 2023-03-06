using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{

	public void PlayGame()
	{
		SceneManager.LoadScene(1);
	}

	public void Exit()
	{
		Application.Quit();
		Debug.Log("QUIT");
	}
}
