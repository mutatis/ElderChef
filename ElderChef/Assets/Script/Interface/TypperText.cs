using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TypperText : MonoBehaviour
{
    public Text text;

    public string texto;

    void Start()
    {
        StartCoroutine("TypeText");
    }

    IEnumerator TypeText()
    {
        foreach (char letter in texto.ToCharArray())
        {
            text.text += letter;
            float start = Time.realtimeSinceStartup;
            while (Time.realtimeSinceStartup < start + 0.05f)
            {
                yield return null;
            }
        }
    }
}
