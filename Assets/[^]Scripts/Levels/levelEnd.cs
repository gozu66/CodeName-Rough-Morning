using UnityEngine;
using System.Collections;

public class levelEnd : MonoBehaviour 
{
	public AudioClip winner;
	public GameObject winnerSprite;

	public GameObject anaNode;		//ANALYTICS 


	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Player")
		{
			other.collider2D.enabled = false;
			StartCoroutine("endLevel");
		}
	}

	IEnumerator endLevel()
	{
		audio.Play();
		winnerSprite.SetActive(true);
		//AudioSource.PlayClipAtPoint(winner, transform.position);
		//anaNode.SendMessage("WeaponTimer", 3, SendMessageOptions.DontRequireReceiver); 
		yield return new WaitForSeconds(1.5f);
		anaNode.SendMessage("SendMail", 3, SendMessageOptions.DontRequireReceiver);		//ANALYTICS 
		anaNode.SendMessage("WriteTxt", 3, SendMessageOptions.DontRequireReceiver);		//ANALYTICS 
		Application.LoadLevel(0);


	}
	
}