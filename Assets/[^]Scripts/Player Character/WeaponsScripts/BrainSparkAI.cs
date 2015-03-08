using UnityEngine;
using System.Collections;

public class BrainSparkAI : MonoBehaviour 
{
	public ParticleSystem ptl;
	public float delay;
	TrailRenderer myTrail;

	void Start()
	{
		ptl = GetComponent<ParticleSystem>();
		ptl.renderer.sortingLayerName = "Foreground";
		myTrail = GetComponent<TrailRenderer>();
		delay = 1.0f;
	}

	void OnCollisionEnter2D()
	{
		StartCoroutine("Impact");
	}
	IEnumerator Impact()
	{
		ptl.Play();
		BrainSpark.isFired = false;
		rigidbody2D.isKinematic = true;
		myTrail.time = 0.0f;
		yield return new WaitForSeconds(delay);
		BrainSpark.isFired = false;
		gameObject.SetActive(false);
	}
}
