using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public  bool enableMov = true;
    public  bool enableRot = true;
    public  bool inMiniGame = false;
    private bool finishedMiniGame = false;
    public int goodGame;
    public int badGame;
    public int diffGames;
    public VolumeProfile ppVol;
    public FilmGrain fmGrain;
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

    private void Start()
    {
        gm_State = GameState.normal;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.lockState = CursorLockMode.Locked;
        ppVol.TryGet(out fmGrain);
    }

    private void Update()
    {
        if (finishedMiniGame)
        {
            CalculateMoral();
        }
    }

    public void FinishingMinigame(GameState gm)
    {
        enableMov = true;
        enableRot = true;
        inMiniGame = false;
        gm_State = gm;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.lockState = CursorLockMode.Locked;
        badGame++;
        
    }

    public void FinishingMinigame()
    {
        enableMov = true;
        enableRot = true;
        inMiniGame = false;
        gm_State = GameState.glitch;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.lockState = CursorLockMode.Locked;
        goodGame++;
    }

    public void CalculateMoral()
    {
        
        diffGames = badGame - goodGame;
        finishedMiniGame = true;
        // negativo hace las cosas bien
        // positivo hace las cosas mal
        
    }

    public void EnterMiniGame()
    {
        enableMov = false;
        enableRot = false;
        inMiniGame = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void testVP(bool test)
    {
        if (test)
        {
            float intensity = fmGrain.intensity.value;
            fmGrain.intensity.Override(intensity + .01f);
        }

        if (!test)
        {
            float intensity = fmGrain.intensity.value;
            fmGrain.intensity.Override(intensity - .01f);
        }
    }
    
}
