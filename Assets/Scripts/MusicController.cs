using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    void Awake()
    {
        int numberOfMusic = FindObjectsOfType<MusicController>().Length;
        if (numberOfMusic > 1) Destroy(gameObject);
        else DontDestroyOnLoad(gameObject);
    }
}
