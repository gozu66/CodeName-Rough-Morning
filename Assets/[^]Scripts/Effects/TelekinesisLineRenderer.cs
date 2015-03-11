using UnityEngine;
using System.Collections;

public class TelekinesisLineRenderer : MonoBehaviour 
{
	LineRenderer myLine;
	public GameObject target;
	public int verts;
	public float waveHeight = 10, timeMultiplier;
	float offset, xDist, yDist;
	public GameObject WeaponTrans;
	public enum lines {a,b,c,d};
	public lines Daline;

	void Start()
	{
		myLine = GetComponent<LineRenderer>();
		myLine.SetVertexCount(verts);
		this.renderer.sortingLayerName = "Foreground";
	}

	void Update()
	{
		if(target){
			xDist = Mathf.Abs(transform.position.x - target.transform.position.x)/10;
			yDist = 1 - xDist;

			float incrementX = ((target.transform.position.x - transform.position.x) / (verts - 1) * transform.parent.localScale.x);
			float incrementY = (target.transform.position.y - transform.position.y) / (verts - 1);

			for(int i = 0; i < verts; i++)
			{
				if(i == 0 || i == verts - 1)
				{
					myLine.SetPosition(i, new Vector3(i * incrementX, (i * incrementY), 0));
				}
				else
				{
					float newi = i;
					newi = newi / verts;
					if(newi <= 0.5f){
						newi = newi / 0.5f;
					}else{
						newi = 1 - newi;
						newi = newi / 0.5f;
					}
//					if(Daline == lines.a)myLine.SetPosition(i, new Vector3(i * incrementX, (i * incrementY) + PingPong(Time.time * timeMultiplier, (-waveHeight * newi * xDist), (waveHeight * newi * xDist)), 0));
//
//					if(Daline == lines.b)myLine.SetPosition(i, new Vector3(i * incrementX, (i * incrementY) + PingPong(Time.time * timeMultiplier, (newi), (-newi)), 0));
//
//					if(Daline == lines.c)myLine.SetPosition(i, new Vector3(i * incrementX, (i * incrementY) + PingPong(Time.time * timeMultiplier, (-waveHeight), (waveHeight)), 0));

					if(Daline == lines.d)myLine.SetPosition(i, new Vector3((i * incrementX) + PingPong(Time.time * timeMultiplier, (-waveHeight * newi * yDist), (waveHeight * newi * yDist)), (i * incrementY) + PingPong(Time.time * timeMultiplier, (-waveHeight * newi *xDist), (waveHeight * newi*xDist)), 0));
				}
			}
		}
	}

	float PingPong(float aValue, float aMin, float aMax)
	{
		return Mathf.PingPong(aValue, aMax-aMin) + aMin;
	}

	public void SetTarget(GameObject a)
	{
		myLine.SetVertexCount(0);
		target = a;
		myLine.SetVertexCount(verts);
	}
}