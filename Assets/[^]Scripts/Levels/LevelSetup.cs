using UnityEngine;
using System.Collections;

public class LevelSetup : MonoBehaviour
{
	private static bool created = false;

	Vector3 StartSpot1, StartSpot2, StartSpot3;
	public Vector3 MyStartSpot;
	
	void Awake() 
	{
		if (!created) { // this is the first instance - make it persist 
			DontDestroyOnLoad(this.gameObject); 
			created = true; 
		} else { // this must be a duplicate from a scene reload - DESTROY! 
			Destroy(this.gameObject); 
		} 

	
	}

	void Start()
	{


		StartSpot1 = new Vector3(-24.65f, 31.96f, 0f);
		StartSpot2 = new Vector3(87.65f, 39.5f, 0f);
		StartSpot3 = new Vector3(189.22f, 6.66f, 0);
		
		//SetNextPosition();
		
		MyStartSpot = StartSpot1;
		

	}

	void OnLevelWasLoaded(int level)
	{


		if(level == 2)
		{
			MyStartSpot = StartSpot2;
		}
		if(level == 3)
		{
			MyStartSpot = StartSpot3;
		}

		if(Application.loadedLevel == 1)
		{
			GameObject Player = GameObject.FindObjectOfType<CharacterControls>().gameObject;
			Player.transform.position = MyStartSpot;
		}
	}
}