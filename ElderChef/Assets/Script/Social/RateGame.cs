using UnityEngine;
using System.Collections;

public class RateGame : MonoBehaviour
{

    public string apdroidAppUrl;
    public string appleId;

    void Start ()
    {
        if (PlayerPrefs.GetInt("Mortes") >= 15)
        {
            Rate();
            PlayerPrefs.SetInt("Mortes", 0);
        }
        else
        {
            PlayerPrefs.SetInt("Mortes", PlayerPrefs.GetInt("Mortes") + 1);
        }
    }

    void Rate()
    {
        MobileNativeRateUs ratePopUp = new MobileNativeRateUs("Like this game?", "Please rate to support future updates!");

#if UNITY_ANDROID
        ratePopUp.SetAndroidAppUrl(apdroidAppUrl);
#endif

#if UNITY_IOS
            ratePopUp.SetAppleId(appleId);
#endif

        ratePopUp.Start();
    }

    private void OnRatePopUpClose(MNDialogResult result)
    {
        //parsing result
        switch (result)
        {
            case MNDialogResult.RATED:
                PlayerPrefs.SetInt("Rate", 1);
                break;
            case MNDialogResult.REMIND:
                Debug.Log("Remind Option picked");
                break;
            case MNDialogResult.DECLINED:
                Debug.Log("Declined Option picked");
                break;
        }
    }
}
