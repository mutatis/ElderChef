using UnityEngine;
using System.Collections;

public class FogoDagon : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Alimento")
        {
            other.gameObject.GetComponent<Animator>().SetTrigger("Queimo");
        }
    }
}
