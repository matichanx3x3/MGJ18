using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlatosBijeiviur : MiniGameBrain
{
    public Image _Image;
    public Sprite spriteBroken;

    public override void OnPointerDown(PointerEventData eventData)
    {

    }

    public override void OnPointerUp(PointerEventData eventData)
    {
            _Image.sprite = spriteBroken;
        //if()
        //{
        //}
        //else if()
        //{
        //}
    }
}
