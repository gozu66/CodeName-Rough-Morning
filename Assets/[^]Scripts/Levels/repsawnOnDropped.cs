using UnityEngine;
using System.Collections;

public class repsawnOnDropped : MonoBehaviour 
{
	GameObject weaponTransform;
	Vector3 spawnPosition;
	public bool isReady, isInvisible;

	void Start()
	{
		spawnPosition = transform.position;
		isReady = false;
		isInvisible = true;
	}

	void Update()
	{
		if(isReady && isInvisible){
			respawn();
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "boundingBox")
			isReady = true;
	}

	void OnBecameInvisible()
	{
		isInvisible = true;
	}

	void OnBecameVisible()
	{
		isInvisible = false;
	}

	public void respawn()
	{
		isReady = false;
		rigidbody2D.velocity = new Vector2(0, 0);
		rigidbody2D.angularVelocity = 0;
		transform.position = spawnPosition;
		//weaponTransform = GameObject.Find("weaponTrans");
		//weaponTransform.SendMessage("dropObject", gameObject.transform , SendMessageOptions.DontRequireReceiver);
	}	
}