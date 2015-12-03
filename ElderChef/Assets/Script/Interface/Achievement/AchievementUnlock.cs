using UnityEngine;
using System.Collections;

public class AchievementUnlock : MonoBehaviour
{

    public GameObject achievement;

	void Update ()
    {
	    if(PlayerPrefs.GetInt("Panelada") == 3 && PlayerPrefs.GetInt("UnlockPanelator") == 0)
        {
            Unlock("Panelator");
            PlayerPrefs.SetInt("UnlockPanelator", 1);
        }
	}

    void Unlock(string name)
    {
        GameObject obj = Instantiate(achievement) as GameObject;
        obj.gameObject.GetComponent<AchievementInterface>().achiName = name;
    }
}