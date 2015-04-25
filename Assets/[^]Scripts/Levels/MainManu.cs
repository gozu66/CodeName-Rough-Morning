using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainManu : MonoBehaviour 
{
	public Image _color;
	float fadeSpeed = 0.5f;
	bool fading;

//	private float _sofar; 
//	private static bool created = false;
//	
//	void Awake() 
//	{
//		if (!created) { // this is the first instance - make it persist 
//			DontDestroyOnLoad(this.gameObject); 
//			created = true; 
//		} else { // this must be a duplicate from a scene reload - DESTROY! 
//			Destroy(this.gameObject); 
//		} 
//	}
			
//	void Update() 
//	{ 
//		_sofar += Time.deltaTime; 
//
//		if (_sofar > 3) 
//		{ 
//			print("reloading level ..."); 
//			Application.LoadLevel("test"); 
//		} 
//	}


	public void LoadCredits()
	{
		StartCoroutine("Credits");
	}
	public void LoadGame()
	{
		StartCoroutine("Game");
	}
	public void SelectLevels()
	{
		StartCoroutine("LevelSelect");
	}
	public void Quit()
	{
		StartCoroutine("QuitGame");
	}

	void Update()
	{
		if(fading)
			_color.color = new Color(0, 0, 0, _color.color.a+fadeSpeed*Time.deltaTime);
	}

	IEnumerator Credits()
	{
		_color.gameObject.SetActive(true);
		fading = true;
		yield return new WaitForSeconds(3);
		Application.LoadLevel(6);
	}
	IEnumerator Game()
	{
		_color.gameObject.SetActive(true);
		fading = true;
		yield return new WaitForSeconds(3);
		Application.LoadLevel(1);
	}
	IEnumerator LevelSelect()
	{
		_color.gameObject.SetActive(true);
		fading = true;
		yield return new WaitForSeconds(3);
		Application.LoadLevel(7);
	}
	IEnumerator QuitGame()
	{
		_color.gameObject.SetActive(true);
		fading = true;
		yield return new WaitForSeconds(3);
		Application.Quit();
	}
}