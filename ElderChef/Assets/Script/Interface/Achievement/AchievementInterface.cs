using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AchievementInterface : MonoBehaviour
{
    public Text text;

    public string achiName;

    void Start()
    {
        text.text = achiName;
    }
}
