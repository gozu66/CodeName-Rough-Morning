using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour
{
	public enum InputType {XboxPad, MouseKBoard};
	public static InputType _input;

	public GameObject MouseKB, XBOX, canvas;

	void Start()
	{
//		yield return new WaitForSeconds(0.25F);

//		Time.timeScale = 0;

		if(Input.GetJoystickNames().Length > 0)
		{
			_input = InputType.XboxPad;
		}
		else{
			_input = InputType.MouseKBoard;
		}

		if(_input == UIManager.InputType.XboxPad)
		{
			MouseKB.SetActive(false);
			PlayerPrefs.SetString("CurrentInput", "Xbox Controller");
		}
		if(_input == UIManager.InputType.MouseKBoard)
		{
			XBOX.SetActive(false);
			PlayerPrefs.SetString("CurrentInput", "Mouse Keyboard");
		}


	}

	void XboxPad()
	{
		Screen.showCursor = false;
		Time.timeScale = 1;
		_input = InputType.XboxPad;
		MouseKB.SetActive(false);
		canvas.SetActive(false);
	}
	void MKB()
	{
		Screen.showCursor = false;
		Time.timeScale = 1;
		_input = InputType.MouseKBoard;
		XBOX.SetActive(false);
		canvas.SetActive(false);
	}

}