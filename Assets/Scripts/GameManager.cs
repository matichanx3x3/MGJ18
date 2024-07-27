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
    private bool finishedMiniGame = false;
    public int goodGame;
    public int badGame;
    public int diffGames;
    public GameObject[] cameras;
    public Animator canvasAnim;
    public GameObject[] minigames;
    public enum GameState
    {
        normal,
        glitch, 
        window,
        plant,
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
        SoundManager.Instance.PlayMusic("GameMusic");
    }

    private void Update()
    {
        
    }

    public void FinishingMinigame(GameState gm)
    {
        StartCoroutine(fadeOUT());
        gm_State = gm;
        badGame++;
        
    }

    public void FinishingMinigame()
    {
        StartCoroutine(fadeOUT());
        goodGame++;
        gm_State = GameState.glitch;
    }

    public void CalculateMoral()
    {
        
        diffGames = badGame - goodGame;
        finishedMiniGame = true;
        // negativo hace las cosas bien
        // positivo hace las cosas mal
        
    }

    public void EnterMiniGame(int i)
    {
        StartCoroutine(fadeIN());
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.lockState = CursorLockMode.Confined;
        minigames[i].SetActive(true);
    }

    IEnumerator fadeIN()
    {
        canvasAnim.SetBool("FadeIn",true);
        yield return new WaitForSeconds(1);
        canvasAnim.SetBool("FadeIn",false);
        enableMov = false;
        enableRot = false;
        inMiniGame = true;
        ChangeBTCameras(true);
    }
    
    IEnumerator fadeOUT()
    {
        canvasAnim.SetBool("FadeIn",true);
        yield return new WaitForSeconds(1);
        switch (MiniGameBubbleCanvas.Instance.actualMinigame.name)
        {
            case "BCPlanta":
                minigames[0].SetActive(false);
                break;
            case "BCPlatos":
                minigames[1].SetActive(false);
                break;
            case "BCVentana":
                minigames[2].SetActive(false);
                break;
        }
        canvasAnim.SetBool("FadeIn",false);
        enableMov = true;
        enableRot = true;
        inMiniGame = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.lockState = CursorLockMode.Locked;
        ChangeBTCameras(false);
        CalculateMoral();
    }

    public void ChangeBTCameras(bool cam)
    {
        if (cam)
        {
            cameras[0].SetActive(false);
            cameras[1].SetActive(true);
            
        }

        if (!cam)
        {
            cameras[0].SetActive(true);
            cameras[1].SetActive(false);
        }
    }

    
}
