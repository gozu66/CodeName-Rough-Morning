using UnityEngine;
using System.Collections;

public class SmartPipes : MonoBehaviour 
{
	GameObject[] endSnapPoint;
	GameObject localSnapPoint, CurrEndSnap, myChild;
	SmartPipes myParent;
	Transform myT;
	ParticleSystem _steam;
	float i = Mathf.Infinity;
	float rotOffset;
	public bool inSitute, isOccupied;

	public float MinSnapDistance = 0.2f, MinRotDistance = 5f;


	void Start()
	{
		myT = transform;

		Transform[] children = GetComponentsInChildren<Transform>();
		foreach(Transform child in children)
		{
			if(child.tag == "SP"){
				localSnapPoint = child.gameObject;
			}
			else if(child.tag == "endSnapPoint"){
				endSnapPoint = GameObject.FindGameObjectsWithTag("endSnapPoint");
			}
			else if(child.tag == "Steam"){
				_steam = child.gameObject.GetComponent<ParticleSystem>();
			}
		}
	}

	void Update()
	{
		if(inSitute && !isOccupied && _steam.emissionRate < 50){
			_steam.emissionRate = 100;
		}	else {
			_steam.emissionRate = 0;
		}
	}

	void SnapPipe()
	{	
//		inSitute = !inSitute;0

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
			myParent = CurrEndSnap.transform.parent.GetComponent<SmartPipes>();
			if(!myParent.isOccupied)
			{
				myParent.SetChild(gameObject);
				myParent.Occupy(true);

				rigidbody2D.isKinematic = true;
				gameObject.layer = 10;

				myT.position += AdjustPosition();

				Vector3 vec = transform.eulerAngles;
				vec.z = Mathf.Round(vec.z / 90) * 90;
				transform.eulerAngles = vec;

				myT.position += AdjustPosition();


				myParent.SteamSwitch();
				SteamSwitch();
				inSitute = true;
			}else{
				myParent = null;
			}
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

	public void Drop(bool occupied)
	{
		inSitute = false;
		if(myParent != null){
			myParent.Occupy(false);
		}
		if(myChild != null){
			myChild.gameObject.layer = 11;	
			myChild.rigidbody2D.isKinematic = false;
			SmartPipes myChildPipes = myChild.GetComponent<SmartPipes>();
			if(myChildPipes != null)myChildPipes.Drop(true);
		}
	}

	public void SteamSwitch()
	{
		float emission = _steam.emissionRate;
		_steam.emissionRate = (emission >= 50) ? 0 : 100;

		BoxCollider2D[] myBox = GetComponentsInChildren<BoxCollider2D>();
		foreach(BoxCollider2D box in myBox)
		{
			if(box.tag == "playerHazard"){
				box.enabled = !box.enabled;
				break;
			}
		}
	}
	public void Occupy(bool _occupy)
	{
		isOccupied = _occupy;
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
}
