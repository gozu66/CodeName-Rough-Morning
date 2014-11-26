using UnityEngine;
using System.Collections;

public class AnaliticsLumos : MonoBehaviour 
{
	float timer;
	int i;

	void Start()
	{
		timer = 0;
		i = 1;
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
			LumosAnalytics.RecordEvent("TestLevel", "Finish Time ", timer);
		}
	}
}