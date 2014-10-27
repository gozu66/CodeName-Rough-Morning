using UnityEngine;
using System.Collections;

public class plasmaGrenade : MonoBehaviour 
{
	public GameObject ptl;
	public float timer;

	IEnumerator Start()
	{
		CircleCollider2D col = this.GetComponent<CircleCollider2D>();
		yield return new WaitForSeconds(timer);
		Instantiate(ptl, transform.position, transform.rotation);
		col.radius = 0;
		while(col.radius < 5)
		{
			col.radius += 1;
		}
		Destroy(gameObject);
	}
}