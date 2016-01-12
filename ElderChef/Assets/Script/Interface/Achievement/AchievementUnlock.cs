using UnityEngine;
using System.Collections;

public class AchievementUnlock : MonoBehaviour
{

    public GameObject achievement;

	void Update ()
    {
	    if(PlayerPrefs.GetInt("Panelator") == 3 && PlayerPrefs.GetInt("UnlockPanelator") == 0)
        {
            Unlock("Panelator");
            PlayerPrefs.SetInt("UnlockPanelator", 1);
        }
        else if (PlayerPrefs.GetInt("Ovo") == 50 && PlayerPrefs.GetInt("UnlockOvo") == 0)
        {
            Unlock("Ovo");
            PlayerPrefs.SetInt("UnlockOvo", 1);
        }
    }

    void Unlock(string name)
    {
        GameObject obj = Instantiate(achievement) as GameObject;
        obj.gameObject.GetComponent<AchievementInterface>().achiName = name;
    }
}