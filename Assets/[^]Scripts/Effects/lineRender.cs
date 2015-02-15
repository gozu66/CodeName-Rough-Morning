using UnityEngine;
using System.Collections;

public class lineRender : MonoBehaviour 
{
	LineRenderer LR;

	public GameObject chandelier;

	void Start ()
	{
		LR = GetComponent<LineRenderer>();
		LR.renderer.sortingLayerName = "Foreground";
		LR.renderer.sortingOrder = 10;
	}

	void Update ()
	{
		LR.SetPosition(0, transform.position);
		LR.SetPosition(1, chandelier.transform.position);
	}
}