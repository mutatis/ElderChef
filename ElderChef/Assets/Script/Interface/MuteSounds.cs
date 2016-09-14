using UnityEngine;
using System.Collections;

public class MuteSounds : MonoBehaviour
{
    public GameObject obj;

    void Start()
    {
        if(PlayerPrefs.GetInt("Music") == 0)
            obj.SetActive(false);
        else
            obj.SetActive(true);
    }

    public void Music()
    {
        if(PlayerPrefs.GetInt("Music") == 0)
        {
            PlayerPrefs.SetInt("Music", 1);
            Camera.main.GetComponent<AudioSource>().Stop();
            obj.SetActive(true);
        }
        else
        {
            PlayerPrefs.SetInt("Music", 0);
            Camera.main.GetComponent<AudioSource>().Play();
            obj.SetActive(false);
        }
    }
}
