using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Libero : MonoBehaviour
{
    public Image sprite;

    public string achievementName = "Unlock";
    public string title;
    public string descricao;

    void Start()
    {
        if(PlayerPrefs.GetInt(achievementName) == 1)
        {
            sprite.color = Color.white;
        }
    }

    public void Show()
    {
        MobileNativeMessage msg = new MobileNativeMessage(title, descricao);
    }
}
