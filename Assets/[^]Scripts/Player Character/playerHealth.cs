using UnityEngine;
using System.Collections;

public class playerHealth : MonoBehaviour 
{
	Vector3 startPoint;
	public float playerHP, delay;
	public GameObject playerSprite;

	GameObject weaponTransform;

	public Animator anim;

	void Start()
	{
		anim = GetComponentInChildren<Animator>();

		playerHP = 100;
		startPoint = transform.position;
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.tag == "checkPoint")
		{
			startPoint = col.transform.position;
			col.enabled = false;
			weaponTransform = GameObject.Find("weaponTrans");
		}
		if(col.tag == "playerHazard")
		{
			//StopAllCoroutines();
			StartCoroutine("RespawnPlayer");


			if(Telekinesis.isHolding)
				weaponTransform.SendMessage("dropObject", gameObject.transform , SendMessageOptions.DontRequireReceiver);


		}
	}

	IEnumerator RespawnPlayer()
	{
		//playerSprite.renderer.enabled = false;
		anim.SetTrigger("killed");
		//rigidbody2D.isKinematic = true;
		yield return new WaitForSeconds(delay);
		playerSprite.renderer.enabled = false;
		transform.position = startPoint;
		//rigidbody2D.isKinematic = false;
		yield return new WaitForSeconds(0.2f);
		playerSprite.renderer.enabled = true;
//		this.gameObject.SetActive(false);
//		yield return new WaitForSeconds(delay);
//		this.gameObject.SetActive(true);
	}

}
