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

    int nImage;

    void Awake()
    {
        player = this;
    }

	void Update ()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if(nImage == 0)
            {
                sprite.sprite = images[1];
                nImage = 1;
            }
            else if(nImage == 1)
            {
                sprite.sprite = images[0];
                nImage = 0;
            }
            if(transform.localScale.x > 0)
            {
                transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
            }
            else if(bloco > 1)
            {
                bloco -= 1;
                transform.Translate((velX * -1), 0, 0);
            }
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
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
            if (transform.localScale.x < 0)
            {
                transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
            }
            else if(bloco < 5)
            {
                bloco += 1;
                transform.Translate(velX, 0, 0);
            }
        }
    }
}