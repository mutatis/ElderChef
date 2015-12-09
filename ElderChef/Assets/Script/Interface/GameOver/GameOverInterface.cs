﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOverInterface : MonoBehaviour
{
    public Text text;

    int pontos;

    void Start()
    {
        pontos = GameManager.game.pontos;

        text.text = "Você fez " + pontos + " pontos jogo mal seu lixo!!!";
    }
}