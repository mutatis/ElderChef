using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShareScoreTwitter : MonoBehaviour
{
    public string messagemTwitter;

    public string AppID = "1399925576886522";
    public string Link = "https://play.google.com/store/apps/developer?id=Gamestoodio";
    public string Picture = "http://imageshack.us/scaled/landing/843/gh4o.png";
    public string Name = "My New Score";
    public string Caption = "I just got +99 score friends! Can you beat it?";
    public string Description = "Enjoy fun, free games! Challenge yourself or share with friends. Fun and easy-to-use game.";

    public void Share()
    {
        Application.OpenURL("https://www.facebook.com/dialog/feed?" + "app_id=" + AppID + "&link=" +
                            Link + "&picture=" + Picture + "&name=" + ReplaceSpace(Name) + "&caption=" +
                            ReplaceSpace(Caption) + "&description=" + ReplaceSpace(Description) +
                            "&redirect_uri=https://facebook.com/");
    }

    string ReplaceSpace(string val)
    {
        return val.Replace(" ", "%20");
    }

    public void ShareTwitter()
    {
        Application.OpenURL("https://twitter.com/intent/tweet?text=" + messagemTwitter + " " + GameManager.game.pontos + " pontos!!" + "&amp;lang=eng");
    }
}
