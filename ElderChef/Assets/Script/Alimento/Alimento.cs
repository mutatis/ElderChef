using UnityEngine;
using System.Collections;

public class Alimento : MonoBehaviour
{

    public Rigidbody2D rig;

    public SpriteRenderer sprite;

    public int nCozimento;

    bool sumiu;

    int cozinho;
    int frito;
    int minX;
    int maxX;
    int bloco;

	void Start ()
    {
        if (transform.position.x > 0)
        {
            Jogar(-5, 0);
        }
        else if (transform.position.x < 0)
        {
            Jogar(0, 5);
        }
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
	}

    public void Calcula()
    {
        if (bloco != 1)
        {
            minX = bloco * -1;
            minX += 1;
        }
        else
        {
            minX = 0;
        }
        maxX = ((bloco - 5) * -1);
    }

    public void Jogar(int min, int max)
    {
        int x = Random.Range(min, max);
        int y = 10;
        rig.velocity = new Vector3(x, y, 0);
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
            Calcula();
            Jogar(minX, maxX);
        }
        if(other.gameObject.tag == "Mascote")
        {
            if(cozinho <= 0 && frito > 0)
            {
                LevelManager.levelManager.comeu += 1;
                Destroy(gameObject);
            }
        }
    }
}
