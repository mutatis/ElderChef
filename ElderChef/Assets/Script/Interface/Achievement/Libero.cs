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
        MobileNativeDialog msg = new MobileNativeDialog(title, descricao);
        msg.OnComplete += OnDialogClose;
    }

    private void OnDialogClose(MNDialogResult result)
    {
        //parsing result
        switch (result)
        {
            case MNDialogResult.YES:
                Application.OpenURL("https://unionassets.com/mobile-native-popups/showing-dialog-pop-up-58");
                break;
            case MNDialogResult.NO:
                Debug.Log("No button pressed");
                break;
        }
    }
}
