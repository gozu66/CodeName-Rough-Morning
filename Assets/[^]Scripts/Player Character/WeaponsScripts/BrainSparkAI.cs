using UnityEngine;
using System.Collections;

public class BrainSparkAI : MonoBehaviour 
{
	public ParticleSystem ptl;
	TrailRenderer myTrail;

	void Start()
	{
		ptl = GetComponent<ParticleSystem>();
		ptl.renderer.sortingLayerName = "Foreground";
		myTrail = GetComponent<TrailRenderer>();
	}

	void OnTriggerEnter2D()
	{
		StartCoroutine("Impact");
		Debug.Log("hit");
	}
	IEnumerator Impact()
	{
		ptl.Play();
		BrainSpark.isFired = false;
		rigidbody2D.isKinematic = true;
		yield return new WaitForSeconds(0.1f);
		myTrail.enabled = false;
		BrainSpark.isFired = false;
	}
}
