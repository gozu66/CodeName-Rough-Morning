using UnityEngine;
using System.Collections;

public class LevelSelect : MonoBehaviour 
{


	public void Load1()
	{
		Application.LoadLevel(1);
	}
	public void Load2()
	{
		Application.LoadLevel(2);
	}
	public void Load3()
	{
		Application.LoadLevel(3);
	}
	public void Load4()
	{
		Application.LoadLevel(4);
	}
	public void Load5()
	{
		Application.LoadLevel(5);
	}
	public void GoBack()
	{
		Application.LoadLevel(0);
	}

//	IEnumerator LoadLevel1()
//	{
//
//	}
//	IEnumerator LoadLevel1()
//	{
//		
//	}
//	IEnumerator LoadLevel1()
//	{
//		
//	}
//	IEnumerator LoadLevel1()
//	{
//		
//	}
//	IEnumerator LoadLevel1()
//	{
//		
//	}
}