using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class PlatosBijeiviur : MiniGameBrain
{
    public SpriteRenderer _Image;
    public Sprite spriteBroken;

    public float timeRequested;
    public float time;
    
    public GameObject ronia;

    public bool cleaned;
    public bool alreadyCounted;

    private void Awake()
    {
        time = timeRequested;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Entra");

        if (!MiniGameManager._minigamemanager.isDragging)
        {
            if (collision.tag == "losecon")
            {
                StartCoroutine(WaitTillBreak());
            }
        }
        if (collision.tag == "wincon")
        {
            StartCoroutine(WaitTillClean());
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!MiniGameManager._minigamemanager.isDragging)
        {
            if (collision.tag == "losecon")
            {
                StartCoroutine(WaitTillBreak());
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Sale");
        if (collision.tag == "wincon")
        {
            StopCoroutine(WaitTillClean());
        }
    }
    private IEnumerator WaitTillClean()
    {
            yield return new WaitForSeconds(timeRequested);
            Destroy(ronia);
            if (!alreadyCounted)
            {
                mmasgnnknan._mmasgnnknan.good++;
                mmasgnnknan._mmasgnnknan.counter++;
                alreadyCounted = true;
            }
    }
    private IEnumerator WaitTillBreak()
    {

         yield return new WaitForSeconds(1);
        _Image.sprite = spriteBroken;
        yield return new WaitForSeconds(1);
        Destroy(this.gameObject);
        if (!alreadyCounted)
        {
            mmasgnnknan._mmasgnnknan.bad++;
            mmasgnnknan._mmasgnnknan.counter++;
            alreadyCounted = true;
        }
    }
}
