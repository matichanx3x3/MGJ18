using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MierdaCounter : MonoBehaviour
{
    public static MierdaCounter _mierdaCounter;
    public int counter = 11;
    public int bien = 0;
    public int mal = 0;

    public Sprite spriteroto;
    public SpriteRenderer spriterenderer;

    public GameObject parentGO;

    public bool finishGame = false;
    // Start is called before the first frame update
    private void Awake()
    {
        _mierdaCounter = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!finishGame && (counter == 0 && (bien - mal) > 0 ))
        {
            Debug.Log("hola entrando");
            GameManager.Instance.FinishingMinigame();
            finishGame = true;  
        }
        if (!finishGame && (counter == 0 && (mal - bien) > 0 ))
        {
            Debug.Log("hola entrando");
            GameManager.Instance.FinishingMinigame(GameManager.GameState.window);
            finishGame = true;
        }
        if (mal >= 6)
        {
            spriterenderer.sprite = spriteroto;
        }
        if (finishGame)
        {
            GameManager.Instance.gameWindow = true;
            Destroy(parentGO);
        }
    }
    public void SumarLimpiaBien()
    {
        counter--;
        bien++;
    }
    public void SumarLimpiaMal()
    {
        counter--;
        mal++;
    }
}
