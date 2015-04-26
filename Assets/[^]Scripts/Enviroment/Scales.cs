using UnityEngine;
using System.Collections;

public class Scales : MonoBehaviour 
{
	public Transform minHeightTransform, maxHeightTransform;
	public float _minHeight, _maxHeight;
	public float _targetHeight;

	public float maxWeight;
	private float currWeight = 0;
	private float _normalWeight;

	float refFloat = 1.0f;
	

	void Awake()
	{
		_minHeight = minHeightTransform.position.y;
		_maxHeight = maxHeightTransform.position.y;
		_targetHeight = _maxHeight;
	}

	void Start()
	{
		InvokeRepeating("CheckWeight", 0.1f, 0.25f);
	}

	void FixedUpdate()
	{
		float smoothMove = Mathf.SmoothDamp(transform.position.y, _targetHeight, ref refFloat, 1.0f);
		rigidbody2D.MovePosition(new Vector2(transform.position.x, smoothMove));

		_targetHeight = Mathf.Clamp(_targetHeight, _minHeight, _maxHeight);
	}

	void CheckWeight()
	{
		Collider2D[] _weightsArray = new Collider2D[10];
		Physics2D.OverlapAreaNonAlloc(collider2D.bounds.max, collider2D.bounds.min, _weightsArray);

		currWeight = 0;
		foreach(Collider2D col in _weightsArray)
		{
			if(col != null)
			{
				if(col.gameObject.layer == 11 && GameObject.FindObjectOfType<Telekinesis>().heldObj != col.gameObject)
				{
					currWeight += col.GetComponent<Weight>().weight;
				}
				if(col.gameObject.tag == "Player")
				{
					currWeight += col.transform.GetComponent<Weight>().weight;
				}
			}
		}

		_normalWeight = currWeight/maxWeight;													//get normailzed weight value
		_normalWeight = 1 - _normalWeight;													//invert value to match scale
		_targetHeight = (_minHeight + (_normalWeight * (_maxHeight - _minHeight)));			//set Target height to normal value, realsied in worldSpace
	}
}