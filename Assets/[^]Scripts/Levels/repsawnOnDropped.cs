using UnityEngine;
using System.Collections;

public class repsawnOnDropped : MonoBehaviour 
{
	GameObject weaponTransform;
	Vector3 spawnPosition;
	public static float timer = 0.5f;
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
			StartCoroutine("Respawn");
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "boundingBox")
			isReady = !isReady;
	}

	void OnBecameInvisible()
	{
		isInvisible = true;
	}

	void OnBecameVisible()
	{
		isInvisible = false;
	}

	IEnumerator Respawn()
	{
		yield return new WaitForSeconds(timer);
		if(isReady && isInvisible){
			isReady = false;
			rigidbody2D.velocity = new Vector2(0, 0);
			rigidbody2D.angularVelocity = 0;
			transform.position = spawnPosition;
			//weaponTransform = GameObject.Find("weaponTrans");
		//weaponTransform.SendMessage("dropObject", gameObject.transform , SendMessageOptions.DontRequireReceiver);
		}
	}	
}