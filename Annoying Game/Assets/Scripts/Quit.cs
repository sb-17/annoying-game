using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour
{
    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("DontDestroy");
        if (objs.Length > 1)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    private void OnApplicationQuit()
    {
        if (Menu.canQuit)
        {
            Application.Quit();
        }

        if (!Menu.canQuit)
        {
            Application.CancelQuit();
        }
    }
}
