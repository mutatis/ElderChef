using UnityEngine;
using System.Collections;

public class PlayerMovment : MonoBehaviour
{
    public static PlayerMovment player;

    public AudioClip mexe;

    public SpriteRenderer sprite;

    public Sprite[] images;

    public Transform[] posicoes;

    public Dagon dagon;
    public Fogo fogo;

    public Animator anim;
    public Animator fogoPai;
    
    public float velX, volume;

    [HideInInspector]
    public int bloco = 3;

    bool isMov;
    public bool pode;

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
                    dagon.vira = true;
                    fogo.vira = true;
                    AudioSource.PlayClipAtPoint(mexe, new Vector3(0, 0, -10), volume);
                    anim.SetFloat("Vira", -1);
                    anim.SetTrigger("Esquerda");
                    pode = true;
                }
                else if (bloco > 2)
                {
                    bloco -= 1;
                    num = -1;
                    AudioSource.PlayClipAtPoint(mexe, new Vector3(0, 0, -10), volume);
                    StartCoroutine("GO");
                }
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (transform.localScale.x < 0)
                {
                    dagon.vira = true;
                    fogo.vira = true;
                    AudioSource.PlayClipAtPoint(mexe, new Vector3(0, 0, -10), volume);
                    anim.SetFloat("Vira", 1);
                    anim.SetTrigger("Direita");
                    pode = true;
                }
                else if (bloco < 5)
                {
                    bloco += 1;
                    num = 1;
                    AudioSource.PlayClipAtPoint(mexe, new Vector3(0, 0, -10), volume);
                    StartCoroutine("GO");
                }
            }
        }
    }

    public void ViroDireita()
    {
        StartCoroutine("Pode");
        //pode = false;
        transform.localScale = new Vector3(1.25f, transform.localScale.y, transform.localScale.z);
        dagon.Play();
        fogo.Play();
    }

    public void ViroEsquerda()
    {
        StartCoroutine("Pode");
        //pode = false;
        transform.localScale = new Vector3(-1.25f, transform.localScale.y, transform.localScale.z);
        dagon.Play();
        fogo.Play();
    }

    IEnumerator Pode()
    {
        yield return new WaitForSeconds(0.15f);
        pode = false;
        StopCoroutine("Pode");
    }

    public void Vira()
    {
        if (!pode)
        {
            if (transform.localScale.x < 0)
            {
                dagon.vira = true;
                fogo.vira = true;
                AudioSource.PlayClipAtPoint(mexe, new Vector3(0, 0, -10), volume);
                anim.SetFloat("Vira", 1);
                anim.SetTrigger("Direita");
                pode = true;
            }
            else if (transform.localScale.x > 0)
            {
                dagon.vira = true;
                fogo.vira = true;
                AudioSource.PlayClipAtPoint(mexe, new Vector3(0, 0, -10), volume);
                anim.SetFloat("Vira", -1);
                anim.SetTrigger("Esquerda");
                pode = true;
            }
        }
    }
    
    public void Esquerda()
    {
       // if (!pode)
      //  {
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
                AudioSource.PlayClipAtPoint(mexe, new Vector3(0, 0, -10), volume);
                StopCoroutine("GO");
                StartCoroutine("GO");
            }
        //}
    }
    
    public void Direita()
    {
       // if (!pode)
      //  {
            AudioSource.PlayClipAtPoint(mexe, new Vector3(0, 0, -10), volume);
           /* if (transform.localScale.x < 0)
            {
                anim.SetTrigger("Direita");
                pode = true;
            }
            else*/ if (bloco < 5)
            {
                bloco += 1;
                num = 1;
                AudioSource.PlayClipAtPoint(mexe, new Vector3(0, 0, -10), volume);
                StopCoroutine("GO");
                StartCoroutine("GO");
            }
      //  }
    }

    IEnumerator GO()
    {
        anim.SetBool("Run", true);
        isMov = true;
        for (int i = 0; i < 6; i++)
        {
            transform.Translate((velX * num)/3.5f, 0, 0, Space.World);
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
        transform.position = new Vector3(posicoes[bloco - 2].position.x, transform.position.y, transform.position.z);
        StopCoroutine("GO");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Alimento")
        {
            anim.SetTrigger("Fritando");
            fogoPai.SetTrigger("Fritando");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Alimento")
        {
            pode = false;
        }
    }
}