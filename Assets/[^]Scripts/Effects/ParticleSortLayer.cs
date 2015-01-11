using UnityEngine;
using System.Collections;

public class ParticleSortLayer : MonoBehaviour {

	void Start()
	{
		particleEmitter.renderer.sortingLayerName = "Foreground";
	}
}
