using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager game;

    public int pontos;

    bool isSave;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        game = this;
    }

    void Update()
    {
        if(LevelManager.levelManager.pontos > 0)
        {
            pontos = LevelManager.levelManager.pontos;
        }
        
        if(PlayerController.player.life < 1 && !isSave)
        {
            SavePontos();
        }
        else if(PlayerController.player.life > 0)
        {
            isSave = false;
        }
    }

    void SavePontos()
    {
        PlayerPrefs.SetInt("Pontos", PlayerPrefs.GetInt("Pontos") + LevelManager.levelManager.pontos);
        isSave = true;
    }
}