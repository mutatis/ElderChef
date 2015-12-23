using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour
{
    public static LevelManager levelManager;

    public Probabilidade probabilidade;

    public Transform[] posCreated;

    public GameObject[] alimento;

    public List<GameObject> controll = new List<GameObject>();

    public float tempo;

    public int pontos;

    int n;

    bool isPlay;

    void Awake()
    {
        levelManager = this;
    }

    void Update()
    {
        if(!isPlay && Time.timeScale == 1)
        {
            int x = Random.Range(0, posCreated.Length);
            n = probabilidade.ChooseAlimento();
            Instantiate(alimento[n], posCreated[x].position, transform.rotation);
            StartCoroutine("Created");
            isPlay = true;
        }
    }

    public void RemoveItem(GameObject obj)
    {
        controll.Remove(obj);
    }

    public void AddItem(GameObject obj)
    {
        controll.Add(obj);
    }

    public void DagonQuente()
    {
        for(int i = 0; i < controll.Count; i++)
        {
            Destroy(controll[i]);
        }
    }

    public void AddPonto(int qntPonto)
    {
        pontos += qntPonto;
    }

    IEnumerator Created()
    {
        yield return new WaitForSeconds(tempo);
        int x = Random.Range(0, posCreated.Length);
        n = probabilidade.ChooseAlimento();
        Instantiate(alimento[n], posCreated[x].position, transform.rotation);
        StartCoroutine("Created");
    }
}