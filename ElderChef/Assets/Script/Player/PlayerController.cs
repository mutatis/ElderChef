using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public static PlayerController player;

    public int life;

    void Awake()
    {
        player = this;
    }

    void Update()
    {
        if(life <= 0)
        {
            //Morreu
        }
    }
}
