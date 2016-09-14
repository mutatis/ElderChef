using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TapStart : MonoBehaviour
{

    void Start()
    {
        Time.timeScale = 0;
    }

    public void Clico(AudioClip click)
    {
        AudioSource.PlayClipAtPoint(click, Camera.main.transform.position);
    }

    public void Click(GameObject obj)
    {
        Time.timeScale = 1;
        PlayerPrefs.SetInt("Jogadas", PlayerPrefs.GetInt("Jogadas") + 1);
        Destroy(obj);
    }
}