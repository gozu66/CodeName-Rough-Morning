using UnityEngine;
using System.Collections;

public class TKSineWaveTest : MonoBehaviour 
{
	public int resolution = 10;
	public float length;
	private ParticleSystem.Particle[] points;


	void Start()
	{
		points = new ParticleSystem.Particle[resolution];
		float incriment = length / (resolution - 1);

		for(int i = 0; i < resolution; i++)
		{
			float x = i * incriment;
			points[i].position = new Vector3(x, 0, 0);
			points[i].color = new Color(x, 0, 0);
			points[i].size = 0.1f;
		}
	}

	void Update()
	{
		particleSystem.SetParticles(points, points.Length);

		for(int i = 0; i < resolution; i++)
		{
			Vector3 p = points[i].position;
//			p.y = Linear(p.x);
//			p.y = Exponential(p.x);
//			p.y = Parabola(p.x);
			p.y = Sine(p.x);
			points[i].position = p;
		}
	}

	private static float Linear(float x)
	{
		return x;
	}

	private static float Exponential(float x)
	{
		return x * x;
	}

	private static float Parabola(float x)
	{
		x = 2 * (x -1);
		return x * x;
	}

	private static float Sine(float x)
	{
		return 0.5f + (0.5f * Mathf.Sin(2 * Mathf.PI * x + (Time.timeSinceLevelLoad * 10)));
	}
}