using UnityEngine;
using System.Collections;

public class SoundController : MonoBehaviour
{
	void Start ()
    {
        if (PlayerPrefs.GetInt("Music") == 1)
        {
            gameObject.GetComponent<AudioSource>().Stop();
        }
	}
}
