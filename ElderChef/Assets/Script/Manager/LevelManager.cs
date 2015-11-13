using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour
{
    public static LevelManager levelManager;

    public Probabilidade probabilidade;

    public Transform[] posCreated;

    public GameObject[] comida;

    public float tempo;

    public int comeu;

    void Awake()
    {
        levelManager = this;
    }

    void Start()
    {
        int x = Random.Range(0, posCreated.Length);
        Instantiate(comida[probabilidade.ChooseAlimento()], posCreated[x].position, transform.rotation);
        StartCoroutine("Created");
    }

    void Update()
    {

    }

    IEnumerator Created()
    {
        yield return new WaitForSeconds(tempo);
        int x = Random.Range(0, posCreated.Length);
        Instantiate(comida[probabilidade.ChooseAlimento()], posCreated[x].position, transform.rotation);
        StartCoroutine("Created");
    }
}
