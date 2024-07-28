using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameBubbleCanvas : MonoBehaviour
{
    public static MiniGameBubbleCanvas Instance;
    public GameObject[] minigamesBbls;
    public GameObject actualMinigame;
    private void Awake()
    {
        if (Instance != null) 
        {
            Destroy(gameObject);
        }
        else {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

}
