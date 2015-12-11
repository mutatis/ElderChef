﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public static PlayerController player;

    public AudioClip perdeu;

    public int life;

    void Awake()
    {
        player = this;
    }

    void Update()
    {
        if(life <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    public void PerdeVida(int perdeu)
    {
        AudioSource.PlayClipAtPoint(this.perdeu, new Vector3(0, 0, -10));
        life -= perdeu;
    }
}