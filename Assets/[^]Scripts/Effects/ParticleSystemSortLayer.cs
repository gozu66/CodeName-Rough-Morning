using UnityEngine;
using System.Collections;

public class ParticleSystemSortLayer : MonoBehaviour 
{
	void Awake()
	{
		particleSystem.renderer.sortingLayerName = "Foreground";
	}
}