using UnityEngine;
using System.Collections;

public class playerHealth : MonoBehaviour 
{
	Vector3 startPoint;
	public float playerHP, delay;
	public GameObject playerSprite;

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
		}
		if(col.tag == "playerHazard")
		{
			StopAllCoroutines();
			StartCoroutine("RespawnPlayer");

			weaponTransform = GameObject.Find("weaponTrans");
			if(Telekinesis.isHolding)
				weaponTransform.SendMessage("dropObject", gameObject.transform , SendMessageOptions.DontRequireReceiver);


		}
	}

	IEnumerator RespawnPlayer()
	{
		playerSprite.renderer.enabled = false;
		rigidbody2D.isKinematic = true;
		yield return new WaitForSeconds(delay);
		transform.position = startPoint;
		rigidbody2D.isKinematic = false;
		playerSprite.renderer.enabled = true;
//		this.gameObject.SetActive(false);
//		yield return new WaitForSeconds(delay);
//		this.gameObject.SetActive(true);
	}

}
