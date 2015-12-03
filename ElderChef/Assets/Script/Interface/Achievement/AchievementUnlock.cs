using UnityEngine;
using System.Collections;

public class AchievementUnlock : MonoBehaviour
{

    public GameObject achievement;

	void Update ()
    {
	    if(Input.GetKeyDown(KeyCode.Space))
        {
            Unlock("GGGGGG");
        }
	}

    void Unlock(string name)
    {
        GameObject obj = Instantiate(achievement) as GameObject;
        obj.gameObject.GetComponent<AchievementInterface>().achiName = name;
    }
}