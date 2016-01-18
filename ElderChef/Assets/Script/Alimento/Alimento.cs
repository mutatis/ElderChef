using UnityEngine;
using System.Collections;

public class Alimento : MonoBehaviour
{

    public Rigidbody2D rig;

    public SpriteRenderer sprite;

    public Animator frita;

    public AudioSource audio;

    public AudioClip bate;
    public AudioClip joga;
    public AudioClip pronta;

    public string tipo;

    public int nCozimento;
    [HideInInspector]
    public int cozinho;
    [HideInInspector]
    public int frito;

    Vector2 x;
    
    float dist;
    
    bool segue;
    bool morreu;

    int escolha;
    int minX;
    int maxX;
    int saveFrito;
    int temp;

	void Start ()
    {
        AudioSource.PlayClipAtPoint(joga, new Vector3(0, 0, -10));
        Jogar(0, Limits.limit.trans.Length);
        minX = 0;
        maxX = Limits.limit.trans.Length;
        cozinho = nCozimento;
        frito = nCozimento / 2;
        saveFrito = nCozimento;
	}
	
	void Update ()
    {
        if (!morreu)
        {
            if (cozinho <= 0 && frito > 0)
            {
                frita.SetTrigger("Frito");
                if (temp == 0)
                {
                    AudioSource.PlayClipAtPoint(pronta, new Vector3(0, 0, -10));
                    temp = 1;
                }
            }
            else if (frito <= 0)
            {
                sprite.color = new Color(0.24f, 0.24f, 0.24f);
            }

            if (saveFrito <= 0)
            {
                Queima();
            }

            if (segue)
            {
                dist = Vector2.Distance(Limits.limit.trans[escolha].position, transform.position);
                if (dist > 0.05f)
                {
                    transform.position = Vector2.Lerp(transform.position, new Vector2(x.x, transform.position.y), Time.deltaTime * 0.8f);
                }
                else
                {
                    segue = false;
                }
            }
        }
        else
        {
            transform.position = new Vector3(transform.position.x, -4.7f, transform.position.z);
            sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, sprite.color.a - 0.01f);
        }

        if(sprite.color.a <= 0)
        {
            Destroy(gameObject);
        }
	}

    public void Queima()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        frita.SetTrigger("Queimo");
        if (temp == 1)
        {
            audio.Play();
            temp = 2;
        }
    }

    public void Tchau()
    {
        Destroy(gameObject);
    }

    public void Jogar(int min, int max)
    {
        escolha = Random.Range(min, max);
        x = Limits.limit.trans[escolha].position;
        float y = 5.5f;
        rig.velocity = new Vector3(0, y, 0);
        segue = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Panela")
        {
            AudioSource.PlayClipAtPoint(bate, new Vector3(0, 0, -10));
            if (cozinho > 0)
            {
                cozinho -= 1;
            }
            else if(frito > 0)
            {
                frito -= 1;
            }
            else if (saveFrito > 0)
            {
                saveFrito -= 1;
            }
            if (escolha > 1)
            {
                minX = escolha - 2;
            }
            if (escolha < 3)
            {
                maxX = escolha + 2;
            }
            
            if(PlayerController.player.pimenta)
            {
                if (cozinho > 0)
                {
                    cozinho -= 1;
                }
                else if (frito > 1)
                {
                    frito -= 1;
                }
                else if(saveFrito > 0)
                {
                    saveFrito -= 1;
                }
                LevelManager.levelManager.AddPonto(1);
                PlayerPrefs.SetInt("Panelator", (PlayerPrefs.GetInt("Panelator") + 1));
            }

            PlayerPrefs.SetInt(tipo, PlayerPrefs.GetInt(tipo) + 1);
            
            Jogar(minX, maxX);
            LevelManager.levelManager.AddPonto(1);
            PlayerPrefs.SetInt("Panelator", (PlayerPrefs.GetInt("Panelator") + 1));
        }
        else if(other.gameObject.tag == "Chao")
        {
            PlayerPrefs.SetInt("ErroDagon", PlayerPrefs.GetInt("ErroDagon") + 1);
            PlayerController.player.PerdeVida(1);
            morreu = true;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            gameObject.GetComponent<Animator>().enabled = false;
        }
    }
}