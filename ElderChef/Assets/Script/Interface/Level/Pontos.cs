using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Pontos : MonoBehaviour
{
    public Text text;

    [HideInInspector]
    public int pontos;
    
    void Update()
    {
        pontos = LevelManager.levelManager.comeu;
        text.text = pontos.ToString();
    }	
}
