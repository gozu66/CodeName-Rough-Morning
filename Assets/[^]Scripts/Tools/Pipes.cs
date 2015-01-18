using UnityEngine;
using System.Collections;

public class Pipes : MonoBehaviour 
{
	Transform myT;
	Vector3 Snap;	
	Quaternion RSnap;
	Rigidbody Rbody;

	void Start()
	{
		Debug.Log(Snap);

		myT = transform;
		Rbody = GetComponent<Rigidbody>();
	}

	public void SnapPipe()
	{
		Rbody.isKinematic = true;
	}

	[ContextMenu("Set Up Pipes")]
	void SetUpPipes()
	{
		Snap = transform.position;
		RSnap = transform.rotation;
	}
}