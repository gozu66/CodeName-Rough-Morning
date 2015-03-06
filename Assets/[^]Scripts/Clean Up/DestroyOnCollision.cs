using UnityEngine;
using System.Collections;

public class DestroyOnCollision : MonoBehaviour
{
	public float maxCollisionMagnitude;

	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.relativeVelocity.magnitude > maxCollisionMagnitude)
			rigidbody2D.velocity = Vector3.zero;
	}
}