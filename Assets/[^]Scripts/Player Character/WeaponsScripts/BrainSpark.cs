using UnityEngine;
using System.Collections;

public class BrainSpark : MonoBehaviour 
{
	public Rigidbody2D spark;
	public static bool isFired = false;
	public float maxChargeTimer, speed;
	TrailRenderer sparkTrail;
	float chargeTimer;
	Transform sparkT, myT;
	bool tempIsFired;

	void Start()
	{
		myT = transform;
		sparkT = spark.transform;
		sparkTrail = spark.gameObject.GetComponent<TrailRenderer>();
		sparkTrail.enabled = false;
		spark.isKinematic = true;
	}

	void Update()
	{
		tempIsFired = isFired;

		if(!isFired){	
			if(Input.GetMouseButtonDown(0)){
				StartCoroutine("Charge");
			}
			else if(Input.GetMouseButtonUp(0)){
				StopAllCoroutines();
			}
		}
	}


	IEnumerator Charge()
	{
		chargeTimer = 0;

		while(chargeTimer < maxChargeTimer){
			chargeTimer += Time.deltaTime;
			yield return null;
		}

		isFired = true;
		sparkT.position = myT.position;
		spark.isKinematic = false;
		spark.AddForce((transform.right * myT.localScale.x)*speed, ForceMode2D.Impulse);
		sparkTrail.enabled = true;
		chargeTimer = 0;

		yield return null;
	}
}