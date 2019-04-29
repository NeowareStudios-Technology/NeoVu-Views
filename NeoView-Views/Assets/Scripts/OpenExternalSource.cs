using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenExternalSource : MonoBehaviour
{
    public void OpenLink(string link)
	{
		Application.OpenURL(link);
	}

	    public void OpenLinkInApp(string link)
	{
		InAppBrowser.OpenURL(link);
	}

    public void OpenFacebookPage(string id, string url)
	{
		float startTime;
		startTime = Time.timeSinceLevelLoad;

		// open the facebook app in IOS
		Application.OpenURL("fb://page/?id=" + id);
		// open the facebook app in Andorid
		Application.OpenURL ("fb://page/" + id);

		if (Time.timeSinceLevelLoad - startTime <= 1f)
		{
			//fail. Open safari.
			Application.OpenURL(url);
		}
	}

    public void SendEmail(string address, string subjectString, string bodyString)
    {
        string subject = MyEscapeURL(subjectString);
        string body = MyEscapeURL(bodyString);
        
        Application.OpenURL ("mailto:" + address + "?subject=" + subject + "&body=" + body);
    }  

    string MyEscapeURL(string url)
    {
        return WWW.EscapeURL(url).Replace("+","%20");
    }
}
