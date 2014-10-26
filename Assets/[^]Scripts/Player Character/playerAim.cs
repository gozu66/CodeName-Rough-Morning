using UnityEngine;
using System.Collections;

public class playerAim : MonoBehaviour 
{
	public Transform reticule;
	public float range;

	void Update () 
	{
		/*	Vector3 mouse_pos = Input.mousePosition;
		Vector3 player_pos = Camera.main.WorldToScreenPoint(this.transform.position);
		
		mouse_pos.x = mouse_pos.x - player_pos.x;
		mouse_pos.y = mouse_pos.y - player_pos.y;

		float angle = Mathf.Atan2 (mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;
		this.transform.rotation = Quaternion.Euler (new Vector3(0, 0, angle));			*/	//working mouse aiming

		if(!gravityGun.isHolding)
		{
			float angle = Mathf.Atan2 (-Input.GetAxis("R_YAxis_1")*0.5f, transform.localPosition.x) * Mathf.Rad2Deg;
			this.transform.rotation = Quaternion.Euler (new Vector3(0, 0, angle));								
		}

	}
}
