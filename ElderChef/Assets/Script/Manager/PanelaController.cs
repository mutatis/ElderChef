using UnityEngine;
using System.Collections;

public class PanelaController : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Pimenta")
        {
            PlayerController.player.pimenta = true;
            PlayerController.player.StartCoroutine("Pimenta");
            Destroy(other.gameObject);
        }
    }
}
