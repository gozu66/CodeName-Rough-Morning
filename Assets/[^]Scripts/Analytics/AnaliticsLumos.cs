using UnityEngine;
using System.Collections;

public class AnaliticsLumos : MonoBehaviour 
{
	float timer;
	int i;
	int deaths;

	void Start()
	{
		timer = 0;
		i = 1;
		deaths = 0;
	}

	void Update()
	{
		timer += Time.deltaTime;
	}

//	void OnTriggerEnter2D(Collider2D other)
//	{
//		Debug.Log("hit");
//
//		if(other.tag == "checkPoint")
//		{
//			CheckPointHit();
//			Debug.Log("hitCP");
//		}
//	}

	void CheckPointHit()
	{
		if(i <= 7)
		{
			LumosAnalytics.RecordEvent("TestLevel", "CheckPoint " + i.ToString("0"), timer);
			i++;
		}
		else{
			LumosAnalytics.RecordEvent("TestLevel", "Finishing Time ", timer);
		}
	}

	void CheckPointDeath()
	{
		deaths++;

		LumosAnalytics.RecordEvent("TestLevel", "Deaths at CheckPoint " + i.ToString("0"), deaths);
	}
}