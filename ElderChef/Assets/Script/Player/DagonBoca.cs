using UnityEngine;
using System.Collections;

public class DagonBoca : MonoBehaviour
{
    public Animator dagon;

    public AudioClip eat;

    GameObject obj;

    IEnumerator GO()
    {
        yield return new WaitForSeconds(0.15f);
        LevelManager.levelManager.AddPonto(1);
        Destroy(obj);
        StopCoroutine("GO");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Alimento")
        {
            obj = other.gameObject;
            if (obj.GetComponent<Alimento>().cozinho <= 0 && obj.GetComponent<Alimento>().frito > 0)
            {
                AudioSource.PlayClipAtPoint(eat, new Vector3(0, 0, -10));
                dagon.SetTrigger("Mastiga");
                StartCoroutine("GO");
            }
        }
    }
}
