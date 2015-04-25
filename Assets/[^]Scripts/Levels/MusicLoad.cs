using UnityEngine;
using System.Collections;

public class MusicLoad : MonoBehaviour 
{
	private float _sofar; 
	private static bool created = false;
	
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
		if(Application.loadedLevel == 0)
		{
			DontDestroyOnLoad(this);
		}

		if(Application.loadedLevel != 7 && Application.loadedLevel != 6 && Application.loadedLevel != 0)
		{
			Debug.Log (Application.loadedLevel);
			Destroy(gameObject);
		}
	}
}

