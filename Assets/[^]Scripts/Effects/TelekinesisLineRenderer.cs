using UnityEngine;
using System.Collections;

public class TelekinesisLineRenderer : MonoBehaviour 
{
	LineRenderer myLine;
	public GameObject target;
	public int verts;
	public float waveHeight = 10, timeMultiplier;
	float offset;
	public GameObject WeaponTrans;

	void Start()
	{
		myLine = GetComponent<LineRenderer>();
		myLine.SetVertexCount(verts);
		this.renderer.sortingLayerName = "Foreground";
	}

	void Update()
	{
		if(target){
			float Dist = Vector2.Distance(transform.position, target.transform.position);
			waveHeight = Dist/3;
			float incrementX = ((target.transform.position.x - transform.position.x) / (verts - 1)*transform.parent.localScale.x);
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

					myLine.SetPosition(i, new Vector3(i * incrementX, (i * incrementY) + PingPong(Time.time * timeMultiplier, (-waveHeight * newi), (waveHeight * newi)), 0));
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
		target = a;
	}
}