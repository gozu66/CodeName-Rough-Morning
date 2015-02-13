using UnityEngine;
using System.Collections;

public class lineRender : MonoBehaviour 
{
	LineRenderer LR;

	public GameObject chandelier;

	void Start ()
	{
		LR = GetComponent<LineRenderer>();
//		LR.SetPosition(0, transform.position);
//		LR.renderer.sortingLayerID = 3;
//		LR.renderer.sortingLayerName = "Foreground";
//		print(this.renderer.sortingLayerName);
//		this.renderer.sortingLayerName = "Foreground";
//		print(this.renderer.sortingLayerName);
		LR.renderer.sortingLayerName = "Foreground";
		LR.renderer.sortingOrder = 10;
		LR.SetVertexCount(3);
	}

	void Update ()
	{
		LR.SetPosition(0, transform.position);
		LR.SetPosition(2, chandelier.transform.position);
	}
}