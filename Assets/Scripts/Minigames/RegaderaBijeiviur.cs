using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RegaderaBijeiviur : MiniGameBrain
{
    public GameObject plantGO;
    public GameObject waterGO;
    public Transform spawnerTransform;
    public Rigidbody2D rb;

    public bool isOnRange;

    public float timeRequestedToWin;
    public float timeRequestedToLose;
    public float time;
    public float timerWaterDrop;
    public bool hasFinished;
    public bool win;
    public bool lose;

    public Color colorA;
    public Color colorB;

    public GameObject parentGO;

    private void Update()
    {
        rb.velocity = Vector3.zero;
        if (this.transform.position.y > -2)
        {
            rb.gravityScale = 0;
        }
        else if (MiniGameManager._minigamemanager.isDragging)
        {
            isOnRange = false;
        }

        if (isOnRange && timeRequestedToWin >= time)
        {
            plantGO.transform.localScale = Vector3.one * time / timeRequestedToWin;

            time += Time.deltaTime;
        }
        if (isOnRange && timeRequestedToLose >= time && timeRequestedToWin <= time)
        {
            plantGO.transform.localScale = Vector3.one * (3 - (time - 5 / timeRequestedToLose - 5)) / 3;

            time += Time.deltaTime;
        }
        if(time>timeRequestedToWin && !MiniGameManager._minigamemanager.isDragging)
        {
            win = true;
            hasFinished = true;
        }
        if (time > timeRequestedToLose && !MiniGameManager._minigamemanager.isDragging)
        {
            lose = true;
            win = false;
            hasFinished = true;
        }

        if (hasFinished)
        {
            GameManager.Instance.gamePlant = true;
        }
        
        if (hasFinished && win)
        {
            GameManager.Instance.FinishingMinigame();
            GameManager.Instance.goodGame++;
            GameManager.Instance.goodGame = GameManager.Instance.goodGame - 0.5f;
            GameManager.Instance.goodGame = GameManager.Instance.goodGame - 0.5f;
            Destroy(parentGO);  
            hasFinished = false;
        }       
        if (hasFinished && lose)
        {
            hasFinished = false;
            GameManager.Instance.FinishingMinigame(GameManager.GameState.plant);
            GameManager.Instance.badGame++;
            GameManager.Instance.badGame = GameManager.Instance.badGame - 0.5f;
            GameManager.Instance.badGame = GameManager.Instance.badGame - 0.5f;
            Destroy(parentGO);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (MiniGameManager._minigamemanager.isDragging)
        {
            this.transform.rotation = Quaternion.Euler(0, 0, 30);
        }

        isOnRange = true;
        
        Instantiate(waterGO, spawnerTransform.position, Quaternion.Euler(0, 0, 0));
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("ahdahah");
        if (MiniGameManager._minigamemanager.isDragging)
        {
            this.transform.rotation = Quaternion.Euler(0, 0, 30);
            
            timerWaterDrop += Time.deltaTime;
            if (timerWaterDrop > 0.5f)
            {
                Instantiate(waterGO, spawnerTransform.position, Quaternion.Euler(0, 0, 0));
                timerWaterDrop = 0;
            } 
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isOnRange = false;
        this.transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}
