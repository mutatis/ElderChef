using UnityEngine;
using System.Collections;

public class PlayerMovment : MonoBehaviour
{
    public static PlayerMovment player;

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
                    anim.SetFloat("Vira", -1);
                    anim.SetTrigger("Esquerda");
                    pode = true;
                   // transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
                }
                else if (bloco > 1)
                {
                    bloco -= 1;
                    num = -1;
                    StartCoroutine("GO");
                }
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (transform.localScale.x < 0)
                {
                    anim.SetFloat("Vira", 1);
                    anim.SetTrigger("Direita");
                    pode = true;
                    // transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
                }
                else if (bloco < 5)
                {
                    bloco += 1;
                    num = 1;
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

    public void Esquerda()
    {
        if (transform.localScale.x > 0)
        {
            anim.SetTrigger("Esquerda");
            //transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }
        else if (bloco > 1)
        {
            bloco -= 1;
            num = -1;
            StopCoroutine("GO");
            StartCoroutine("GO");
        }
    }

    public void Direita()
    {
        if (transform.localScale.x < 0)
        {
            anim.SetTrigger("Direita");
            //transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }
        else if (bloco < 5)
        {
            bloco += 1;
            num = 1;
            StopCoroutine("GO");
            StartCoroutine("GO");
        }
    }

    IEnumerator GO()
    {
        anim.SetBool("Run", true);
        isMov = true;
        for (int i = 0; i < 3; i++)
        {
            transform.Translate((velX * num)/3, 0, 0);
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
            yield return new WaitForSeconds(0.06f);
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