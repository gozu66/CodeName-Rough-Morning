using UnityEngine;
using System.Collections;

public class TelekinesisPtl : MonoBehaviour 
{
	void Update()
	{
		if(particleSystem.enableEmission)
		{
			particleSystem.startRotation = -transform.rotation.z;
		}
	}
}
