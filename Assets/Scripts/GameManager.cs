using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public  bool enableMov = true;
    public  bool enableRot = true;
    public  bool inMiniGame = false;

    public enum GameState
    {
        normal,
        glitch, 
        toilet,
        sink,
        dishes
    }

    public GameState gm_State;
    void Awake() {
        if (Instance != null) {
            Destroy(gameObject);
        }
        else {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void FinishingMinigame(GameState gm)
    {
        enableMov = true;
        enableRot = true;
        inMiniGame = false;
        gm_State = gm;
    }

    public void EnterMiniGame()
    {
        enableMov = false;
        enableRot = false;
        inMiniGame = true;
    }

    
}
