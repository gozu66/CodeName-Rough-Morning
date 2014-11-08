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
	public float timeSpent;
	public string testerName = "testerName";

	public InputField playerName;
	public Canvas canvas;

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
		MailMessage mail = new MailMessage();

		mail.From = new MailAddress("codenameroughmorning@gmail.com");
		mail.To.Add("codenameroughmorning@gmail.com");
		mail.To.Add("gozu66@gmail.com");
		mail.Subject = testerName + " @ " + System.DateTime.Now;
		mail.Body = timeSpent.ToString() + " seconds spent in level";

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

}