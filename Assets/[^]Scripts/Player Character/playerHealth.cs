using UnityEngine;
using System.Collections;

public class playerHealth : MonoBehaviour 
{
	public Transform startPoint;
	public float playerHP;

	void Start()
	{
		playerHP = 100;
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.tag == "playerHazard")
		{
			transform.position = startPoint.position;
		}
	}
}
