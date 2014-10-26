using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour 
{
	public float dampTime = 0.15f;
	public Transform Target;
	public float distance, maxDistance;
	Vector3 refV3 = Vector3.zero;

	void Update()
	{
		if(Camera.main.isOrthoGraphic)
			camera.orthographicSize = distance;

		Vector3 camTarget = new Vector3(Target.position.x, Target.position.y, Target.position.z - distance);
		transform.position = Vector3.SmoothDamp(transform.position, camTarget, ref refV3, dampTime);

		if(Input.GetButton("Back_1") && distance < maxDistance)
		{
			distance = Mathf.Lerp(distance, maxDistance, dampTime);
		}
		else if(distance >= maxDistance-1)
		{
			distance = Mathf.Lerp(13, maxDistance, dampTime);
		}
	}
}
