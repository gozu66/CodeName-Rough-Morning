using UnityEngine;
using System.Collections;

public class SmartPipes : MonoBehaviour 
{
	GameObject[] endSnapPoint;
	GameObject localSnapPoint, CurrEndSnap;

	Transform myT;

	float i = Mathf.Infinity;
	float rotOffset;

	public float MinSnapDistance = 0.2f, MinRotDistance = 5f;

	void Start()
	{
		myT = transform;
		endSnapPoint = GameObject.FindGameObjectsWithTag("endSnapPoint");

		localSnapPoint = myT.GetChild(0).gameObject;
		if(localSnapPoint.tag == "endSnapPoint")
			localSnapPoint = myT.GetChild(1).gameObject;
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

			myT.position += AdjustPosition();
			myT.parent = CurrEndSnap.transform.parent;
		}
	}

	bool Compare()
	{
		float dist = Vector2.Distance(localSnapPoint.transform.position, CurrEndSnap.transform.position);

		if(dist <= MinSnapDistance)
		{
			rotOffset = Quaternion.Angle(CurrEndSnap.transform.rotation, localSnapPoint.transform.rotation);

			if(rotOffset < MinRotDistance)	{
				return true;
			}	else {
				return false;
			}
		}	else {
			return false;
		}
	}

	Vector3 AdjustPosition()
	{
		float x = CurrEndSnap.transform.position.x - localSnapPoint.transform.position.x;
		float y = CurrEndSnap.transform.position.y - localSnapPoint.transform.position.y;

		Vector3 offset = new Vector3(x, y, 0);
		return offset;
	}

}
