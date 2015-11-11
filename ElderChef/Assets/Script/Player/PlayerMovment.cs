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
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
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