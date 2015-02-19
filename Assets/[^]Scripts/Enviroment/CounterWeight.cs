using UnityEngine;
using System.Collections;

public class CounterWeight : MonoBehaviour 
{
	public Scales _scale;
	float _max, _min;
	float _targetHeight;
	float refFloat = 1.0f;


	IEnumerator Start()
	{
		yield return new WaitForSeconds(0.5f);
		_scale.GetComponent<Scales>();
		_min = _scale._minHeight;
		_max = _scale._maxHeight;
	}

	void Update()
	{
		float smoothMove = Mathf.SmoothDamp(transform.position.y, _targetHeight, ref refFloat, 0.1f);
		rigidbody2D.MovePosition(new Vector2(transform.position.x, smoothMove));
		
		_targetHeight = Mathf.Clamp(_targetHeight, _min, _max);
	}

	public void SetWeightByCounter(float normal)
	{
		_targetHeight = normal;
	}
}