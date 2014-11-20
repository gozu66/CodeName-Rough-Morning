using UnityEngine;
using System.Collections;

public class weaponManager : MonoBehaviour 
{
	public enum Weapon {NoWeapon, gravityGun, timeGun, plasmaGun};		//	
	public Weapon weaponType;											//	enum for Weapon state public enum
	Weapon highlightedWeaponType;										//

	public GameObject gravGunSprite, TimeGunSprite, PlasmaGunSprite;	//	sprite Game Objects
																		
	gravityGun gravGun;													//
	timeGun TimeGun;													// 	references for 
	playerAim reticule;													//	weapon scripts
	plasmaGun plasGun;													//

	TimeManager TM;														// referece for time manager

	public static bool weaponWheelActive;

	public GUISkin weaponManagerSkin;

	public GameObject anaNode;		//ANALYTICS 

	void Start()
	{
		TM = transform.parent.GetComponent<TimeManager>();

		gravGun = GetComponent<gravityGun>();
		TimeGun = GetComponent<timeGun>();
		reticule = GetComponent<playerAim>();
		plasGun = GetComponent<plasmaGun>();

		selectWeapon(Weapon.NoWeapon);
	}

	public void selectWeapon(Weapon chosenWeapon)
	{
		weaponType = chosenWeapon;

		switch(weaponType)
		{
			case Weapon.NoWeapon:
				selectWeaponSwitch(Weapon.NoWeapon);
				break;
		
			case Weapon.gravityGun:
				selectWeaponSwitch(Weapon.gravityGun);
				break;

			case Weapon.timeGun:
				selectWeaponSwitch(Weapon.timeGun);
				break;

			case Weapon.plasmaGun:
				selectWeaponSwitch(Weapon.plasmaGun);
				break;
				
			default:
					Debug.Log("whatchu talking bout willis");
					break;
		}
	}

	void switchWeapon(bool rendr, bool gravguntimegun, bool TGun, bool retic ,bool GGsprite, bool TGsprite, bool Pgun, bool PgunSprite)
	{
		renderer.enabled = rendr;
		gravGun.enabled = gravguntimegun;
		TimeGun.enabled = TGun;
		reticule.enabled = retic;
		gravGunSprite.renderer.enabled = GGsprite;
		TimeGunSprite.renderer.enabled = TGsprite;
		plasGun.enabled = Pgun;
		PlasmaGunSprite.renderer.enabled = PgunSprite;
	}

	void Update()
	{
/*		if(Input.GetButton("RB_1"))
		{
			weaponWheelActive = true;

			//Debug.Log(Input.GetAxis("R_XAxis_1"));

				if(Input.GetAxis("R_YAxis_1") <= -0.9f)
				{
					highlightedWeaponType = Weapon.gravityGun;
				}
				if(Input.GetAxis("R_XAxis_1") >= 0.9f)
				{
					highlightedWeaponType = Weapon.plasmaGun;
				}
				if(Input.GetAxis("R_XAxis_1") <= -0.9f)
				{
					highlightedWeaponType = Weapon.timeGun;
				}

		}
		else 
			{	weaponWheelActive = false;	}


		if(Input.GetButtonUp("RB_1"))
			selectWeapon(highlightedWeaponType);
																*/


		//Debug.Log(Input.GetButtonDown("DPad_D_1"));

		if(Input.GetAxisRaw("DPad_XAxis_1") != 0)
		{
			if(Input.GetAxisRaw("DPad_XAxis_1") > 0)
				selectWeapon(Weapon.gravityGun);
			else
				selectWeapon(Weapon.plasmaGun);
		}
		if(Input.GetAxisRaw("DPad_YAxis_1") != 0)
		{
			if(Input.GetAxisRaw("DPad_YAxis_1") > 0)
				selectWeapon(Weapon.timeGun);
			else
				selectWeapon(Weapon.NoWeapon);
		}	

	}

	void selectWeaponSwitch(Weapon w)
	{
		if(w == Weapon.NoWeapon)
		{
			switchWeapon(false, false, false, false, false, false, false, false);
			anaNode.SendMessage("WeaponTimer", 0, SendMessageOptions.DontRequireReceiver);		//ANALYTICS 
		}
		if(w == Weapon.gravityGun)
		{
			switchWeapon(true, true, false, true, true, false, false, false);
			anaNode.SendMessage("WeaponTimer", 1, SendMessageOptions.DontRequireReceiver);		//ANALYTICS 
		}
		if(w == Weapon.timeGun)
		{
			switchWeapon(false, false, true, false, false, true, false, false);
			anaNode.SendMessage("WeaponTimer", 2, SendMessageOptions.DontRequireReceiver);		//ANALYTICS 
		}
		if(w == Weapon.plasmaGun)
		{
			switchWeapon(true, false, false, true, false, false, true, true);
			anaNode.SendMessage("WeaponTimer", 3, SendMessageOptions.DontRequireReceiver);		//ANALYTICS 
		}
	}

	void OnGUI()
	{
		GUI.skin = weaponManagerSkin;

		if(weaponWheelActive)
		{
			GUI.Box(new Rect(Screen.width/2 - (Screen.width/16), (Screen.height/2 - (Screen.height/32)) - Screen.height/16, Screen.width/8, Screen.height/16), "gravity gun");
			GUI.Box(new Rect((Screen.width/2 - (Screen.width/16) - Screen.width/8), (Screen.height/2 - (Screen.height/32)) + Screen.height/16, Screen.width/8, Screen.height/16), "time gun");
			GUI.Box(new Rect((Screen.width/2 - (Screen.width/16) + Screen.width/8), (Screen.height/2 - (Screen.height/32)) + Screen.height/16, Screen.width/8, Screen.height/16), "plasma gun");
		}
	}
}