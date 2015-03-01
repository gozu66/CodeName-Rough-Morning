using UnityEngine;
using System.Collections;

public class AudioVisualiser : MonoBehaviour 
{
	public GameObject[] sprites;
	Transform[] spriteTransforms;

	void Start()
	{
		spriteTransforms = new Transform[sprites.Length];

		for(int i = 0; i < sprites.Length; i++)
		{
			spriteTransforms[i] = sprites[i].transform;
		}

		InvokeRepeating("AudioVisualize", 0f, 0.125f);
	}

	void AudioVisualize()
	{
		float[] spectrumData = new float[8];
		spectrumData = AudioListener.GetOutputData(spectrumData.Length, 0);

		for(int i = 0; i < spriteTransforms.Length; i++)
		{
			float newY = spectrumData[i];
			spriteTransforms[i].localScale = new Vector3(spriteTransforms[i].localScale.x, spriteTransforms[i].localScale.x + (newY * 10) ,spriteTransforms[i].localScale.x);
		}
	}
}
