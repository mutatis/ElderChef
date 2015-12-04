using UnityEngine;
using System.Collections;

public class Libero : MonoBehaviour
{
    public SpriteRenderer sprite;

    public string achievementName = "Unlock";

    void Start()
    {
        if(PlayerPrefs.GetInt(achievementName) == 1)
        {
            sprite.color = Color.white;
        }
    }
}
