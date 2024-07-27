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

    private void Update()
    {
        rb.velocity = Vector3.zero;
        if (this.transform.position.y > -2)
        {
            rb.gravityScale = 6;
        }

        if (isOnRange && timeRequestedToLose >= time)
        {
            plantGO.transform.localScale = Vector3.one * time / timeRequestedToLose;

            time += Time.deltaTime;
        }
        if (time >= timeRequestedToWin && time <= timeRequestedToLose)
        {
            GameManager.Instance.FinishingMinigame();
            GameManager.Instance.goodGame++;
        }
        if (timeRequestedToLose <= time)
        {
            GameManager.Instance.FinishingMinigame(GameManager.GameState.plant);
            GameManager.Instance.badGame++;
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
        }
        timerWaterDrop += Time.deltaTime;
        if (timerWaterDrop > 0.5f)
        {
            Instantiate(waterGO, spawnerTransform.position, Quaternion.Euler(0, 0, 0));
            timerWaterDrop = 0;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isOnRange = false;
        this.transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    private IEnumerator WaitToWin()
    {
        yield return new WaitForSeconds(1);
        GameManager.Instance.goodGame++;
        GameManager.Instance.FinishingMinigame();
    }
}
