using UnityEngine;
using System.Collections;

public class PlayerMovment : MonoBehaviour
{
    public static PlayerMovment player;

    public AudioClip[] mexe;

    public SpriteRenderer sprite;

    public Sprite[] images;

    public Animator anim;
    
    public float velX;

    [HideInInspector]
    public int bloco = 3;

    bool isMov;
    bool pode;

    int nImage;
    int num;

    void Awake()
    {
        player = this;
    }

	void Update ()
    {
        if (!isMov && !pode)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (transform.localScale.x > 0)
                {
                    AudioSource.PlayClipAtPoint(mexe[1], new Vector3(0, 0, -10));
                    anim.SetFloat("Vira", -1);
                    anim.SetTrigger("Esquerda");
                    pode = true;
                }
                else if (bloco > 2)
                {
                    bloco -= 1;
                    num = -1;
                    AudioSource.PlayClipAtPoint(mexe[0], new Vector3(0, 0, -10));
                    StartCoroutine("GO");
                }
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (transform.localScale.x < 0)
                {
                    AudioSource.PlayClipAtPoint(mexe[1], new Vector3(0, 0, -10));
                    anim.SetFloat("Vira", 1);
                    anim.SetTrigger("Direita");
                    pode = true;
                }
                else if (bloco < 5)
                {
                    bloco += 1;
                    num = 1;
                    AudioSource.PlayClipAtPoint(mexe[0], new Vector3(0, 0, -10));
                    StartCoroutine("GO");
                }
            }
        }
    }

    public void ViroDireita()
    {
        pode = false;
        transform.localScale = new Vector3(1.25f, transform.localScale.y, transform.localScale.z);
    }

    public void ViroEsquerda()
    {
        pode = false;
        transform.localScale = new Vector3(-1.25f, transform.localScale.y, transform.localScale.z);
    }

    public void Vira()
    {
        if (transform.localScale.x < 0)
        {
            AudioSource.PlayClipAtPoint(mexe[1], new Vector3(0, 0, -10));
            anim.SetFloat("Vira", 1);
            anim.SetTrigger("Direita");
            pode = true;
        }
        else if (transform.localScale.x > 0)
        {
            AudioSource.PlayClipAtPoint(mexe[1], new Vector3(0, 0, -10));
            anim.SetFloat("Vira", -1);
            anim.SetTrigger("Esquerda");
            pode = true;
        }
    }
    
    public void Esquerda()
    {
        if (!pode)
        {
            /*if (transform.localScale.x > 0)
            {
                AudioSource.PlayClipAtPoint(mexe[1], new Vector3(0, 0, -10));
                anim.SetTrigger("Esquerda");
                pode = true;
            }
            else */if (bloco > 2)
            {
                bloco -= 1;
                num = -1;
                AudioSource.PlayClipAtPoint(mexe[0], new Vector3(0, 0, -10));
                StopCoroutine("GO");
                StartCoroutine("GO");
            }
        }
    }
    
    public void Direita()
    {
        if (!pode)
        {
            AudioSource.PlayClipAtPoint(mexe[1], new Vector3(0, 0, -10));
           /* if (transform.localScale.x < 0)
            {
                anim.SetTrigger("Direita");
                pode = true;
            }
            else*/ if (bloco < 5)
            {
                bloco += 1;
                num = 1;
                AudioSource.PlayClipAtPoint(mexe[0], new Vector3(0, 0, -10));
                StopCoroutine("GO");
                StartCoroutine("GO");
            }
        }
    }

    IEnumerator GO()
    {
        anim.SetBool("Run", true);
        isMov = true;
        for (int i = 0; i < 6; i++)
        {
            transform.Translate((velX * num)/3.5f, 0, 0);
            if (nImage == 0)
            {
                sprite.sprite = images[1];
                nImage = 1;
            }
            else if (nImage == 1)
            {
                sprite.sprite = images[0];
                nImage = 0;
            }
            yield return new WaitForSeconds(0.02f);
        }
        isMov = false;
        anim.SetBool("Run", false);
        StopCoroutine("GO");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Alimento")
        {
            anim.SetTrigger("Fritando");
        }
    }
}