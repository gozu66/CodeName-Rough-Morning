using UnityEngine;
using System.Collections;

public class audioTimeSync : MonoBehaviour 
{
	void Update()
	{
		if(timeGun.timeStopped)
		{
			if(audio.pitch > Time.timeScale)
			{
				audio.pitch -= 0.2f * Time.deltaTime/Time.timeScale;
			}
		}	
			else
		{
			if(audio.pitch < Time.timeScale)
			{
				audio.pitch += 0.4f * Time.deltaTime/Time.timeScale;
			}
		}
	}
}