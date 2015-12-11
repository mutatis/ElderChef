using UnityEngine;
using System.Collections;

public class Dagon : MonoBehaviour
{
    public Animator anim;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Alimento")
        {
            anim.SetTrigger("Comeu");
        }
    }
}