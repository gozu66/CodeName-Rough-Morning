﻿using UnityEngine;
using System.Collections;

public class TimeSlow : MonoBehaviour 
{
	public static bool timeStopped = false;

	public float amountToSlow = 0.2f, effectDuration = 5, cooldown = 10, maxCooldown = 10;
	float timeSinceGunfired = 0;

	TimeManager TM;

	public CharacterControls charCont;

	public GameObject blur;

	void Start()
	{
		TM = transform.parent.GetComponent<TimeManager>();
		charCont = transform.parent.GetComponent<CharacterControls>();
	}

	void OnEnable()
	{
		if(Time.timeSinceLevelLoad - timeSinceGunfired >= 10)
		{
			cooldown = maxCooldown;
		}	
		else if(timeSinceGunfired > 0)
		{
			cooldown = Time.timeSinceLevelLoad - timeSinceGunfired;
		}
	}

	void Update () 
	{

		if(!timeStopped)
		{
			if(cooldown < maxCooldown)
			{
				cooldown += Time.deltaTime;
			}

			else{

				if(Input.GetButtonDown("Y_1") || Input.GetMouseButtonDown(2))
				{
					timeStopped = true;
					cooldown = 0; 
					TM.slowTime(amountToSlow, effectDuration);
					blur.SetActive(true);
//					LumosAnalytics.RecordEvent("Time Gun ", AnaliticsLumos.zone);
					LogUse();
				}
			}
		}
	}

	public void returnTimeScale()
	{
		Time.timeScale = 1.0f;
		timeStopped = false;
		timeSinceGunfired = Time.timeSinceLevelLoad;
		blur.SetActive(false);
	}

	public static int timesUsedTS;
	void LogUse()
	{
		timesUsedTS++;
	}

}