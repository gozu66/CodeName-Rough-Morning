using UnityEngine;
using System.Collections;

public class TelekinesisPtl : MonoBehaviour 
{
	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.collider2D.gameObject.layer == 12){
			particleSystem.enableEmission = true;
			Invoke("StopPing", 0.5f);
		}
	}

	void StopPing()
	{
		particleSystem.enableEmission = false;
	}
}
