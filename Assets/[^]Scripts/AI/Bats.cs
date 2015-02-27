using UnityEngine;
using System.Collections;

public class Bats : MonoBehaviour 
{
	public enum States {
		idle, 
		wander,
		attack,
		scatter
	}
	public States _state;

	Animator anim;
	public bool isSideWays, isFrontWays, isIdle;
	Rigidbody2D myRigidbody2D;

	void Start()
	{
		anim = GetComponent<Animator>();
		myRigidbody2D = rigidbody2D;

		currWP = wanderPoints[0];
	}

	void Update()
	{
		switch(_state){

		case States.idle:
			IdleUpdate();
			break;

		case States.wander:
			WanderUpdate();
			break;

		case States.attack:
			AttackUpdate();
			break;

		case States.scatter:
			ScatterUpdate();
			break;
		}
	}

	void IdleUpdate()
	{

	}

	public Transform[] wanderPoints;
	int currWPi = 0;
	Transform currWP;

	void WanderUpdate()
	{

//		myRigidbody2D.MovePosition((currWP.position - transform.position)*Time.deltaTime*0.1f);
	}

	void AttackUpdate()
	{

	}

	void ScatterUpdate()
	{

	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "pathNode"){
			currWP = ChangeWanderPoint(currWPi);
			print("hit");
		}
	}

	Transform ChangeWanderPoint(int _currWP)
	{
		if(currWPi >= wanderPoints.Length)
			return wanderPoints[0];
	
		return null;
	}
}