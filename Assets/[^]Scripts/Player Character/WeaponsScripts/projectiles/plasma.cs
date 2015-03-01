using UnityEngine;
using System.Collections;

public class plasma : MonoBehaviour 
{
	public GameObject ptl;
	public bool ShakeOnIvisible;
	bool invisible;


	void OnCollisionEnter2D(Collision2D col)
	{
		//Instantiate(ptl, col.contacts[0].otherCollider.transform.position, transform.rotation);   //col.contacts[0].otherCollider  TOO EXPENSIVE??
		Instantiate(ptl, transform.position, transform.rotation);

		if(ShakeOnIvisible){
			CameraShake.instance.CamShake(0.2f,0.2f);
		}else{
			if(!invisible)
				CameraShake.instance.CamShake(0.2f,0.2f);
		}

		Destroy(gameObject);
	}

	void OnBecameInvisible()
	{
		invisible = true;
	}
}