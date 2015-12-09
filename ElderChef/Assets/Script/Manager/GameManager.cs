using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager game;

    public int pontos;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        game = this;
    }

    void Update()
    {
        if(LevelManager.levelManager.comeu > 0)
        {
            pontos = LevelManager.levelManager.comeu;
        }
    }
}