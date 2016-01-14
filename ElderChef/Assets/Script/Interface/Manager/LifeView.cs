using UnityEngine;
using System.Collections;

public class LifeView : MonoBehaviour
{

    public Animator[] vida;

    int life;

	void Update ()
    {
        life = PlayerController.player.life;

        switch (life)
        {
            case 0:
                for(int i = 0; i < vida.Length; i++)
                {
                    vida[i].enabled = true;
                }
            break;

            case 1:
                for (int i = 0; i < vida.Length - 1; i++)
                {
                    vida[i].enabled = true;
                }
            break;

            case 2:
                for (int i = 0; i < vida.Length - 2; i++)
                {
                    vida[i].enabled = true;
                }
            break;

            case 3:
                //todos ok;
            break;

            default:
                //tudo ok;
            break;
        }
	}
}
