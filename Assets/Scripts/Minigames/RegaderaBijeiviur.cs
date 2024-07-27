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

    private void Update()
    {
        rb.velocity = Vector3.zero;
        if (this.transform.position.y > -2)
        {
            rb.gravityScale = 2;
        }

        if (isOnRange && timeRequestedToLose <= time)
        {
            plantGO.transform.localScale = Vector3.one * time / timeRequestedToLose;
            time += Time.deltaTime;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        this.transform.rotation = Quaternion.Euler(0, -30, 0);

        Instantiate(waterGO, spawnerTransform.position, Quaternion.Euler(0, 0, 0));
    }
private void OnTriggerStay2D(Collider2D collision)
    {
        isOnRange = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isOnRange = false;
        this.transform.rotation = Quaternion.Euler(0, -30, 0);
    }
}
