using UnityEngine;
using System.Collections;

public class repsawnOnDropped : MonoBehaviour 
{
	GameObject weaponTransform;
	Vector3 spawnPosition;
	public bool isReady = false;

	void Start()
	{
		spawnPosition = transform.position;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "boundingBox")
			respawn();
	}

	public void respawn()
	{

		rigidbody2D.velocity = new Vector2(0, 0);
		rigidbody2D.angularVelocity = 0;
		transform.position = spawnPosition;
		//weaponTransform = GameObject.Find("weaponTrans");
		//weaponTransform.SendMessage("dropObject", gameObject.transform , SendMessageOptions.DontRequireReceiver);
	}	
}