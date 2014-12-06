using UnityEngine;
using System.Collections;

public class playerHealth : MonoBehaviour 
{
	Vector3 startPoint;
	public float playerHP;

	public GameObject anaNode;

	GameObject weaponTransform;

	void Start()
	{
		playerHP = 100;
		startPoint = transform.position;
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.tag == "checkPoint")
		{
			startPoint = col.transform.position;
			col.enabled = false;
			//anaNode.SendMessage("AddCheckpoint", SendMessageOptions.DontRequireReceiver);
//			transform.GetChild(5).SendMessage("CheckPointHit", col.gameObject.name, SendMessageOptions.DontRequireReceiver);
		}
		if(col.tag == "playerHazard")
		{
			transform.position = startPoint;
			//anaNode.SendMessage("AddDeath", SendMessageOptions.DontRequireReceiver);
			weaponTransform = GameObject.Find("weaponTrans");
			SendMessageUpwards("CheckPointDeath", SendMessageOptions.DontRequireReceiver);

			if(gravityGun.isHolding)
				weaponTransform.SendMessage("dropObject", gameObject.transform , SendMessageOptions.DontRequireReceiver);
		}
	}
}
