using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Credits : MonoBehaviour {

	float scrollSpeed = 70f, fadeSpeed = 0.5f;
	RectTransform _rectTransform;
	Image _image;
	public Image _color;
	public bool header;
	public AudioSource _audio;
//	float timer;

	void Start()
	{
		if(!header)
			_rectTransform = GetComponent<RectTransform>();

		if(header)
			_image = GetComponent<Image>();

	}

	void Update() 
	{
//		timer+=Time.deltaTime;
//		Debug.Log(timer);

		if(!header)
			_rectTransform.position += new Vector3(0, scrollSpeed*Time.deltaTime, 0);

		if(header){
			_image.color = new Color(255f, 255f, 255f, _image.color.a-fadeSpeed*Time.deltaTime);

		if(Time.timeSinceLevelLoad >= 23.0f){
				_color.color = new Color(0, 0, 0, _color.color.a+fadeSpeed*Time.deltaTime);
				_audio.volume -= (fadeSpeed/3)*Time.deltaTime;
			}
		if(Time.timeSinceLevelLoad >= 27f){
				Application.LoadLevel(0);
			}
		}
	}
}
