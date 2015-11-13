using UnityEngine;
using System.Collections;

public class Probabilidade : MonoBehaviour
{
    //alimento
    public Alimentos[] alimento;

    //escolhe 
    public int ChooseAlimento()
    {
        float total = 0;
        int i = 0;
        foreach (Alimentos elem in alimento)
        {
            total += elem.probability;
        }

        float randomPoint = Random.value * total;

        for (i = 0; i < alimento.Length; i++)
        {
            if (randomPoint < alimento[i].probability)
                return i;
            else
                randomPoint -= alimento[i].probability;
        }

        return alimento.Length - 1;
    }
}

[System.Serializable]
public class Alimentos
{
    public GameObject alimento;
    [Range(0, 100)]
    public float probability;
}