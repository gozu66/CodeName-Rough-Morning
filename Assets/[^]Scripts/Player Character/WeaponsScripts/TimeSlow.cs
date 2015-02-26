using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimeSlow : MonoBehaviour 
{
	public static bool timeStopped = false;

	public float amountToSlow = 0.2f, effectDuration = 5, timer = 10, maxTimer = 10;
//	float timeSinceGunfired = 0;

	TimeManager TM;

	public GameObject trail;
	public CharacterControls CharCont;

	public Image timerSprite, blur;


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
		if(timeStopped){timer -= Time.deltaTime / Time.timeScale;}else{timer += Time.deltaTime;}

		if(timer < 0.01f)returnTimeScale();

		timer = Mathf.Clamp(timer, 0, maxTimer);

		timerSprite.fillAmount = timer / maxTimer;
	}

	public void SlowTimeScale()
	{
		timeStopped = true;
		CharCont.TimeAdjust(true);
		TM.slowTime(amountToSlow, effectDuration);
		StopAllCoroutines();
		StartCoroutine("Blurr");
		trail.SetActive(true);
	}

	public void returnTimeScale()
	{
		Time.timeScale = 1.0f;
		CharCont.TimeAdjust(false);
		timeStopped = false;
		StopAllCoroutines();
		StartCoroutine("DeBlurr");
		trail.SetActive(false);
	}

	IEnumerator Blurr()
	{
		float alpha = 0.0f;
		while(blur.color.a < 0.5f){

			alpha += Time.deltaTime;
			blur.color = new Color(blur.color.r, blur.color.g, blur.color.b, alpha);
			yield return null;
		}

	}
	IEnumerator DeBlurr()
	{
		float alpha = 0.5f;
		while(blur.color.a > 0.0f){
			
			alpha -= Time.deltaTime;
			blur.color = new Color(blur.color.r, blur.color.g, blur.color.b, alpha);
			yield return null;
		}
		
	}

}
