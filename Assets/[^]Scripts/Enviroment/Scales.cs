using UnityEngine;
using System.Collections;

public class Scales : MonoBehaviour 
{
//	GameObject[] allWeightItems;
//	GameObject[] usedWeightItems;
//
//	float weight;
//
//	void Start()
//	{
//		allWeightItems = GameObject.FindGameObjectsWithTag("moveable");
//
//	}
//	void OnTriggerStay2D(Collider2D other)
//	{
//
//	}

//	float massToAdd = 0;
//	bool move = false;
//	Rigidbody2D currRbody;
//	float newY;
//
//	void OnCollisionEnter2D(Collision2D other)
//	{
//		if(other.collider.tag == "moveable" && other.gameObject.layer != 10)
//		{
//			currRbody = other.collider.GetComponent<Rigidbody2D>();
//			massToAdd =  other.collider.rigidbody2D.mass;
//			newY = transform.position.y - massToAdd/2;
//			move = true;
//		}
//	}
//
//	void OnTriggerExit2D(Collider2D other)
//	{
//		if(other.tag == "moveable" && other.gameObject.layer != 10)
//		{
//			currRbody = other.GetComponent<Rigidbody2D>();
//			massToAdd =  other.rigidbody2D.mass;
//			newY = transform.position.y + massToAdd;
//			move = true;
//		}
//	}
//
//	void FixedUpdate()
//	{
//		if(move)
//		{
//			float zOffset = Mathf.Lerp(transform.position.y, newY, Time.deltaTime/2);
//			Vector2 moveVector = new Vector3(transform.position.x, zOffset);
//			rigidbody2D.MovePosition(moveVector);
//		}
//	}
//}
//	public Transform _max, _min;
//	public float _maxf, _minf;
//	public float range;
//
//	void Start()
//	{
//		_minf = _min.position.y;
//		_maxf = _max.position.y;
//	}
//
//	void Update()
//	{
//		range = Mathf.Clamp(range, _min.position.y, _max.position.y);
//
//	}
}