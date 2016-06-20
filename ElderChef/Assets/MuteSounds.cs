using UnityEngine;
using System.Collections;

public class MuteSounds : MonoBehaviour
{
    public void Music()
    {
        if(PlayerPrefs.GetInt("Music") == 0)
        {
            PlayerPrefs.SetInt("Music", 1);
            Camera.main.GetComponent<AudioSource>().Stop();
        }
        else
        {
            PlayerPrefs.SetInt("Music", 0);
            Camera.main.GetComponent<AudioSource>().Play();
        }
    }
}
