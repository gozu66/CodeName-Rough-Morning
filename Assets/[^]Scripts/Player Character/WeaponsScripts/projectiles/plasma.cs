using UnityEngine;
using System.Collections;

public class plasma : MonoBehaviour 
{
	public GameObject ptl;


	void OnCollisionEnter2D(Collision2D col)
	{
		//Instantiate(ptl, col.contacts[0].otherCollider.transform.position, transform.rotation);   //col.contacts[0].otherCollider  TOO EXPENSIVE??
		Instantiate(ptl, transform.position, transform.rotation);

		Destroy(gameObject);
	}

	void OnBecameInvisible()
	{
		Destroy(gameObject);
	}
}