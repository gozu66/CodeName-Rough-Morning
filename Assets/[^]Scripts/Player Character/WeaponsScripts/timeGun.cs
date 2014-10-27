using UnityEngine;
using System.Collections;

public class timeGun : MonoBehaviour 
{
	public static bool timeStopped = false;

	public float amountToSlow = 0.2f, effectDuration = 5, cooldown = 10, maxCooldown = 10;
	float storedSpeed;
	float timeSinceGunfired = 0;

	public GUISkin mySkin;

	public TimeManager TM;
	public CharacterControls charCont;

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
		else 
		{
			if(timeSinceGunfired > 0)
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
					if(Input.GetAxis("RTrigger_1") >= 0.1f)
					{
							timeStopped = true;
							cooldown = 0; 
							TM.slowTime(amountToSlow, effectDuration);
							storedSpeed = charCont.maxSpeed;
							charCont.maxSpeed = charCont.maxSpeed / (Time.timeScale*2);
				}
			}
		}
	}

	public void returnTimeScale()
	{
		Time.timeScale = 1.0f;
		charCont.maxSpeed = storedSpeed;
		timeStopped = false;
		timeSinceGunfired = Time.timeSinceLevelLoad;
	}

	void OnGUI()
	{
		GUI.skin = mySkin;

		GUI.Label(new Rect(25, 5, 100, 10),"");

		if(cooldown >= 1f)
		{
			GUI.Box(new Rect(25, 5, cooldown * 10, 10),"");
		}
	}
}
