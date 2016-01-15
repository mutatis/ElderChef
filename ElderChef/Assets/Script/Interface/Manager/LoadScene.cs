using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public void Load(string cena)
    {
        SceneManager.LoadScene(cena);
    }

    public void Clico(AudioClip click)
    {
        AudioSource.PlayClipAtPoint(click, Camera.main.transform.position);
    }
}