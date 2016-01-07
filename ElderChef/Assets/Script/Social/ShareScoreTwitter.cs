using UnityEngine;
using System.Collections;
using Facebook.Unity;
using System.Collections.Generic;

public class ShareScoreTwitter : MonoBehaviour
{
    public string messagemTwitter;

    public string titulo; //linkname;
    public string textoClaro; //linkcaption;
    public string textoAtencao; //linkdescrition;
    public string linkDaLoja; //link;
    public string foto; //picture;

    void Awake()
    {
            FB.Init();  
    }

    public void Share()
    {
        print("Loggin");

        if(!FB.IsLoggedIn)
        {
            FBLoggin();
        }
        else
        {
            FB.FeedShare(
                            link: new System.Uri(linkDaLoja),
                            linkName: titulo,
                            linkCaption: textoClaro,
                            linkDescription: textoAtencao,
                            picture: new System.Uri(foto)
                        );
        }
    }

    void FBLoggin()
    {
        var perms = new List<string>() { "public_profile", "user_about_me" };
        FB.LogInWithReadPermissions(perms, AuthCallback);
    }

    void AuthCallback(IResult result)
    {
        if(FB.IsLoggedIn)
        {
            print("LOGO");
        }
        else
        {
            print("NAOLOGO");
        }
    }

    public void ShareTwitter()
    {
        Application.OpenURL("https://twitter.com/intent/tweet?text=" + messagemTwitter + " " + GameManager.game.pontos + " pontos!!" + "&amp;lang=eng");
    }
}
