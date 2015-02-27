using UnityEngine;
using System.Collections;

public class TelekinesisPtl : MonoBehaviour 
{
	Transform myP;
	ParticleSystem pSys;

	void Start()
	{
		myP = transform.parent;
		pSys = GetComponent<ParticleSystem>();
		InvokeRepeating("UpdateRot", 0.5f, 0.5f);
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.collider2D.gameObject.layer == 12){
			pSys.enableEmission = true;
			Invoke("StopPing", 0.5f);
		}
	}

	void UpdateRot()
	{
		pSys.startRotation = (360 - myP.eulerAngles.z) * Mathf.Deg2Rad;
	}

	void StopPing()
	{
		pSys.enableEmission = false;
	}
}
