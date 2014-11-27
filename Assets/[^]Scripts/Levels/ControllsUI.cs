using UnityEngine;
using System.Collections;

public class ControllsUI : MonoBehaviour 
{
	public GameObject Pad;
	public GameObject MKB;

	void Start()
	{

		if(UIManager._input == UIManager.InputType.MouseKBoard)
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