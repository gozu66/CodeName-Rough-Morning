using UnityEngine;
using System.Collections;

public class ScalesDouble : MonoBehaviour 
{
	public float moveSpeed = 0.5f;
	public GameObject weight1, weight2;

	public GameObject minHeightObj, maxHeightObj;
	float maxHeight, minHeight;

	float currWeight1, currWeight2, currFullWeight;

//	float normalHeight1, normalHeight2;
	float targetHeight1, targetHeight2;
//	float normalWeight1, normalWeight2;

	float refFloat = 0.0f;

	void Start()
	{
		minHeight = minHeightObj.transform.position.y;
		maxHeight = maxHeightObj.transform.position.y;

		InvokeRepeating("CheckScales", 0.1f, 0.25f);	
	}

	void FixedUpdate()
	{
//		float smoothMove1 = Mathf.SmoothDamp(weight1.transform.position.y, targetHeight1, ref refFloat, 1.0f);
//		weight1.rigidbody2D.MovePosition(new Vector2(weight1.transform.position.x, smoothMove1));
//		
//		targetHeight1 = Mathf.Clamp(targetHeight1, minHeight, maxHeight);
//
//		float smoothMove2 = Mathf.SmoothDamp(weight2.transform.position.y, targetHeight2, ref refFloat, 1.0f);
//		weight2.rigidbody2D.MovePosition(new Vector2(weight2.transform.position.x, smoothMove2));
//		
//		targetHeight2 = Mathf.Clamp(targetHeight2, minHeight, maxHeight);

		targetHeight1 = Mathf.Clamp(targetHeight1, minHeight, maxHeight);
		targetHeight2 = Mathf.Clamp(targetHeight2, minHeight, maxHeight);

		float smoothMove1 = Mathf.Lerp(weight1.transform.position.y, targetHeight1, moveSpeed * Time.deltaTime);
		float smoothMove2 = Mathf.Lerp(weight2.transform.position.y, targetHeight2, moveSpeed * Time.deltaTime);

		weight1.rigidbody2D.MovePosition(new Vector2(weight1.transform.position.x, smoothMove1));
		weight2.rigidbody2D.MovePosition(new Vector2(weight2.transform.position.x, smoothMove2));
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
				if(col.gameObject.layer == 11 && GameObject.FindObjectOfType<Telekinesis>().heldObj != col.gameObject)
				{
					currWeight1 += col.GetComponent<Weight>().weight;
				}
				if(col.tag == "Player")
				{
//					currWeight1 += col.transform.GetComponent<Weight>().weight;
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
				if(col.gameObject.layer == 11 && GameObject.FindObjectOfType<Telekinesis>().heldObj != col.gameObject)
				{
					currWeight2 += col.GetComponent<Weight>().weight;
				}
				if(col.tag == "Player")
				{
//					currWeight2 += col.transform.GetComponent<Weight>().weight;
				}
			}
		}

		currFullWeight = 0;
		currFullWeight = currWeight1 + currWeight2;		//Set current weight of both scales combined

		if(currFullWeight > 0)
		{
			float newWeight1 = currWeight2 / currFullWeight;
			float newWeight2 = currWeight1 / currFullWeight;
			currWeight1 = newWeight1;
			currWeight2 = newWeight2;

			targetHeight1 = minHeight + (currWeight1 * (maxHeight - minHeight));
			targetHeight2 = minHeight + (currWeight2 * (maxHeight - minHeight));

		}else{
			targetHeight1 = minHeight + (0.5f * (maxHeight - minHeight));
			targetHeight2 = minHeight + (0.5f * (maxHeight - minHeight));
		}

	}
}
