using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimeSlow : MonoBehaviour 
{
	public static bool timeStopped = false;

	public float amountToSlow = 0.2f, effectDuration = 5, timer = 10, maxTimer = 10;
//	float timeSinceGunfired = 0;

	TimeManager TM;

	public GameObject blur;
	public CharacterControls CharCont;

	public Image timerSprite;


	void Start()
	{
		TM = transform.parent.GetComponent<TimeManager>();
		CharCont = GameObject.FindObjectOfType<CharacterControls>();
		CharCont.GetComponentInChildren<CharacterControls>();

	}
	
	void Update () 
	{
		if(Input.GetButtonDown("Y_1") || Input.GetMouseButtonDown(2))
		{
			if(timeStopped)
			{
				returnTimeScale();
			}else
			{
				SlowTimeScale();
			}
		}
//		float timeScaleOffset = Mathf.Abs(0 - Time.timeScale);

		if(timeStopped){timer -= Time.deltaTime / Time.timeScale;}else{timer += Time.deltaTime;}

		if(timer < 0.01f)returnTimeScale();

		timer = Mathf.Clamp(timer, 0, maxTimer);

		timerSprite.fillAmount = timer / 10;
	}

	public void SlowTimeScale()
	{
		timeStopped = true;
		CharCont.TimeAdjust(true);
		TM.slowTime(amountToSlow, effectDuration);
		blur.SetActive(true);
		LogUse();
	}

	public void returnTimeScale()
	{
		Time.timeScale = 1.0f;
		CharCont.TimeAdjust(false);
		timeStopped = false;
//		timeSinceGunfired = Time.timeSinceLevelLoad;
		blur.SetActive(false);
	}

	public static int timesUsedTS;
	void LogUse()
	{
		timesUsedTS++;
	}

}
