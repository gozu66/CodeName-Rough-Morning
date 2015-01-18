using UnityEngine;
using System.Collections;

public class Pipes : MonoBehaviour 
{
	public Vector3 Snap;	
	public Quaternion RSnap;
	public GameObject Steam;
	public bool isFinal;

	public float MinSanpDistance = 0.2f, MinRotDistance = 5f;

	Transform myT;
	Rigidbody2D Rbody;
	
	void Start()
	{
//		SnapPoints = GetComponentsInChildren<Transform>();
		myT = transform;
	}

	public void SnapPipe()
	{
		if(DistCheck() < MinSanpDistance && RotationCheck() < MinRotDistance)
		{
			rigidbody2D.isKinematic = true;
			collider2D.enabled = false;
			myT.position = Snap;
			myT.rotation = RSnap;
			Steam.SetActive(!isFinal);
		}
	}

		float DistCheck()
		{
			Vector2 Dist = new Vector2(Snap.x - myT.position.x, Snap.y - myT.position.y);
			return Dist.magnitude;
		}

			float RotationCheck()
			{
				float angle = Quaternion.Angle(myT.rotation, RSnap);
				return angle;
			}

	[ContextMenu("Set Up Pipes")]
	void SetUpPipes()
	{
		Snap = transform.position;
		RSnap = transform.rotation;
	}
}