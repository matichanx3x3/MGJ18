using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RegaderaBijeiviur : MiniGameBrain
{
    public bool isHolded;
    public float stopLimit;
    private void Start()
    {
        isHolded = true;
    }
    private void Update()
    {
        if (!this.isHolded && transform.position.y >= stopLimit)
        {
            transform.position = transform.position + new Vector3(0, -100, 0) * Time.deltaTime;
        }
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        isHolded = true;
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        isHolded = false;
    }
}
