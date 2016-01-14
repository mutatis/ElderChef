using UnityEngine;
using System.Collections;

public class PanelaLife : MonoBehaviour
{
    public AudioClip audio;

    public void End()
    {
        gameObject.SetActive(false);
    }
    
    public void Som()
    {
        AudioSource.PlayClipAtPoint(audio, new Vector3(0, 0, -10));
    }
}
