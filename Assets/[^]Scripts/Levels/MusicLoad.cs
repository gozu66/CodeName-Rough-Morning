using UnityEngine;
using System.Collections;

public class MusicLoad : MonoBehaviour 
{
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

	void Update()
	{
		if(Application.loadedLevel == 1 || Application.loadedLevel == 2 || Application.loadedLevel == 3 || Application.loadedLevel == 4 || Application.loadedLevel == 5)
		{
			Destroy(gameObject);
		}
	}
}

