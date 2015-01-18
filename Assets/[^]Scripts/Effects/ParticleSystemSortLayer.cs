using UnityEngine;
using System.Collections;

public class ParticleSystemSortLayer : MonoBehaviour 
{
	void Start()
	{
		particleSystem.renderer.sortingLayerName = "Foreground";
	}
}