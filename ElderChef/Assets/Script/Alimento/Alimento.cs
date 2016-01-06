using UnityEngine;
using System.Collections;

public class Alimento : MonoBehaviour
{

    public Rigidbody2D rig;

    public SpriteRenderer sprite;

    public AudioClip bate;
    public AudioClip joga;

    public string tipo;

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
    int saveFrito;

	void Start ()
    {
        LevelManager.levelManager.AddItem(gameObject);
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
        bloco = PlayerMovment.player.bloco;
        if(cozinho <= 0 && frito > 0)
        {
            sprite.color = new Color(1, 0.87f, 0.44f, 1);
        }
        else if(frito <= 0)
        {
            sprite.color = Color.black;
        }

        if(saveFrito <= 0)
        {
            Destroy(gameObject);
        }

        if(segue)
        {
            dist = Vector2.Distance(Limits.limit.trans[escolha].position, transform.position);
            if(dist > 0.05f)
            {
                transform.position = Vector2.Lerp(transform.position, new Vector2(x.x, transform.position.y), Time.deltaTime * 1);
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
        float y = 7.5f;
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
            else
            {
                sumiu = true;
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
                PlayerPrefs.SetInt("Panelada", (PlayerPrefs.GetInt("Panelada") + 1));
            }

            PlayerPrefs.SetInt(tipo, PlayerPrefs.GetInt(tipo) + 1);
            
            Jogar(minX, maxX);
            LevelManager.levelManager.AddPonto(1);
            PlayerPrefs.SetInt("Panelada", (PlayerPrefs.GetInt("Panelada") + 1));
        }
        else if(other.gameObject.tag == "Chao")
        {
            PlayerPrefs.SetInt("ErroDagon", PlayerPrefs.GetInt("ErroDagon") + 1);
            LevelManager.levelManager.RemoveItem(gameObject);
            PlayerController.player.PerdeVida(1);
        }
    }
}