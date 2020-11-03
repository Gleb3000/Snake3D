using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemporarySaves : MonoBehaviour
{
    public int Score;

    public void Awake()
    {
        DontDestroyOnLoadManeger.DontDestroyOnLoad(gameObject);
    }
}
