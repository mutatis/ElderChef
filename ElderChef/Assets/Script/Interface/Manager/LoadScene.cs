using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public void Load(string cena)
    {
        SceneManager.LoadScene(cena);
    }
}