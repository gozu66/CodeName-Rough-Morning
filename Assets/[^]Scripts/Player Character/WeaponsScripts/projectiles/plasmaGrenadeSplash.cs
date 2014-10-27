using UnityEngine;
using System.Collections;

public class plasmaGrenadeSplash : MonoBehaviour {

	void Start()
	{
		CircleCollider2D col = this.GetComponent<CircleCollider2D>();
		col.radius = 0;

		while(col.radius < 5)
		{
			col.radius += 0.001f * Time.deltaTime;
		}

		//StartCoroutine("grow");
	}

	//IEnumerator grow()
	//{
		//yield return new WaitForSeconds(0);
		//CircleCollider2D col = this.GetComponent<CircleCollider2D>();
		//col.radius = 0;
		//Destroy(gameObject);
	//}
}
