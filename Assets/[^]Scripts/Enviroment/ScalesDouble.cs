using UnityEngine;
using System.Collections;

public class ScalesDouble : MonoBehaviour 
{
	public float maxWeight = 1;
	public GameObject weight1, weight2;
	public GameObject minHeightObj, maxHeightObj;
	public float currWeight1, currWeight2;
	float normalHeight1, normalHeight2;
	float targetHeight1, targetHeight2;
	float maxHeight, minHeight;
	float normalWeight1, normalWeight2;
	float refFloat = 0.0f;

	void Start()
	{
		minHeight = minHeightObj.transform.position.y;
		maxHeight = maxHeightObj.transform.position.y;

		InvokeRepeating("CheckScales", 0.1f, 0.25f);	
	}

	void FixedUpdate()
	{
		float smoothMove1 = Mathf.SmoothDamp(weight1.transform.position.y, targetHeight1, ref refFloat, 1.0f);
		weight1.rigidbody2D.MovePosition(new Vector2(weight1.transform.position.x, smoothMove1));
		
		targetHeight1 = Mathf.Clamp(targetHeight1, minHeight, maxHeight);

		float smoothMove2 = Mathf.SmoothDamp(weight2.transform.position.y, targetHeight2, ref refFloat, 1.0f);
		weight2.rigidbody2D.MovePosition(new Vector2(weight2.transform.position.x, smoothMove2));
		
		targetHeight2 = Mathf.Clamp(targetHeight2, minHeight, maxHeight);
	}

	void CheckScales()
	{
		Collider2D[] weights1 = new Collider2D[10];
		Physics2D.OverlapAreaNonAlloc(weight1.collider2D.bounds.max, weight1.collider2D.bounds.min, weights1);
		currWeight1 = 0;

		foreach(Collider2D col in weights1)
		{
			if(col != null)
			{
				if(col.GetComponent<Weight>() != null && GameObject.FindObjectOfType<Telekinesis>().heldObj != col.gameObject)
				{
					currWeight1 = col.GetComponent<Weight>().weight;
				}
			}
		}

		Collider2D[] weights2 = new Collider2D[10];
		Physics2D.OverlapAreaNonAlloc(weight2.collider2D.bounds.max, weight2.collider2D.bounds.min, weights2);
		currWeight2 = 0;

		foreach(Collider2D col in weights2)
		{
			if(col != null)
			{
				if(col.GetComponent<Weight>() != null && GameObject.FindObjectOfType<Telekinesis>().heldObj != col.gameObject)
				{
					currWeight2 = col.GetComponent<Weight>().weight;
				}
			}
		}

		currWeight1 -= currWeight2;
		currWeight2 -= currWeight1;

		normalHeight1 = currWeight1/maxWeight;
		normalWeight1 = 1 - normalWeight1;
		targetHeight1 = minHeight + (normalWeight1 * (maxHeight - minHeight));

		normalHeight2 = currWeight2/maxWeight;
		normalHeight2 = 1 - normalWeight2;
		targetHeight2 = minHeight + (normalWeight2 * (maxHeight - minHeight));

		targetHeight1 = (currWeight1 >= 0) ? targetHeight1 : 1 - targetHeight1;
		targetHeight2 = (currWeight2 >= 0) ? targetHeight2 : 1 - targetHeight2;
	}
}
