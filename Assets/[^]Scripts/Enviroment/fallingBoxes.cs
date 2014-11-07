using UnityEngine;
using System.Collections;

public class fallingBoxes : MonoBehaviour 
{
	public GameObject fallCube;
	public GameObject[] fallCubes;

	Vector3 spawnPoint1, spawnPoint2, spawnPoint3;

	float timeCounter;
	public float respawnTime = 5;

	void Start()
	{
		spawnPoint1 = fallCubes[0].transform.position;
		spawnPoint2 = fallCubes[1].transform.position;
		spawnPoint3 = fallCubes[2].transform.position;

		//foreach()
	}

	void Update()
	{
		timeCounter += Time.deltaTime;

		if(timeCounter >= respawnTime)
		{
			Respawn();
		}
	}

	void Respawn()
	{
		Instantiate(fallCube, spawnPoint1, Quaternion.identity);
		Instantiate(fallCube, spawnPoint2, Quaternion.identity);
		Instantiate(fallCube, spawnPoint3, Quaternion.identity);

		timeCounter = 0;
	}
}