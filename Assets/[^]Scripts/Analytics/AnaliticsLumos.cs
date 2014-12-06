﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AnaliticsLumos : MonoBehaviour 
{
	float timer = 0.0f;
	int deaths, currCheckP, checkPdeath;
	float[] checkpoints = new float[8];
	float[] checkpointdeaths = new float[8];
	string[] checkpointnames = {"CheckPoint 1", "CheckPoint 2", "CheckPoint 3", 
		"CheckPoint 4", "CheckPoint 5", "CheckPoint 6", "CheckPoint 7", "Finished @ "};

	void Start()
	{
		deaths = 0; currCheckP = 0; checkPdeath = 0;
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
				checkpoints[currCheckP] = timer - checkpoints[currCheckP - 1];
			}
			else{
				checkpoints[currCheckP] = timer;
			}

			CheckPointDeathDataSend();
			LumosAnalytics.RecordEvent(checkpointnames[currCheckP], checkpoints[currCheckP]);
			currCheckP++;

			if(currCheckP == 8)
			{
				LumosAnalytics.RecordEvent("Finished @ ", timer);
//				Debug.Log("FINISH?");
			}
		}
	}

	void LumosDataCall()
	{
		LumosAnalytics.RecordEvent(checkpointnames[0], checkpoints[0]);
		LumosAnalytics.RecordEvent(checkpointnames[1], checkpoints[1]);
		LumosAnalytics.RecordEvent(checkpointnames[2], checkpoints[2]);
		LumosAnalytics.RecordEvent(checkpointnames[3], checkpoints[3]);
		LumosAnalytics.RecordEvent(checkpointnames[4], checkpoints[4]);
		LumosAnalytics.RecordEvent(checkpointnames[5], checkpoints[5]);
		LumosAnalytics.RecordEvent(checkpointnames[6], checkpoints[6]);
		LumosAnalytics.RecordEvent(checkpointnames[7], checkpoints[7]);
		Debug.Log("Analytics Sent");


//		for(int x = 0; x < 8; x++)
//		{
//			LumosAnalytics.RecordEvent(checkpointnames[x], checkpoints[x]);
//			Debug.Log("Analytics Sent " + checkpointnames[x]);
//		}
	}

	void CheckPointDeath()
	{
		checkPdeath++;
	}
	void CheckPointDeathDataSend()
	{
		LumosAnalytics.RecordEvent("Died @ " + checkpointnames[currCheckP], checkPdeath);
		checkPdeath = 0;
		Debug.Log(checkpointnames[currCheckP] + " DED");
	}
	
	/*
	float timer;
	int i;
	int deaths;
	float chp1, chp2, chp3,chp4,chp5,chp6,chp7,finish;
//	chp1s, chp2s, chp3s,chp4s,chp5s,chp6s,chp7s,finish;

	void Start()
	{
		timer = 0;
//		i = 1;
		deaths = 0;
	}

	void Update()
	{
		timer += Time.deltaTime;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "checkPoint")
		{
			CheckPointHit(other.gameObject);
		}
	}

	void CheckPointHit()
	{


//		chp1 = timer;
//		chp2 = timer;
//		chp3 = timer;
//		chp4 = timer;
//		chp5 = timer;
//		chp6 = timer;
//		chp7 = timer;
//		finish = timer;

//		if(i <= 7)
//		{
//			LumosAnalytics.RecordEvent(names, timer);
//			i++;
//		}
//		else{
//			LumosAnalytics.RecordEvent("Finishing Time ", timer);
//		}
	}

	void CheckPointDeath()
	{
		deaths++;

		LumosAnalytics.RecordEvent("Deaths at CheckPoint " + i.ToString("0"), deaths);
	}*/

}