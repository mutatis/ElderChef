using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour
{
    public static LevelManager levelManager;

    public Probabilidade probabilidade;

    public Transform[] posCreated;

    public GameObject[] alimento;

    public Animator[] elder;

    public float tempo;

    public int pontos, trocaTempo;

    int n;
    int num;
    int tutorial;
    int troca;

    bool isPlay;

    void Awake()
    {
        levelManager = this;
    }

    void Start()
    {
        troca = trocaTempo;
       /* if (PlayerPrefs.GetInt("Primeira") == 0)
        {
            tempo = 15;
            tutorial = 1;
            isPlay = true;
            StartCoroutine("Created");
        }*/
    }

    void Update()
    {
        if(!isPlay && Time.timeScale == 1)
        {
            int x = Random.Range(0, posCreated.Length);
            elder[x].SetTrigger("Joga");
            n = probabilidade.ChooseAlimento();
            Instantiate(alimento[n], posCreated[x].position, transform.rotation);
            StartCoroutine("Created");
            isPlay = true;
        }
    }

    public void AddPonto(int qntPonto)
    {
        pontos += qntPonto;
    }

    IEnumerator Created()
    {
        if (pontos > troca && tempo > 3)
        {
            tempo -= 0.5f;
            troca += trocaTempo;
        }
        yield return new WaitForSeconds(tempo);
        num += 1;
        if(num >= 10)
        {
            if (tempo > 2)
            {
                tempo = tempo / 1.2f;
            }
            num = 0;
        }
        if(tutorial == 1)
        {
            tempo = 6;
            tutorial = 2;
        }
        int x = Random.Range(0, posCreated.Length);
        elder[x].SetTrigger("Joga");
        n = probabilidade.ChooseAlimento();
        Instantiate(alimento[n], posCreated[x].position, transform.rotation);
        StartCoroutine("Created");
    }
}