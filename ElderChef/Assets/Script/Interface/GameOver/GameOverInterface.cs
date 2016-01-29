using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverInterface : MonoBehaviour
{
    public Text text;

    public AudioSource audio;

    int pontos;
    int save;

    float temp;

    void Start()
    {
        Time.timeScale = 1;

        pontos = GameManager.game.pontos;
    }

    void Update()
    {
        if(Input.GetMouseButtonUp(0))
        {
            temp = pontos;
            audio.Stop();
        }

        if(temp < pontos)
        {
            text.text = save.ToString();
            temp += 0.3f;
            save = (int)temp;
        }
        else
        {
            text.text = pontos.ToString();
            audio.Stop();
        }
    }

    public void Restart(string level)
    {
        SceneManager.LoadScene(level);
    }
}