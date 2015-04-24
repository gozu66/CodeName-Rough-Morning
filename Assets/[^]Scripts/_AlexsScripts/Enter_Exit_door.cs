using UnityEngine;
using System.Collections;

public class Enter_Exit_door : MonoBehaviour 
{
	public GameObject Player;
	public Transform destination;
	bool playerIn;
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject == Player)
		{
			playerIn = true;
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if(other.gameObject == Player)
		{
			playerIn = false;
		}
	}

	void Update()
	{
		if (playerIn) 
		{
			if(Input.GetKeyDown(KeyCode.S))
			{
				Player.transform.position = destination.position;
				Player.GetComponentInChildren<Telekinesis>().SendMessage("dropObject", gameObject.transform);
			}
		}
	}
}
