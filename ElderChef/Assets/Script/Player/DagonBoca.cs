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
        LevelManager.levelManager.AddPonto(5);       
        PlayerPrefs.SetInt(obj.GetComponent<Alimento>().tipo, PlayerPrefs.GetInt(obj.GetComponent<Alimento>().tipo) + 5);
        PlayerPrefs.SetInt("Dagon", PlayerPrefs.GetInt("Dagon") + 1);
        Destroy(obj);
        StopCoroutine("GO");
    }

    void Verifica()
    {
        if (obj.GetComponent<Alimento>().cozinho <= 0 && obj.GetComponent<Alimento>().frito > 0)
        {
            AudioSource.PlayClipAtPoint(eat, new Vector3(0, 0, -10));
            dagon.SetTrigger("Mastiga");
            obj.GetComponent<BoxCollider2D>().enabled = false;
            StartCoroutine("GO");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Alimento")
        {
            obj = other.gameObject;
            Verifica();
        }
        else if (other.gameObject.tag == "Pimenta")
        {
            LevelManager.levelManager.DagonQuente();
        }
    }
}
