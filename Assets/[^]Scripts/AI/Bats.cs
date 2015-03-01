
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
	Transform myTransform, player;

	void Start()
	{
		anim = GetComponent<Animator>();
		myRigidbody2D = rigidbody2D;
		myTransform = transform;
		player = GameObject.FindGameObjectWithTag("Player").transform;
		currWPi = 0;

	}

	void Update()
	{
		switch(_state){

		case States.idle:
			isSideWays = false;
			isFrontWays = false;
			isIdle = true;
			IdleUpdate();
			break;

		case States.wander:
			isSideWays = true;
			isFrontWays = false;
			isIdle = false;
			WanderUpdate();
			break;

		case States.attack:
			AttackUpdate();
			break;

		case States.scatter:
			ScatterUpdate();
			break;
		}

		anim.SetBool("isIdle", isIdle);
		anim.SetBool("isSideWays", isSideWays);
		anim.SetBool("isFrontWays", isFrontWays);
	}

	public Transform[] wanderPoints;
	public LayerMask lyrMsk;
	public float checkDist, speed;
	int currWPi = 0;
	Transform currWP;

	void WanderUpdate()
	{
		if(currWP != wanderPoints[currWPi])
			currWP = wanderPoints[currWPi];

//		myRigidbody2D.AddForce(myRigidbody2D.position + new Vector2(currWP.position.x-myRigidbody2D.position.x, currWP.position.y-myRigidbody2D.position.y)*Time.deltaTime*speed);
		myRigidbody2D.AddForce(new Vector2(currWP.position.x-myRigidbody2D.position.x, currWP.position.y-myRigidbody2D.position.y)*Time.deltaTime*speed);

		if(myRigidbody2D.velocity.x < 0){
			transform.localScale = new Vector2(-1, transform.localScale.y);
		}else{
			transform.localScale = new Vector2(1, transform.localScale.y);
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "pathNode"){
			if(currWPi >= wanderPoints.Length-1){
				currWPi = 0;
			}else{
				currWPi++;
			}
			print("hitWP");
		}
	}

	void IdleUpdate()
	{
//		Ray PlayerCheck;
		RaycastHit2D playerCheck = Physics2D.Raycast(myTransform.position, player.position-myTransform.position, checkDist, lyrMsk);
		if(playerCheck)
			_state = States.wander;
	}

	void AttackUpdate()
	{
		
	}
	
	void ScatterUpdate()
	{
		
	}

}