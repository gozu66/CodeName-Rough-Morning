using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour
{
	public enum InputType {XboxPad, MouseKBoard};
	public static InputType _input;

//	public GameObject MouseKB, XBOX, canvas, exitButton;

	void Start()
	{
//		Debug.Log(PlayerPrefs.GetString("CurrentInput"));
//		PlayerPrefs.DeleteAll();
//		string ppinput = PlayerPrefs.GetString("CurrentInput");
//		
//		if(ppinput == "Xbox Controller") 
//		{
//			_input = InputType.XboxPad;
//			MouseKB.SetActive(false);
//		}
//
//		else if(ppinput == "Mouse Keyboard") 
//		{
//			_input = InputType.MouseKBoard;
//			XBOX.SetActive(false);
//		}
//
//		else
//		{

		Debug.Log(Input.GetJoystickNames().Length);

			if(Input.GetJoystickNames().Length > 0)			//Input detection if player input null
			{
				_input = InputType.XboxPad;
				Debug.Log("xbox");
			}
			else
			{
				_input = InputType.MouseKBoard;
				Debug.Log("KMB");
			}

//			if(_input == UIManager.InputType.XboxPad)
//			{
//				MouseKB.SetActive(false);
//				PlayerPrefs.SetString("CurrentInput", "Xbox Controller");
//			}
//
//			if(_input == UIManager.InputType.MouseKBoard)
//			{
//				XBOX.SetActive(false);
//				PlayerPrefs.SetString("CurrentInput", "Mouse Keyboard");
//			}
//		}
	}

//	void XboxPad()
//	{
//		Screen.showCursor = false;
//		Time.timeScale = 1;
//		_input = InputType.XboxPad;
//		MouseKB.SetActive(false);
//		canvas.SetActive(false);
//	}
//	void MKB()
//	{
//		Screen.showCursor = false;
//		Time.timeScale = 1;
//		_input = InputType.MouseKBoard;
//		XBOX.SetActive(false);
//		canvas.SetActive(false);
//	}

}