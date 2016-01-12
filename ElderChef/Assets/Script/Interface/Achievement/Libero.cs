using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Libero : MonoBehaviour
{
    public Image sprite;

    public Text text;

    public Slider sli;

    public string achievementName = "Nome do playerprefs q verifica se libero";
    public string descricao;

    //valor q precisa pra libera;
    public int valorLibera;

    void Start()
    {
        sli.maxValue = valorLibera;
        sli.value = PlayerPrefs.GetInt(achievementName);
        text.text = PlayerPrefs.GetInt(achievementName).ToString() + " / " + valorLibera.ToString();
        if (PlayerPrefs.GetInt(achievementName) >= 3)
        {
            //mostra q libero;
        }
    }

    public void Show()
    {
        MobileNativeDialog msg = new MobileNativeDialog(achievementName, descricao);
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
