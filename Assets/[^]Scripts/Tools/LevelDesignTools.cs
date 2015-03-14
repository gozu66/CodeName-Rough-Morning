using UnityEngine;
using System.Collections;

public class LevelDesignTools : MonoBehaviour 
{
	public enum _object 
	{
		B_wallFlat, B_wallCurved, B_SmallWallFlat, B_SmallWallCurved, B_DividerConcave, B_DividerConvex, B_DividerStraight, B_SmallDividerConcave, B_SmallDividerConvex, B_SmallDividerStraight,
	};

	public _object selectedObject;
	public Transform _parent;
	GameObject currObj;


	public int rows, columns;

	[ContextMenu("Create")]
	void Create()
	{
//		if(selectedObject == _object._wallFlat){currObj = props[0];}
//		if(selectedObject == _object._wallCurved){currObj = props[1];}

		int i = (int)selectedObject;
		currObj = props[i];

		for(int x = 0; x < columns; x++){
			float newX = transform.position.x + (currObj.GetComponent<SpriteRenderer>().bounds.extents.x * (x*2));
			for(int y = 0; y < rows; y++){
				float newY = transform.position.y + (currObj.GetComponent<SpriteRenderer>().bounds.extents.y * (y*2));
				Instantiate(currObj, new Vector2(newX, newY), Quaternion.identity);
			}
		}
	}

	[ContextMenu("ParentObjects")]
	void ParentObjects()
	{
		GameObject[] objs = GameObject.FindGameObjectsWithTag("Environment");
		foreach(GameObject go in objs)
		{
			go.transform.parent = _parent;
			Debug.Log("execute");
		}
	}

	void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, 0.5f);
	}

	public GameObject[] props;
}	