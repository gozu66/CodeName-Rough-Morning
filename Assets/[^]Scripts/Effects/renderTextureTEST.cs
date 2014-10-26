using UnityEngine;
using System.Collections;

public class renderTextureTEST : MonoBehaviour /*
{
	Texture2D t2d;

	public GameObject mirror;

	void Start()
	{
		t2d = new Texture2D(512, 512, TextureFormat.RGB24, false);
	}


	void Update()
	{
		if(Input.GetKeyDown(KeyCode.F1))
			StartCoroutine("RenderToTexture");
	}


	IEnumerator RenderToTexture()
	{
		yield return new WaitForEndOfFrame();
		t2d.ReadPixels(this.camera.rect, 1, 1, false);
		mirror.renderer.sharedMaterial.mainTexture = t2d;
		Debug.Log("kfkfkf");
	}
	
}*/
{
	public Camera playerCam;

	void Update ()
	{
		if (Input.GetKey("c"))
		{
			StartCoroutine("RenderToTexture");
		}        
	}

	IEnumerator RenderToTexture()
	{
		yield return new WaitForEndOfFrame();
		Texture2D tex = new Texture2D(Screen.width,Screen.height,TextureFormat.RGB24,false);

		tex.ReadPixels(new Rect(0,0,Screen.width,Screen.height),0,0,false);
		//tex.ReadPixels(new Rect(playerCam.rect.x, playerCam.rect.y, playerCam.rect.width, playerCam.rect.height),0,0,false);
		//tex.ReadPixels(playerCam.pixelRect,0,0,false);

		tex.Apply();
		if (renderer != null)
			renderer.sharedMaterial.mainTexture = tex;
	}
}