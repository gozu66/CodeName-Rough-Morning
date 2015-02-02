using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AnaliticsLumos : MonoBehaviour 
{
	float timer = 0.0f, currTime;
	int currCheckP, checkPdeath;
	float[] checkpoints = new float[8];
//	float[] checkpointdeaths = new float[8];
	string[] checkpointnames = {"CheckPoint 1", "CheckPoint 2", "CheckPoint 3", 
		"CheckPoint 4", "CheckPoint 5", "CheckPoint 6", "CheckPoint 7", "CheckPoint 8"};
	string _InputType;
	int buffer1,buffer2,buffer3;

	void Awake ()
	{
		Lumos.OnReady += OnLumosReady;
	}

	void Start()
	{
		currCheckP = 0; checkPdeath = 0;
		buffer1=0;
		buffer2=0;
		buffer3=0;
	}
	
	void OnLumosReady ()
	{
		LumosAnalytics.RecordEvent("Lumos-Initialized");
	}

	void Update()
	{
		timer += Time.deltaTime * Time.timeScale;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "checkPoint")
		{
			if(currCheckP >= 1)
			{
				checkpoints[currCheckP] = timer - currTime;
			}
			else{
				checkpoints[currCheckP] = timer;
			}
			currTime = timer;
			CheckPointDeathDataSend();
			//LumosAnalytics.RecordEvent(PlayerPrefs.GetString("CurrentInput"), checkpointnames[currCheckP], checkpoints[currCheckP]);
			PlayerPrefs.SetString(checkpointnames[currCheckP], checkpointnames[currCheckP]);
			PlayerPrefs.SetFloat(checkpointnames[currCheckP]+" Value", checkpoints[currCheckP]);
			currCheckP++;
			LumosDataCall();

		}else if(other.tag == "Finish")
		{
			LumosAnalytics.RecordEvent(PlayerPrefs.GetString("CurrentInput"), "Exit Time", timer);

			for(int i = 0; i < currCheckP; i++)
			{
				LumosAnalytics.RecordEvent(PlayerPrefs.GetString("CurrentInput"), checkpointnames[i], PlayerPrefs.GetFloat(checkpointnames[i]+" Value"));
				Debug.Log("loop" + i.ToString("0"));
			}
		}
	}

	void LumosDataCall()
	{
		LumosAnalytics.RecordEvent("Time Slow Used", "zone : "+currCheckP.ToString("0"), TimeSlow.timesUsedTS - buffer1);
		LumosAnalytics.RecordEvent("Telekinesis Used", "zone : "+currCheckP.ToString("0"), Telekinesis.timesUsedTK - buffer2);
		LumosAnalytics.RecordEvent("Shoot Used", "zone : "+currCheckP.ToString("0"), MindBullets.timesUsedMB - buffer3);

		buffer1 = TimeSlow.timesUsedTS;
		buffer2 = Telekinesis.timesUsedTK;
		buffer3 = MindBullets.timesUsedMB;
	}
	
	void CheckPointDeath()
	{
		checkPdeath++;
	}

	void CheckPointDeathDataSend()
	{
		LumosAnalytics.RecordEvent(PlayerPrefs.GetString("CurrentInput"), "Died @ " + checkpointnames[currCheckP], checkPdeath);
		checkPdeath = 0;
	}
}