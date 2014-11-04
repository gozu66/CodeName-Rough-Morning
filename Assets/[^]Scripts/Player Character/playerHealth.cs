using UnityEngine;
using System.Collections;

public class playerHealth : MonoBehaviour 
{
	Vector3 startPoint;
	public float playerHP;

	void Start()
	{
		playerHP = 100;
		startPoint = transform.position;
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.tag == "checkPoint")
		{
			startPoint = col.transform.position;
			col.enabled = false;
		}
		if(col.tag == "playerHazard")
		{
			transform.position = startPoint;
		}
	}
}
