using UnityEngine;
using System.Collections;

public class SmartPipes : MonoBehaviour 
{
	GameObject[] endSnapPoint;
	GameObject localSnapPoint, CurrEndSnap;

	Transform myT;

	float i = Mathf.Infinity;

	public float MinSnapDistance = 0.2f, MinRotDistance = 5f;

	void Start()
	{
		myT = transform;
		endSnapPoint = GameObject.FindGameObjectsWithTag("endSnapPoint");

		localSnapPoint = this.transform.GetChild(0).gameObject;
		if(localSnapPoint.tag == "endSnapPoint")
			localSnapPoint = this.transform.GetChild(1).gameObject;
	}

	void SnapPipe()
	{
		foreach(GameObject point in endSnapPoint)
		{
			float dist = Vector2.Distance(localSnapPoint.transform.position, point.transform.position);
			if(dist < i)
			{
				i = dist;
				CurrEndSnap = point;
			}
		}
		if(Compare() == true)
		{
			rigidbody2D.isKinematic = true;
			collider2D.isTrigger = true;
		}
	}

	bool Compare()
	{
		float dist = Vector2.Distance(localSnapPoint.transform.position, CurrEndSnap.transform.position);
		if(dist <= MinSnapDistance)
		{
			float rotOffset = Quaternion.Angle(CurrEndSnap.transform.rotation, localSnapPoint.transform.rotation);
			Debug.Log(rotOffset);

			if(rotOffset < MinRotDistance)
			{
				return true;
			}else
			{
				return false;
			}
		}else{
		return false;
		}
	}
}
