using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour 
{
	public static CameraShake instance;

	Vector3 initialPos;
	Transform myT;
	float _amplitude = 1.0f, _duration = 1.0f;
	bool isShaking = false;

	void Start()
	{
		instance = this;
		myT = transform;
//		initialPos = myT.position;
	}

	void Update()
	{
		if(isShaking){
			transform.localPosition = myT.position + Random.insideUnitSphere * _amplitude;
		}

		if(Input.GetKeyDown(KeyCode.T))
		{
			CamShake(_amplitude, _duration);
		}
	}

	public void CamShake(float amplitude, float duration)
	{
		_amplitude = amplitude;
		_duration = duration;
		isShaking = true;
		CancelInvoke();
		Invoke("StopCamShake", _duration);
	}

	public void CamKick(Vector3 Direction)
	{
		transform.localPosition += (-Direction) * 1;
	}

	void StopCamShake()
	{
		isShaking = false;
	}
}