﻿using UnityEngine;
using System.Collections;

public class plasmaGun : MonoBehaviour 
{
	public enum fireType {semiAuto, fullAuto, Grenade};
	public fireType currFireType;


	public float SA_fireRate, SA_force, FA_fireRate, FA_force, G_fireRate, G_force;
	float SA_fireCooldown = 0, FA_fireCooldown, G_fireCooldown;
	bool isTrigger;

	public float ammo, G_ammo;

	public GameObject plasmaBullet, plasmaGrenade;

	public GUISkin mySkin;

	void Start()
	{
		currFireType = fireType.semiAuto;

		FA_fireCooldown = FA_fireRate;
		G_fireCooldown = G_fireRate;
		SA_fireCooldown = SA_fireRate;


		ammo = 50;
	}

	void Update()
	{
		switch(currFireType)
		{
			case fireType.semiAuto:
				//Debug.Log("SA");
				semiAutoUpdate();
				break;

			case fireType.fullAuto:
				//Debug.Log("FA");
				fulAutoUpdate();
				break;

			case fireType.Grenade:
				grenadeUpdate();
				break;

			default:
				Debug.Log("__");
				break;
		}

		if(Input.GetButtonDown("X_1"))
		{
			if(currFireType == fireType.semiAuto)
			currFireType = fireType.fullAuto;

				else if(currFireType == fireType.fullAuto)
					currFireType = fireType.Grenade;

					else if(currFireType == fireType.Grenade)
						currFireType = fireType.semiAuto;
		}
	}

	void semiAutoUpdate()
	{
		if(ammo > 0)
		{
		/*	if(Input.GetAxis("Triggers_1") <= -0.1f && SA_fireCooldown >= SA_fireRate)
			{
				GameObject newBullet = Instantiate(plasmaBullet, transform.position, transform.rotation)as GameObject;
				newBullet.rigidbody2D.AddForce(new Vector3 (transform.right.x * transform.parent.localScale.x, transform.right.y, transform.right.z) * (SA_force*1000));
				ammo--;
				SA_fireCooldown = 0;
			}
			
			if(SA_fireCooldown < SA_fireRate)
			{
				SA_fireCooldown += (Time.deltaTime) / Time.timeScale;
			}	*/

			//isTrigger = false;

			if(!isTrigger)
			{
				if(Input.GetAxisRaw("Triggers_1") <= -0.9)
				{
					GameObject newBullet = Instantiate(plasmaBullet, transform.position, transform.rotation)as GameObject;
					newBullet.rigidbody2D.AddForce(new Vector3 (transform.right.x * transform.parent.localScale.x, transform.right.y, transform.right.z) * (SA_force*1000));
					ammo--;
					SA_fireCooldown = 0;
					isTrigger = true;
				}
			}	else {
				{
					if(Input.GetAxisRaw("Triggers_1") >= 0)
						isTrigger = false;
				}
			}

			//Debug.Log(Input.GetAxisRaw("Triggers_1"));
		}
	}

	void fulAutoUpdate()
	{
		if(ammo > 0)
		{
				if(Input.GetAxis("Triggers_1") <= -0.1f && FA_fireCooldown >= FA_fireRate)
				{
					GameObject newBullet = Instantiate(plasmaBullet, transform.position, transform.rotation)as GameObject;
					newBullet.rigidbody2D.AddForce(new Vector3 (transform.right.x * transform.parent.localScale.x, transform.right.y, transform.right.z) * (FA_force*1000));
					ammo--;
					FA_fireCooldown = 0;
				}
				
				if(FA_fireCooldown < FA_fireRate)
				{
					FA_fireCooldown += (Time.deltaTime) / Time.timeScale;
				}
		}
	}

	void grenadeUpdate()
	{
		if(Input.GetAxis("Triggers_1") <= -0.1f && G_fireCooldown >= G_fireRate)
		{
			GameObject newBullet = Instantiate(plasmaGrenade, transform.position, transform.rotation)as GameObject;
			newBullet.rigidbody2D.AddForce(new Vector3 (transform.right.x * transform.parent.localScale.x, transform.right.y, transform.right.z) * (G_force*1000));
			G_ammo--;
			G_fireCooldown = 0;
		}
		
		if(G_fireCooldown < G_fireRate)
		{
			G_fireCooldown += (Time.deltaTime) / Time.timeScale;
		}

	}

	void OnGUI()
	{
		GUI.skin = mySkin;

		switch(currFireType)
		{
		case fireType.semiAuto:
			GUI.Box(new Rect(25, 5, 100, 50),"Ammo\n "+ammo);
			GUI.Box(new Rect(150, 5, 100, 50),"Semi Auto\nX");
			break;
			
		case fireType.fullAuto:
			GUI.Box(new Rect(25, 5, 100, 50),"Ammo\n "+ammo);
			GUI.Box(new Rect(150, 5, 100, 50),"Full Auto\nX");
			break;

		case fireType.Grenade:
			GUI.Box(new Rect(25, 5, 100, 50),"Ammo\n "+G_ammo);
			GUI.Box(new Rect(150, 5, 100, 50),"Grenade\nX");
			break;
			
		default:
			Debug.Log("__");
			break;
		}

	}
}
