using UnityEngine;
using System.Collections;

public class BrainSpark : MonoBehaviour 
{
	public static bool isFired = false;
	public Rigidbody2D spark;
	public float maxChargeTimer, speed;
	GameObject sparkGO;
	TrailRenderer myTrail;
	Transform myT, sparkT;
	bool isPrimed;
	float chargeTimer;

	void Start()
	{
		myT = transform;
		sparkT = spark.transform;
		sparkGO = sparkT.gameObject;
		myTrail = sparkGO.GetComponent<TrailRenderer>();
		myTrail.time = 0;
		sparkGO.SetActive(false);
	}

	void Update()
	{
		if(!isFired){
			if(Input.GetMouseButton(0)){
				chargeTimer += Time.deltaTime;
			}

			if(chargeTimer >= maxChargeTimer){
				isPrimed = true;
			}else{
				isPrimed = false;
			}

			if(Input.GetMouseButtonUp(0)){
				chargeTimer = 0;
				if(isPrimed){
					sparkT = spark.transform;
					sparkGO = sparkT.gameObject;
					sparkGO.SetActive(false);
					Fire();
				}
			}
		}
	}

	void Fire()
	{
//		float trailTime = myTrail.time; myTrail.time = 0;
		sparkT.position = myT.position;
		spark.isKinematic = false;
		myTrail.time = 3; 
		Vector2 shootVector = new Vector2(transform.right.x * transform.parent.localScale.x, transform.right.y);
		sparkGO.SetActive(true);
		spark.AddForce(shootVector*speed, ForceMode2D.Impulse);
	}
}