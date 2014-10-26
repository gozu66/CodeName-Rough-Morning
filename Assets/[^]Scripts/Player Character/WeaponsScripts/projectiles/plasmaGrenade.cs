using UnityEngine;
using System.Collections;

public class plasmaGrenade : MonoBehaviour 
{
	public GameObject ptl;
	public float timer;

	IEnumerator Start()
	{
		yield return new WaitForSeconds(timer);
		Instantiate(ptl, transform.position, transform.rotation);
		Destroy(gameObject);
	}
}