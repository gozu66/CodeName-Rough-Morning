using UnityEngine;
using System.Collections;

public class LevelEnterExit : MonoBehaviour 
{
	public int _loadLevel;
	bool playerIn;

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Player")
			playerIn = true;
	}
	void OnTriggerExit2D(Collider2D other)
	{
		if(other.tag == "Player")
			playerIn = false;
	}

	void Update()
	{
		if(playerIn)
		{
			if(Input.GetKeyDown(KeyCode.S) || Input.GetAxisRaw("DPad_YAxis_1") < 0)
			{
				Application.LoadLevel(_loadLevel);
			}
		}
	}
}