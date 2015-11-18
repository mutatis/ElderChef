using UnityEngine;
using System.Collections;

public class Dagon : MonoBehaviour
{

    public Animator anim;

    GameObject obj;

    public void Comeu()
    {
        if (obj.GetComponent<Alimento>().cozinho <= 0 && obj.GetComponent<Alimento>().frito > 0)
        {
            LevelManager.levelManager.comeu += 1;
            Destroy(obj);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Alimento")
        {
            anim.SetTrigger("Comeu");
            obj = other.gameObject;
        }
    }
}
