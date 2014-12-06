using UnityEngine;
using System.Collections;

public class weaponManager : MonoBehaviour 
{
	public enum Weapon {NoWeapon, Telekinesis, TimeSlow, MindBullets};		//	
	public Weapon weaponType;											//	enum for Weapon state public enum
	Weapon highlightedWeaponType;										//

	public GameObject TeleKSprite, TimeSlowSprite, PlasmaGunSprite;	//	sprite Game Objects
																		
	Telekinesis TeleK;													//
	TimeSlow TimeSlow;													// 	references for 
	playerAim reticule;													//	weapon scripts
	MindBullets MindBullets;													//

	TimeManager TM;														// referece for time manager

	public static bool weaponWheelActive;

	public GUISkin weaponManagerSkin;

	public GameObject anaNode;		//ANALYTICS 

	void Start()
	{
		TM = transform.parent.GetComponent<TimeManager>();

		TeleK = GetComponent<Telekinesis>();
		TimeSlow = GetComponent<TimeSlow>();
		reticule = GetComponent<playerAim>();
		MindBullets = GetComponent<MindBullets>();

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
		
			case Weapon.Telekinesis:
				selectWeaponSwitch(Weapon.Telekinesis);
				break;

			case Weapon.TimeSlow:
				selectWeaponSwitch(Weapon.TimeSlow);
				break;

			case Weapon.MindBullets:
				selectWeaponSwitch(Weapon.MindBullets);
				break;
				
			default:
					Debug.Log("whatchu talking bout willis");
					break;
		}
	}

	void switchWeapon(bool rendr, bool gravgunTimeSlow, bool TGun, bool retic ,bool GGsprite, bool TGsprite, bool Pgun, bool PgunSprite)
	{
		renderer.enabled = rendr;
		TeleK.enabled = gravgunTimeSlow;
		TimeSlow.enabled = TGun;
		reticule.enabled = retic;
		TeleKSprite.renderer.enabled = GGsprite;
		TimeSlowSprite.renderer.enabled = TGsprite;
		MindBullets.enabled = Pgun;
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
					highlightedWeaponType = Weapon.Telekinesis;
				}
				if(Input.GetAxis("R_XAxis_1") >= 0.9f)
				{
					highlightedWeaponType = Weapon.MindBullets;
				}
				if(Input.GetAxis("R_XAxis_1") <= -0.9f)
				{
					highlightedWeaponType = Weapon.TimeSlow;
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
				selectWeapon(Weapon.Telekinesis);
			else
				selectWeapon(Weapon.MindBullets);
		}
		if(Input.GetAxisRaw("DPad_YAxis_1") != 0)
		{
			if(Input.GetAxisRaw("DPad_YAxis_1") > 0)
				selectWeapon(Weapon.TimeSlow);
			else
				selectWeapon(Weapon.NoWeapon);
		}	

	}

	void selectWeaponSwitch(Weapon w)
	{
		if(w == Weapon.NoWeapon)
		{
			switchWeapon(false, false, false, false, false, false, false, false);
			//anaNode.SendMessage("WeaponTimer", 0, SendMessageOptions.DontRequireReceiver);		//ANALYTICS 
		}
		if(w == Weapon.Telekinesis)
		{
			switchWeapon(true, true, false, true, true, false, false, false);
			//anaNode.SendMessage("WeaponTimer", 1, SendMessageOptions.DontRequireReceiver);		//ANALYTICS 
		}
		if(w == Weapon.TimeSlow)
		{
			switchWeapon(false, false, true, false, false, true, false, false);
			//anaNode.SendMessage("WeaponTimer", 2, SendMessageOptions.DontRequireReceiver);		//ANALYTICS 
		}
		if(w == Weapon.MindBullets)
		{
			switchWeapon(true, false, false, true, false, false, true, true);
			//anaNode.SendMessage("WeaponTimer", 3, SendMessageOptions.DontRequireReceiver);		//ANALYTICS 
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