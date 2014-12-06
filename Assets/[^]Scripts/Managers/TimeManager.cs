using UnityEngine;
using System.Collections;

public class TimeManager : MonoBehaviour 
{
	public TimeSlow TGun;
	public CharacterControls CharCont;

	void Start()
	{
		TGun = this.GetComponentInChildren<TimeSlow>();
		CharCont = this.GetComponentInChildren<CharacterControls>();
	}

	public void slowTime(float newTimeScale, float length)
	{
		Time.timeScale = newTimeScale;
		CharCont.TimeAdjust(true);
		StartCoroutine("slowTimeCountdown", newTimeScale * length);
	}

	IEnumerator slowTimeCountdown(float countdownTime)
	{
		yield return new WaitForSeconds(countdownTime);
		Time.timeScale = 1.0f;
		CharCont.TimeAdjust(false);
		TGun.returnTimeScale();
	}

}
