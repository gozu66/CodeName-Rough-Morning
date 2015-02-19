using UnityEngine;
using System.Collections;

public class TKSineWaveTest1 : MonoBehaviour 
{
	LineRenderer myLine;
	public Transform target;
	public int verts;

	void Start()
	{
		myLine = GetComponent<LineRenderer>();
		myLine.SetVertexCount(verts);
	}

	void Update()
	{
		float incrementX = (target.position.x - transform.position.x) / (verts-1);
		float incrementY = (target.position.y - transform.position.y) / (verts-1);

		for(int i = 0; i < verts; i++)
		{
			myLine.SetPosition(i, new Vector3(i * incrementX, (i * incrementY), 0));
		}
	}


}