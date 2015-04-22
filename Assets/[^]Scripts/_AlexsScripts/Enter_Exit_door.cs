using UnityEngine;
using System.Collections;

public class Enter_Exit_door : MonoBehaviour 
{

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	void OnTriggerEnter2D(Collider2D other)
		{
			if (other.gameObject.tag == "Untagged") 
				{
					//transform.position = new Vector3(0, 0, 0);
					Debug.Log("Hello world");
				}
		}

}
