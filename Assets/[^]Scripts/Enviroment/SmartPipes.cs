using UnityEngine;
using System.Collections;

public class SmartPipes : MonoBehaviour 
{
	GameObject[] SnapPoints;
	Transform myT;

	public float MinSnapDistance = 0.2f, MinRotDistance = 5f;

	void Start()
	{
		myT = transform;
		SnapPoints = GameObject.FindGameObjectsWithTag("SP");
	}

	void SnapPipe()
	{

	}

	Vector3 CompareDist(GameObject x, Transform y)
	{
		return Vector3.zero;
	}
}
