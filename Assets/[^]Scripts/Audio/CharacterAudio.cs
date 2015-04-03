using UnityEngine;
using System.Collections;

public class CharacterAudio : MonoBehaviour 
{
	public AudioClip[] _footsteps;
	public int lastClip = 0;

	public void FootStep()
	{
		int i = Random.Range(0,3);
		if(i == lastClip){i += 1;}
		if(i > 3){i = 0;}
		AudioSource.PlayClipAtPoint(_footsteps[i], transform.position);
		lastClip = i;
	}

	public AudioClip[] grunts;
	public int lastClipGrunt = 0; 

	public void Grunt()
	{
		int i = Random.Range(0,3);
		if(i == lastClipGrunt){i += 1;}
		if(i > 2){i = 0;}
		AudioSource.PlayClipAtPoint(grunts[i], transform.position);
		lastClipGrunt = i;
	}

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space) && groundCheck.isGrounded){
			Grunt();
		}
	}
}
