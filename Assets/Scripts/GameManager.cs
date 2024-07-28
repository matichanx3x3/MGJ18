using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public  bool enableMov = true;
    public  bool enableRot = true;
    public  bool inMiniGame = false;
    private bool finishedMiniGame = false;
    public float goodGame;
    public float badGame;
    public float diffGames;
    public GameObject[] cameras;
    public Animator canvasAnim;
    public GameObject[] minigames;
    public GameObject[] mgCols;
    public GameObject[] mgBbls;

    public bool gamePlant;
    public bool gameWindow;
    public bool gameDishes;
    public GameObject textbbls;
    public GameObject textPlant;
    public GameObject textDishes;
    public GameObject textWindow;

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
        if (goodGame >= 1)
        {
            CamFX.Instance.activeRandomTimer = true;
        }
        if(gameDishes)
        {
            Destroy(mgCols[1]);
            mgBbls[1].SetActive(false);
            textDishes.SetActive(false);
        }
        if(gamePlant)
        {
            Destroy(mgCols[0]);
            mgBbls[0].SetActive(false);
            textPlant.SetActive(false);
        }
        if(gameWindow)
        {
            Destroy(mgCols[2]);
            mgBbls[2].SetActive(false);
            textWindow.SetActive(false);
        }

        if (!inMiniGame && gamePlant && gameDishes && gameWindow)
        {
            textbbls.SetActive(false);
            if (goodGame > badGame)
            {
                SceneManager.LoadScene("FinalBueno");
            }

            if (badGame == 3)
            {
                SceneManager.LoadScene("FinalMalo");
            }

            if ((diffGames == 1))
            {
                SceneManager.LoadScene("FinalRegular");
            }
        }
    }

    public void FinishingMinigame(GameState gm)
    {
        StartCoroutine(fadeOUT());
        gm_State = gm;
        SoundManager.Instance.PlaySFX("GlitchFX");
        badGame++;
        
    }

    public void FinishingMinigame()
    {
        StartCoroutine(fadeOUT());
        CamFX.Instance.addFXGrain();
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
                Debug.Log("hola");
                Destroy(minigames[0].gameObject);
                Destroy(mgCols[0].gameObject);
                //minigames[0].SetActive(false);
                break;
            case "BCPlatos":
                Debug.Log("hola");
                Destroy(minigames[1].gameObject);
                Destroy(mgCols[1].gameObject);
                //minigames[1].SetActive(false);
                break;
            case "BCVentana":
                
                Debug.Log("hola");
                MierdaCounter._mierdaCounter.finishGame = true;
                Destroy(minigames[2].gameObject);
                Destroy(mgCols[2].gameObject);
                //minigames[2].SetActive(false);
                break;
        }
        MiniGameBubbleCanvas.Instance.actualMinigame = null;
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
