using UnityEngine;
using System.Collections;

public class Limits : MonoBehaviour
{
    public static Limits limit;
    public Transform[] trans;

    void Awake()
    {
        limit = this;
    }
}
