using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TapStart : MonoBehaviour
{
    void Start()
    {
        Time.timeScale = 0;
    }

    public void Click(GameObject obj)
    {
        print("OOOOII");
        Time.timeScale = 1;
        Destroy(obj);
    }
}
