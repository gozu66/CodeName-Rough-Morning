using UnityEngine;
using System.Collections;

public class TimeManager : MonoBehaviour 
{
	public timeGun TGun;

	void Start()
	{
		TGun = this.GetComponentInChildren<timeGun>();
	}

	public void slowTime(float newTimeScale, float length)
	{
		Time.timeScale = newTimeScale;
		StartCoroutine("slowTimeCountdown", newTimeScale * length);
	}

	IEnumerator slowTimeCountdown(float countdownTime)
	{
		yield return new WaitForSeconds(countdownTime);
		Time.timeScale = 1.0f;
		TGun.returnTimeScale();
	}

}
