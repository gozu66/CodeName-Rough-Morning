using UnityEngine;
using System.Collections;

public class LevelDesignTools : MonoBehaviour 
{
	public enum StaticGeometryBasement 
	{
		wallFlat, wallCurved, SmallWallFlat, SmallWallCurved, DividerConcave, DividerConvex, DividerStraight, SmallDividerConcave, SmallDividerConvex, SmallDividerStraight, Floor_1, Floor_2, Floor_borken_1, Floorbroken_2, FloorBroken_3, FloorBroken_4, FloorBroken_5, FloorBroken_6, FloorBroken_7, FloorBroken_8, FloorBroken_9, Seperator_middle, Seperator_bottom, Seperator_bottomRight, Seperator_bottomeLeft, Sperator_Left, Seperator_Right, Seperator_TopLft, Seperator_Top, Seperator_TopRight, SmallFloor
	};
	public enum StaticGeometryMine
	{
		Wall_1, Wall_2, Wall_3, Wall_Tunnel, Wall_small, Divider_1, Divider_2, Divider_3, Divider_small, Rocks_1, Rocks_2, Rocks_small, Divider_Brace
	};
	public int rows, columns;

	public enum StaticProps
	{
		B_wardrobe_1, B_wardrobe_2, Crate, Door, Bell, Boiler, Bucket, Broom, CanaryCage_open, CanaryCage_closed, CoatRack, Mop_slanted, Mop_straight, Grammaphone_front, Grammaphone_side, VaccumeCleaner, light, Light_shade, MineCart_front, mineCart_side, minecart_wheel, Pump_wheel, Cap_front, Cap_side, Pick, Platform, Radiator, Rope, harness, Shovel_front, Shovel_side, Stairs_bottom, stairs_top, Stairs_bottom_broken, Stairs_top_broken, Pump
	};

	public enum PuzzleObjects
	{
		Pipe_1_static, Pipe_2_static, Pipe_3_static, Pipe_4_static, Pipe_5_static, Pipe_1_dynamic, Pipe_2_dynamic, Pipe_3_dynamic, Pipe_4_dynamic, Pipe_5_dynamic, Single_Scale, DoubleScale
	};

	public StaticGeometryBasement basementStaticGeo;
	public StaticGeometryMine mineStaticGeo;
	public StaticProps staticProp;
	public PuzzleObjects puzzleObjects;
	
	public GameObject[] basementStaticGeometries;
	public GameObject[] MineStaticGeometries;
	public GameObject[] staticProps;
	public GameObject[] puzzleObjs;

	GameObject currObj;

	[ContextMenu("CreateBasementStaticGeo")]
	void CreateBasementStaticGeo()
	{
		int i = (int)basementStaticGeo;
		currObj = basementStaticGeometries[i];

		for(int x = 0; x < columns; x++){
			float newX = transform.position.x + (currObj.GetComponent<SpriteRenderer>().bounds.extents.x * (x*2));
			for(int y = 0; y < rows; y++){
				float newY = transform.position.y + (currObj.GetComponent<SpriteRenderer>().bounds.extents.y * (y*2));
				Instantiate(currObj, new Vector2(newX, newY), Quaternion.identity);
			}
		}
	}

	[ContextMenu("CreateMineStaticGeo")]
	void CreateMineStaticGeo()
	{
		int i = (int)mineStaticGeo;
		currObj = MineStaticGeometries[i];
		
		for(int x = 0; x < columns; x++){
			float newX = transform.position.x + (currObj.GetComponent<SpriteRenderer>().bounds.extents.x * (x*2));
			for(int y = 0; y < rows; y++){
				float newY = transform.position.y + (currObj.GetComponent<SpriteRenderer>().bounds.extents.y * (y*2));
				Instantiate(currObj, new Vector2(newX, newY), Quaternion.identity);
			}
		}
	}

	[ContextMenu("CreateStaticProp")]
	void CreateStaticProp()
	{
		int i = (int)staticProp;
		currObj = staticProps[i];
		Instantiate(currObj, transform.position, Quaternion.identity);
	}

	[ContextMenu("CreatePuzzlePiece")]
	void CreatePuzzlePiece()
	{
		int i = (int)puzzleObjects;
		currObj = puzzleObjs[i];
		Instantiate(currObj, transform.position, Quaternion.identity);
	}

	void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, 0.5f);
	}
}	