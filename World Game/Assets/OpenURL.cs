using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenURL : MonoBehaviour
{
    public Region region;
    private string url;
    private const string goodURL = "https://youtu.be/5xBTViLn8uY?t=33e";
    private const string badURL = "https://www.youtube.com/watch?v=X0DgYTgQu_E&feature=youtu.be";

    public void OpenURLNow()
    {
        if (region.GetQuality() > 0.5f && region.GetStability() > 0.5f)
        {
            Application.OpenURL(goodURL);
        }
        else
        {
            Application.OpenURL(badURL);
        }
    }
}
