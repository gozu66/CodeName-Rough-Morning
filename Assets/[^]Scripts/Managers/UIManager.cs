using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour
{
	public GameObject MouseKB, XBOX;

	void Start()
	{
		if(playerAim._input == playerAim.InputType.XboxPad)
		{
			MouseKB.SetActive(false);
			XBOX.SetActive(true);
		}
		if(playerAim._input == playerAim.InputType.MouseKBoard)
		{
			MouseKB.SetActive(false);
			XBOX.SetActive(true);
		}
	}

}