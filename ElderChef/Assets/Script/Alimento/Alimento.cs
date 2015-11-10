using UnityEngine;
using System.Collections;

public class Alimento : MonoBehaviour
{

    public Rigidbody2D rig;

    int minX;
    int maxX;
    int bloco;

	void Start ()
    {
        Jogar(-5, 0);
	}
	
	void Update ()
    {
        bloco = PlayerMovment.player.bloco;
	}

    public void Calcula()
    {
        if (bloco != 1)
        {
            minX = bloco * -1;
        }
        else
        {
            minX = 0;
        }
        maxX = ((bloco - 5) * -1);
        print(minX + "+" + maxX + "+" + bloco);
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
            Calcula();
            Jogar(minX, maxX);
        }
    }
}
