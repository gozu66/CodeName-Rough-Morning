using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

public class GatherAnalytics : MonoBehaviour
{
	public InputField playerName;
	public Canvas canvas;
	public bool debugEmail = false;
	public bool debugTxt = false;

	string testerName = "testername";
	string FILE_NAME = "Analytics.txt";
	float timeSpent = 0.0f;
	int deaths = 0;
	int checkpointReached = 0;
	float CP0, CP1, CP2, CP3, CP4, CP5, CP6, CP7, CP8, CP9;
	float CPT0, CPT1, CPT2, CPT3, CPT4, CPT5, CPT6, CPT7, CPT8, CPT9;
	public float telekinesis, projectile, timeslow, nothing;
	public int i;
	int x = 0;

	void Start()
	{
		Time.timeScale = 0;
		i = 0;
	}

	void Update()
	{
		timeSpent += Time.deltaTime;

		if(Time.timeScale == 1)
		{
		if(i == 0)
			nothing += Time.deltaTime;

		if(i == 1)
			telekinesis += Time.deltaTime;

		if(i == 2)
			timeslow += Time.deltaTime;

		if(i == 3)
			projectile += Time.deltaTime ;
		}
		else{

			if(i == 0)
				nothing += Time.deltaTime * 2;
			
			if(i == 1)
				telekinesis += Time.deltaTime * 2;
			
			if(i == 2)
				timeslow += Time.deltaTime * 2;
			
			if(i == 3)
				projectile += Time.deltaTime * 2;
		}

		if(Input.GetKeyDown(KeyCode.Tab))
		{
			WriteTxt();
			SendMail();

		}


	}

	void SetName()
	{
		testerName = playerName.text.text;
		canvas.enabled = false;
		Time.timeScale = 1.0f;
	}

	void SendMail ()
	{
		debugEmail = false;
		if(debugEmail)
		{
			MailMessage mail = new MailMessage();

			mail.From = new MailAddress("codenameroughmorning@gmail.com");
			mail.To.Add("codenameroughmorning@gmail.com");
			mail.To.Add("gozu66@gmail.com");
			mail.Subject = testerName + " @ " + System.DateTime.Now;


			mail.Body = timeSpent.ToString() + " seconds spent in level" + "\n" +deaths + " Times died overall" + "\n" + checkpointReached + " checkpoints passed" + "\n" 
				+ "Time to checkpoint 0 : " + CPT0 + "\n" + "Time to checkpoint 1 : " + CPT1 + "\n" + "Time to checkpoint 2 : " + CPT2 + "\n" +"Time to checkpoint 3 : " + CPT3 + "\n" +"Time to checkpoint 4 : " + CPT4 + "\n" +"Time to checkpoint 5 : " + CPT5 + "\n" +
					"Time to checkpoint 6 : " + CPT6 + "\n" +"Time to checkpoint 7 : " + CPT7 + "\n" +"Time to checkpoint 8 : " + CPT8 + "\n" +"Time to checkpoint 9 : " + CPT9 + "\n"
						+ "Deaths at Checkpoint 0 : " + CP0 + "\n" + "Deaths at Checkpoint 1 : " + CP1 + "\n" +  "Deaths at Checkpoint 2 : " + CP2 + "\n" +  "Deaths at Checkpoint 3 : " + CP3 + "\n" + "Deaths at Checkpoint 4 : " + CP4 + "\n" + "Deaths at Checkpoint 5 : " + CP5 +
							"\n" + "Deaths at Checkpoint 6 : " + CP6 + "\n" + "Deaths at Checkpoint 7 : " + CP7 + "\n" + "Deaths at Checkpoint 8 : " + CP8 + "\n" + "Deaths at Checkpoint 9 : " + CP9 + "\n" + "Time spent with nothing selected : " + nothing + "\n" + "Time spent with Telekinesis selected : "
								+ telekinesis + "\n" + "Time spent with Projectiles selected : " + projectile + "\n" + "Time spent with Time slow selected : " + timeslow;


			SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");
			smtpServer.Port = 587;
			smtpServer.Credentials = new System.Net.NetworkCredential("codenameroughmorning@gmail.com", "codenameroughmorning00") as ICredentialsByHost;
			smtpServer.EnableSsl = true;
			ServicePointManager.ServerCertificateValidationCallback = 
			delegate(object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) 
			{ 
				return true; 
			};
			smtpServer.Send(mail);
			Debug.Log("success");
		}
		else{
			return;
		}
	}

