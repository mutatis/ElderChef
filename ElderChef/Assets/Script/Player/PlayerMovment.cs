using UnityEngine;
using System.Collections;

public class PlayerMovment : MonoBehaviour
{
    public static PlayerMovment player;

    public SpriteRenderer sprite;

    public Sprite[] images;
    
    public float velX;

    [HideInInspector]
    public int bloco = 3;

    bool isMov;

    int nImage;
    int num;

    void Awake()
    {
        player = this;
    }

	void Update ()
    {
        if (!isMov)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (transform.localScale.x > 0)
                {
                    transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
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
                    transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
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

    IEnumerator GO()
    {
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
            yield return new WaitForSeconds(0.1f);
        }
        isMov = false;
        StopCoroutine("GO");
    }
}