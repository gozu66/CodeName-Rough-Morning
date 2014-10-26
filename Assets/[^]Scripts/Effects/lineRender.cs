using UnityEngine;
using System.Collections;

public class lineRender : MonoBehaviour 
{
	LineRenderer LR;

	public GameObject chandelier;

	void Start ()
	{
		LR = GetComponent<LineRenderer>();
		LR.SetPosition(0, transform.position);
	}

	void Update ()
	{
		LR.SetPosition(1, chandelier.transform.position);
	}
}