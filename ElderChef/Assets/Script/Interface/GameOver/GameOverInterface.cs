using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverInterface : MonoBehaviour
{
    public Text text;

    int pontos;

    void Start()
    {
        pontos = GameManager.game.pontos;

        if(PlayerPrefs.GetInt("HighScore") < GameManager.game.pontos)
        {
            PlayerPrefs.SetInt("HighScore", GameManager.game.pontos);
        }

        text.text = "Você fez " + pontos + " pontos jogo mal seu lixo!!! Sua melhor pontuação é " + PlayerPrefs.GetInt("HighScore") + "!";
    }

    public void Restart(string level)
    {
        SceneManager.LoadScene(level);
    }
}