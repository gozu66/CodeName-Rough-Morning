using UnityEngine;
using System.Collections;

public class AudioVisualiser2 : MonoBehaviour 
{
	LineRenderer myLine;
	public int resolution, multiplier;

	void Start()
	{
		myLine = GetComponent<LineRenderer>();
		InvokeRepeating("Visualize", 0.0f, 0.025f);
	}

	void Visualize()
	{
		float[] audioData = new float[resolution];
		AudioListener.GetOutputData(audioData, 0);
		myLine.SetVertexCount(audioData.Length);
		for(int i = 0; i < audioData.Length; i++)
		{
			myLine.SetPosition(i, new Vector3(i, (audioData[i] * multiplier), 0));
		}
	}
}