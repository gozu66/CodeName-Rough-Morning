using UnityEngine;
using System.Collections;

public class MindBullets : MonoBehaviour 
{
	public enum fireType {semiAuto, fullAuto, Grenade};
	public fireType currFireType;

	public float SA_fireRate, SA_force, FA_fireRate, FA_force, G_fireRate, G_force;

	bool isTrigger;

	public float ammo, G_ammo;

	public GameObject plasmaBullet, plasmaGrenade;

	void Start()
	{
		currFireType = fireType.semiAuto;

		ammo = 50;

		isTrigger = false;
	}

	void Update()
	{
		semiAutoUpdate();

		if(ammo < 50)
		{
			ammo += Time.deltaTime/3;
		}
	}

	void semiAutoUpdate()
	{
		if(ammo > 0)
		{
			if(!isTrigger)
			{
				if(Input.GetAxisRaw("RTrigger_1") != 0 || Input.GetMouseButtonDown(0))
				{
					GameObject newBullet = Instantiate(plasmaBullet, transform.position, transform.rotation)as GameObject;
					Vector3 shootVector = new Vector3(transform.right.x * transform.parent.localScale.x, transform.right.y, transform.right.z);
					newBullet.rigidbody2D.AddForce(shootVector * (SA_force*1000));
					ammo--;
					isTrigger = true;
					CameraShake.instance.CamKick(shootVector);
					LogUse();
				}
			}	
			else 
			{
				if(Input.GetAxisRaw("RTrigger_1") == 0)
					isTrigger = false;					
			}

			if(Telekinesis.isHolding)
					isTrigger = true;				
		}
	}

	public static int timesUsedMB;
	void LogUse()
	{
		timesUsedMB++;
	}
}
