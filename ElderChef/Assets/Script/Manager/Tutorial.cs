using UnityEngine;
using System.Collections;

public class Tutorial : MonoBehaviour
{
    public GameObject comida;
    
    public void Play()
    {
        Instantiate(comida);
        Time.timeScale = 1;
        Destroy(gameObject);
    }
}
