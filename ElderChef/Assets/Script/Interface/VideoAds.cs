using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;


public class VideoAds : MonoBehaviour
{
    void Start()
    {
        Time.timeScale = 1;
        if (PlayerPrefs.GetInt("Mortes") >= 3)
        {
            StartCoroutine(GO());
        }
    }

    IEnumerator GO()
    {
        yield return new WaitForSeconds(0.5f);
        PlayerPrefs.SetInt("Mortes", 0);
        ShowAd();
    }

    public void ShowAd()
    {
        if (Advertisement.IsReady())
        {
            Advertisement.Show();
        }
    }
}
