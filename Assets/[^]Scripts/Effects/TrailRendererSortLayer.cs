using UnityEngine;
using System.Collections;

public class TrailRendererSortLayer : MonoBehaviour 
{
	void Start()
	{
		TrailRenderer tr = this.GetComponent<TrailRenderer>();
		tr.renderer.sortingLayerName = "Foreground";
		tr.renderer.sortingOrder = -1;

	}
}