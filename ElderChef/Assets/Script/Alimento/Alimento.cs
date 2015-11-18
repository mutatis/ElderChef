using UnityEngine;
using System.Collections;

public class Alimento : MonoBehaviour
{

    public Rigidbody2D rig;

    public SpriteRenderer sprite;

    public int nCozimento;
    [HideInInspector]
    public int cozinho;
    [HideInInspector]
    public int frito;

    Vector2 x;
    
    float dist;

    bool sumiu;
    bool segue;

    int escolha;
    int minX;
    int maxX;
    int bloco;

	void Start ()
    {
        Jogar(0, Limits.limit.trans.Length);
        minX = 0;
        maxX = Limits.limit.trans.Length;
        cozinho = nCozimento;
        frito = nCozimento;
	}
	
	void Update ()
    {
        bloco = PlayerMovment.player.bloco;
        if(cozinho <= 0 && frito > 0)
        {
            sprite.color = Color.blue;
        }
        else if(frito <= 0)
        {
            sprite.color = Color.black;
        }
        if(segue)
        {
            dist = Vector2.Distance(Limits.limit.trans[escolha].position, transform.position);
            if(dist > 0.3)
            {
                transform.position = Vector2.Lerp(transform.position, new Vector2(x.x, transform.position.y), Time.deltaTime * 2);
                //transform.Translate(x);
            }
            else
            {
                segue = false;
            }
        }
	}

    public void Jogar(int min, int max)
    {
        escolha = Random.Range(min, max);
        x = Limits.limit.trans[escolha].position;
        print(x);
        int y = 10;
        rig.velocity = new Vector3(0, y, 0);
        segue = true;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            if (cozinho > 0)
            {
                cozinho -= 1;
            }
            else if(frito > 0)
            {
                frito -= 1;
            }
            else
            {
                sumiu = true;
            }
            Jogar(minX, maxX);
        }
    }
}
