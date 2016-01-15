using UnityEngine;
using System.Collections;

public class Dagon : MonoBehaviour
{
    public Animator anim;

    public Transform[] save;

    public bool vira;

    void Update()
    {
        if(vira)
        {
            transform.position = new Vector3(save[1].position.x, transform.position.y, transform.position.z);
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
        yield return new WaitForSeconds(0.15f);
        vira = false;
        yield return new WaitForSeconds(0.02f);
        if (PlayerController.player.transform.localScale.x > 0 && transform.localScale.x < 0)
        {
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }
        else if(PlayerController.player.transform.localScale.x < 0 && transform.localScale.x > 0)
        {
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }
        StopCoroutine("GO");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Alimento")
        {
            anim.SetTrigger("Comeu");
        }
    }
}