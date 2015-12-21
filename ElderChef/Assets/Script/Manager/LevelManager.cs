using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour
{
    public static LevelManager levelManager;

    public Probabilidade probabilidade;

    public Transform[] posCreated;

    public GameObject[] alimento;

    public float tempo;

    public int pontos;

    bool isPlay;

    void Awake()
    {
        levelManager = this;
    }

    void Start()
    {

    }

    void Update()
    {
        if(!isPlay && Time.timeScale == 1)
        {
            int x = Random.Range(0, posCreated.Length);
            Instantiate(alimento[probabilidade.ChooseAlimento()], posCreated[x].position, transform.rotation);
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
        yield return new WaitForSeconds(tempo);
        int x = Random.Range(0, posCreated.Length);
        Instantiate(alimento[probabilidade.ChooseAlimento()], posCreated[x].position, transform.rotation);
        StartCoroutine("Created");
    }
}