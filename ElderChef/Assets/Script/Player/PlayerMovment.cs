using UnityEngine;
using System.Collections;

public class PlayerMovment : MonoBehaviour
{
    public static PlayerMovment player;
    
    public float velX;

    [HideInInspector]
    public int bloco = 3;
	
    void Awake()
    {
        player = this;
    }

	void Update ()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow) && bloco > 1)
        {
            if(transform.localScale.x > 0)
            {
                transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
            }
            else
            {
                bloco -= 1;
                transform.Translate((velX * -1), 0, 0);
            }
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && bloco < 5)
        {
            if (transform.localScale.x < 0)
            {
                transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
            }
            else
            {
                bloco += 1;
                transform.Translate(velX, 0, 0);
            }
        }
    }
}