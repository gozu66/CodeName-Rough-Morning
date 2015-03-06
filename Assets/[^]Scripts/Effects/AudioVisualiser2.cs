using UnityEngine;
using System.Collections;

public class AudioVisualiser2 : MonoBehaviour 
{
	LineRenderer myLine;
	public int resolution, multiplier;
	public float divider;

	void Start()
	{
		myLine = GetComponent<LineRenderer>();
		renderer.sortingLayerName = "Foreground";
		InvokeRepeating("Visualize", 0.0f, 0.025f);
	}

	void Visualize()
	{
		float[] audioData = new float[resolution];
		AudioListener.GetOutputData(audioData, 0);
		myLine.SetVertexCount(audioData.Length);
		for(int i = 0; i < audioData.Length; i++)
		{
			myLine.SetPosition(i, new Vector3(transform.position.x + (i * divider), transform.position.y + (audioData[i] * multiplier), 0));
		}
	}
}