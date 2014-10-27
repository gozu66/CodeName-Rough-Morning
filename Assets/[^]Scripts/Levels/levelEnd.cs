using UnityEngine;
using System.Collections;

public class levelEnd : MonoBehaviour 
{
	public AudioClip winner;
	public GameObject winnerSprite;

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

		//AudioSource.PlayClipAtPoint(winner, transform.position);

		winnerSprite.SetActive(true);
		yield return new WaitForSeconds(2);
		Application.LoadLevel(0);


	}
	
}