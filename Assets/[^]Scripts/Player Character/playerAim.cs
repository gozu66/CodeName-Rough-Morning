using UnityEngine;
using System.Collections;

public class playerAim : MonoBehaviour 
{
	public enum InputType {XboxPad, MouseKBoard};
	public static InputType _input;

	public Transform reticule; 
	public float range;

	void Start()
	{
		if(Input.GetJoystickNames().Length > 0)
		{
			_input = InputType.XboxPad;
		}
		else{
			_input = InputType.MouseKBoard;
		}
	}

	void Update () 
	{
		switch(_input)
		{
			case InputType.XboxPad:
				if(!gravityGun.isHolding)
				{
					float angle2 = Mathf.Atan2 (-Input.GetAxis("R_YAxis_1")*0.5f, transform.localPosition.x) * Mathf.Rad2Deg;	//XBOX PAD 
					this.transform.rotation = Quaternion.Euler (new Vector3(0, 0, angle2));										//AIM
				}
			break;

			case InputType.MouseKBoard:

				Vector3 mouse_pos = Input.mousePosition;
				Vector3 player_pos = Camera.main.WorldToScreenPoint(this.transform.position);
				
				mouse_pos.x = mouse_pos.x - player_pos.x;																		//MOUSE AND
				mouse_pos.y = mouse_pos.y - player_pos.y;																		//KEYBOARD AIM

				float angle = Mathf.Atan2 (mouse_pos.y, mouse_pos.x * transform.parent.localScale.x) * Mathf.Rad2Deg;
				this.transform.rotation = Quaternion.Euler (new Vector3(0, 0, angle));				
			break;
		}

	}
}
