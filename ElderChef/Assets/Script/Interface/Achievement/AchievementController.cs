using UnityEngine;
using System.Collections;

public class AchievementController : MonoBehaviour
{
    public GameObject obj;

    public void DestroyObj()
    {
        Destroy(obj);
    }
}