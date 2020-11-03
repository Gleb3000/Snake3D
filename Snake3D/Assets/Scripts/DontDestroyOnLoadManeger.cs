using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DontDestroyOnLoadManeger
{
    public static GameObject gameObj;

    public static void DontDestroyOnLoad(GameObject gameObject)
    {
        gameObj = gameObject;
        GameObject.DontDestroyOnLoad(gameObject);
    }
}
