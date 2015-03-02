using UnityEngine;
using System.Collections;

public class TelekinesisPing : MonoBehaviour 
{
	CircleCollider2D myCol;
	Transform myT;
	ParticleSystem myPtl;
	Vector3 myScale;
	float timer;
	public float speed;

	void Awake()
	{
		myCol = GetComponent<CircleCollider2D>();
		myT = transform;
		myScale = myT.localScale;
//		myPtl = GetComponent<ParticleSystem>();
//		myPtl.particleSystem.renderer.sortingLayerName = "Foreground";
	}
	void Start()
	{
//		myCol = GetComponent<CircleCollider2D>();
//		myPtl = GetComponent<ParticleSystem>();
//		myPtl.particleSystem.renderer.sortingLayerName = "Foreground";
	}

	void LateUpdate()
	{
		float multiplier = speed * Time.deltaTime;
		timer += Time.deltaTime;

		myCol.radius += multiplier/30;

		myT.localScale += new Vector3(multiplier*4, multiplier*4, 0);

		if(timer >= 2){
			Reset();
		}

//		myPtl.particleSystem.renderer.sortingLayerName = "Foreground";

	}
	void Reset()
	{

//		myCol.radius = 0.1f;
//		myT.localScale = myScale;
////		myPtl.enableEmission = false;
//		timer = 0f;
		this.gameObject.SetActive(false);
	}

	void OnEnable()
	{
		myCol.radius = 0.1f;
		myT.localScale = myScale;
		timer = 0f;
	}
}