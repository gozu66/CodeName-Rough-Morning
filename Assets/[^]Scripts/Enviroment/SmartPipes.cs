using UnityEngine;
using System.Collections;

public class SmartPipes : MonoBehaviour 
{
	GameObject[] endSnapPoint;
	GameObject localSnapPoint, CurrEndSnap, myParent, myChild;
	Transform myT;
	float i = Mathf.Infinity;
	float rotOffset;

	public float MinSnapDistance = 0.2f, MinRotDistance = 5f;
//	public GameObject steam;

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
			if(point != null){
				float dist = Vector2.Distance(localSnapPoint.transform.position, point.transform.position);
				if(dist < i)
				{
					i = dist;
					CurrEndSnap = point;
				}
			}
		}
		if(Compare() == true)
		{
			rigidbody2D.isKinematic = true;
			gameObject.layer = 10;

			myT.position += AdjustPosition();

			Vector3 vec = transform.eulerAngles;
			vec.z = Mathf.Round(vec.z / 90) * 90;
			transform.eulerAngles = vec;

			myT.position += AdjustPosition();

			GameObject newParent = CurrEndSnap.transform.parent.gameObject;
			myParent = newParent;
			if(newParent.GetComponent<SmartPipes>() != null)
				newParent.GetComponent<SmartPipes>().SetChild(gameObject);

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

	public void SetChild(GameObject _child)
	{
		myChild = _child;
	}

	public void Drop()
	{
		if(myChild != null){
			myChild.gameObject.layer = 11;	
			myChild.rigidbody2D.isKinematic = false;
			SmartPipes myChildPipes = myChild.GetComponent<SmartPipes>();
			if(myChildPipes != null)myChildPipes.Drop();
		}
	}

	[ContextMenu("Align pipe values")]
	public void SetValues()
	{
		SmartPipes[] currentPipes = GameObject.FindObjectsOfType<SmartPipes>();
		foreach(SmartPipes pipe in currentPipes)
		{
			pipe.GetComponent<SmartPipes>().MinSnapDistance = MinSnapDistance;
			pipe.GetComponent<SmartPipes>().MinRotDistance = MinRotDistance;
		}
	}

	public void SteamToggle()
	{

	}
}
