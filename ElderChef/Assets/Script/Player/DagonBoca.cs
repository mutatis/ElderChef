using UnityEngine;
using System.Collections;

public class DagonBoca : MonoBehaviour
{
    public Animator dagon;

    GameObject obj;

    IEnumerator GO()
    {
        yield return new WaitForSeconds(0.15f);
        LevelManager.levelManager.comeu += 1;
        Destroy(obj);
        StopCoroutine("GO");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Alimento")
        {
            obj = other.gameObject;
          //  if (obj.GetComponent<Alimento>().cozinho <= 0 && obj.GetComponent<Alimento>().frito > 0)
         //   {
                dagon.SetTrigger("Mastiga");
                StartCoroutine("GO");
           // }
        }
    }
}
