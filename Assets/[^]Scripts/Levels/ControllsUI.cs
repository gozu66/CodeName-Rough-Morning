using UnityEngine;
using System.Collections;

public class ControllsUI : MonoBehaviour 
{
	public GameObject Pad;
	public GameObject MKB;

	void Start()
	{
		Debug.Log("STUFF");

		if(playerAim._input == playerAim.InputType.MouseKBoard)
		{
			Pad.SetActive(false);
			MKB.SetActive(true);
		}
		else{
			MKB.SetActive(true);
			Pad.SetActive(false);
		}
	}
}