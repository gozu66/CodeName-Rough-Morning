using UnityEngine;
using System.Collections;

public class Weight : MonoBehaviour{

	public int weight = 0;

	[ContextMenu("Apply script to all 'moveable' objects")]
	public void ApplyScript()
	{
		GameObject[] gameObjs = GameObject.FindGameObjectsWithTag("moveable");
		foreach(GameObject go in gameObjs)
		{
			go.AddComponent<Weight>();
		}
	}
}
