using UnityEngine;
using System.Collections;

public class TelekinesisPing : MonoBehaviour 
{
	CircleCollider2D myCol;
	public float speed;

	void Start()
	{
		myCol = GetComponent<CircleCollider2D>();
	}
	void Update()
	{
		myCol.radius += speed * Time.deltaTime;

		if(myCol.radius >= 20)
			Reset();

	}
	void Reset()
	{
		myCol.radius = 0.1f;
		this.gameObject.SetActive(false);
	}
}