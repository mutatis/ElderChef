using UnityEngine;
using System.Collections;

public class Fogo : MonoBehaviour
{
    public Transform[] save;

    public SpriteRenderer sprite;

    public AudioSource audio;

    public bool vira;

    bool pode;

    void Update()
    {
        if(PlayerController.player.pimenta)
        {
            sprite.enabled = true;
            if (!pode)
            {
                audio.Play();
                pode = true;
            }
        }
        else
        {
            sprite.enabled = false;
            audio.Stop();
            pode = false;
        }

        if (vira)
        {
            transform.position = new Vector3(save[1].position.x, save[1].position.y, transform.position.z);
        }
        else
        {
            transform.position = save[0].position;
        }
    }

    public void Play()
    {
        StartCoroutine("GO");
    }

    IEnumerator GO()
    {
        yield return new WaitForSeconds(0.06f);
        vira = false;
        yield return new WaitForSeconds(0.02f);
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        StopCoroutine("GO");
    }
}