using UnityEngine;
using System.Collections;

public class Enter_Exit_door : MonoBehaviour 
{
	public GameObject Player;
	public Transform destination;
	
	void OnTriggerStay2D(Collider2D other)
	{
		if(other.gameObject == Player)
		{
			if(Input.GetKeyDown(KeyCode.S))
			{
				Player.transform.position = destination.position;
			}
		}
	}
}
