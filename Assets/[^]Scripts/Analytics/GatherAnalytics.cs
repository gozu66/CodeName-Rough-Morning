using UnityEngine;
using UnityEngine.UI;
using System.Collections;
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
	public bool debugEmail;

	string testerName = "testername";
	float timeSpent = 0.0f;
	int deaths = 0;
	int checkpointReached = 0;
	float CP0, CP1, CP2, CP3, CP4, CP5, CP6, CP7, CP8, CP9;

	void Start()
	{
		Time.timeScale = 0;
	}

	void Update()
	{
		timeSpent += Time.deltaTime * Time.timeScale;

		if(Input.GetMouseButton(1))
		{
			SendMail();
		}
	}
	void OnApplicationQuit()
	{
		/*
		StreamWriter sr = File.CreateText(FILE_NAME);
		sr.WriteLine(timeSpent + "s spent in level");
			sr.Close();
		*/

		SendMail();
	}

	void SetName()
	{
		testerName = playerName.text.text;
		canvas.enabled = false;
		Time.timeScale = 1.0f;
	}

	void SendMail ()
	{
		if(debugEmail)
		{
			MailMessage mail = new MailMessage();

			mail.From = new MailAddress("codenameroughmorning@gmail.com");
			mail.To.Add("codenameroughmorning@gmail.com");
			mail.To.Add("gozu66@gmail.com");
			mail.Subject = testerName + " @ " + System.DateTime.Now;


			mail.Body = timeSpent.ToString() + " seconds spent in level" + "\n" +deaths + " Times died overall" + "\n" + checkpointReached + " checkpoints passed" + "\n" 
				+ "Deths at Checkpoint 0 : " + CP0 + "\n" + "Deths at Checkpoint 1 : " + CP1 + "\n" +  "Deths at Checkpoint 2 : " + CP2 + "\n" +  "Deths at Checkpoint 3 : " + CP3 + "\n" + "Deths at Checkpoint 4 : " + CP4 + "\n" + "Deths at Checkpoint 5 : " + CP5 +
					"\n" + "Deths at Checkpoint 6 : " + CP6 + "\n" + "Deths at Checkpoint 7 : " + CP7 + "\n" + "Deths at Checkpoint 8 : " + CP8 + "\n" + "Deths at Checkpoint 9 : " + CP9;


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
	}
	void DeathAtCheckpoint()
	{
		if(checkpointReached == 0)
			CP0++;
		
		if(checkpointReached == 1)
			CP1++;
		
		if(checkpointReached == 2)
			CP2++;
		
		if(checkpointReached == 3)
			CP3++;
		
		if(checkpointReached == 4)
			CP4++;
		
		if(checkpointReached == 5)
			CP5++;
		
		if(checkpointReached == 6)
			CP6++;
		
		if(checkpointReached == 7)
			CP7++;
		
		if(checkpointReached == 8)
			CP8++;
		
		if(checkpointReached == 9)
			CP9++;
	}

}