using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Credits : MonoBehaviour {

	float scrollSpeed = 70f, fadeSpeed = 0.25f;
	RectTransform _rectTransform;
	Image _image;
	public Image _color;
	public bool header, footer;
	public AudioSource _audio;

	void Start()
	{
		if(!header)
			_rectTransform = GetComponent<RectTransform>();

		if(header)
			_image = GetComponent<Image>();
	}

	void Update() 
	{
		if(!header)
			_rectTransform.position += new Vector3(0, scrollSpeed*Time.deltaTime, 0);

		if(header)
			_image.color = new Color(255f, 255f, 255f, _image.color.a-fadeSpeed*Time.deltaTime);

		if(footer)
		{
			float height = _rectTransform.position.y;
			if(height >= 500)
			{
				StartCoroutine("LevelEnd");
			}
		}
	}

	IEnumerator LevelEnd()
	{
		_color.color = new Color(0, 0, 0, _color.color.a+fadeSpeed*Time.deltaTime);
		_audio.volume -= (fadeSpeed/3)*Time.deltaTime;
		yield return new WaitForSeconds (5);
		Application.LoadLevel(0);
	}
}