	void AddDeath()
	{
		deaths++;
		DeathAtCheckpoint();
	}
	void AddCheckpoint()
	{
		checkpointReached++;
		if(checkpointReached == 0)
		{
			CPT0 = timeSpent;
		}
		
		if(checkpointReached == 1)
		{
			CPT1 = timeSpent;
		}
		
		if(checkpointReached == 2)
		{
			CPT2 = timeSpent;
		}
		
		if(checkpointReached == 3)
		{
			CPT3 = timeSpent;
		}
		
		if(checkpointReached == 4)
		{
			CPT4 = timeSpent;
		}
		
		if(checkpointReached == 5)
		{
			CPT5 = timeSpent;
		}
		
		if(checkpointReached == 6)
		{
			CPT6 = timeSpent;
		}
		
		if(checkpointReached == 7)
		{
			CPT7 = timeSpent;
		}
		
		if(checkpointReached == 8)
		{
			CPT8 = timeSpent;
		}
		
		if(checkpointReached == 9)
		{
			CPT9 = timeSpent;
		}
	}
	void DeathAtCheckpoint()
	{
		if(checkpointReached == 0)
		{
			CP0++;
		}
		
		if(checkpointReached == 1)
		{
			CP1++;
		}
		
		if(checkpointReached == 2)
		{
			CP2++;
		}
		
		if(checkpointReached == 3)
		{
			CP3++;
		}
		
		if(checkpointReached == 4)
		{
			CP4++;
		}
		
		if(checkpointReached == 5)
		{
			CP5++;
		}
		
		if(checkpointReached == 6)
		{
			CP6++;
		}
		
		if(checkpointReached == 7)
		{
			CP7++;
		}
		
		if(checkpointReached == 8)
		{
			CP8++;
		}
		
		if(checkpointReached == 9)
		{
			CP9++;
		}
	}

	void WriteTxt()
	{
		debugTxt = false;
		if(debugTxt)
		{
			StreamWriter sr = File.CreateText(testerName + FILE_NAME);
	//		sr.WriteLine(timeSpent.ToString() + " seconds spent in level   " + "\n" +deaths + " Times died overall   " + "\n" + checkpointReached + " checkpoints passed   " + "\n" 
	//		             + "Time to checkpoint 0 : " + CPT0 + "\n" + "   Time to checkpoint 1 : " + CPT1 + "\n" + "   Time to checkpoint 2 : " + CPT2 + "\n" +"   Time to checkpoint 3 : " + CPT3 + "\n" +"   Time to checkpoint 4 : " + CPT4 + "\n" +"   Time to checkpoint 5 : " + CPT5 + "\n" +
	//		             "   Time to checkpoint 6 : " + CPT6 + "\n" +"   Time to checkpoint 7 : " + CPT7 + "\n" +"   Time to checkpoint 8 : " + CPT8 + "\n" +"   Time to checkpoint 9 : " + CPT9 + "\n"
	//		             + "   Deaths at Checkpoint 0 : " + CP0 + "\n" + "   Deaths at Checkpoint 1 : " + CP1 + "\n" +  "   Deaths at Checkpoint 2 : " + CP2 + "\n" +  "   Deaths at Checkpoint 3 : " + CP3 + "\n" + "   Deaths at Checkpoint 4 : " + CP4 + "\n" + "   Deaths at Checkpoint 5 : " + CP5 +
	//		             "\n" + "   Deaths at Checkpoint 6 : " + CP6 + "\n" + "   Deaths at Checkpoint 7 : " + CP7 + "\n" + "   Deaths at Checkpoint 8 : " + CP8 + "\n" + "   Deaths at Checkpoint 9 : " + CP9 + "\n" + "   Time spent with nothing selected : " + nothing + "\n" + "   Time spent with Telekinesis selected : "
	//		             + telekinesis + "\n" + "   Time spent with Projectiles selected : " + projectile + "\n" + "   Time spent with Time slow selected : " + timeslow);

			sr.WriteLine(timeSpent.ToString() + " seconds spent in level");
			sr.WriteLine(deaths + " Times died overall");
			sr.WriteLine(checkpointReached + " checkpoints passed ");
			sr.WriteLine("Time to checkpoint 0 : " + CPT0);
				sr.WriteLine("Time to checkpoint 1 : " + CPT1);
					sr.WriteLine("Time to checkpoint 2 : " + CPT2);
						sr.WriteLine("Time to checkpoint 3 : " + CPT3);
							sr.WriteLine("Time to checkpoint 4 : " + CPT4);
								sr.WriteLine("Time to checkpoint 5 : " + CPT5);
									sr.WriteLine("Time to checkpoint 6 : " + CPT6);
										sr.WriteLine("Time to checkpoint 7 : " + CPT7);
											sr.WriteLine("Time to checkpoint 8 : " + CPT8);
												sr.WriteLine("Time to checkpoint 9 : " + CPT9);
			sr.WriteLine("Deaths at Checkpoint 0 : " + CP0);
				sr.WriteLine("Deaths at Checkpoint 1 : " + CP1);
					sr.WriteLine("Deaths at Checkpoint 2 : " + CP2);
						sr.WriteLine("Deaths at Checkpoint 3 : " + CP3);
							sr.WriteLine("Deaths at Checkpoint 4 : " + CP4);
								sr.WriteLine("Deaths at Checkpoint 5 : " + CP5);
									sr.WriteLine("Deaths at Checkpoint 6 : " + CP6);
										sr.WriteLine("Deaths at Checkpoint 7 : " + CP7);
											sr.WriteLine("Deaths at Checkpoint 8 : " + CP8);
												sr.WriteLine("Deaths at Checkpoint 9 : " + CP9);
			sr.WriteLine("Time spent with nothing selected : " + nothing);
			sr.WriteLine("Time spent with Telekinesis selected : " + telekinesis);
			sr.WriteLine("Time spent with Projectiles selected : " + projectile);
			sr.WriteLine("Time spent with Time slow selected : " + timeslow);
			sr.Close();
		}
	}

	void WeaponTimer(int x)
	{
		i = x;
	}
}