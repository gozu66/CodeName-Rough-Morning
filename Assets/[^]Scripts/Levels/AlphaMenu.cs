using UnityEngine;
using System.Collections;

public class AlphaMenu : MonoBehaviour 
{
	public void ControllerSelect(int i)
	{
		PlayerPrefs.DeleteAll();

		string _input = (i == 0) ? "Mouse Keyboard" : "Xbox Controller";

		PlayerPrefs.SetString("CurrentInput", _input);

		Application.LoadLevel(1);
	}

	public void ExitGame()
	{
		Application.Quit();
	}

	public void GoToMenu()
	{
		Application.LoadLevel(0);
	}

	public void GoToCredits()
	{
		Application.LoadLevel(2);
	}
}