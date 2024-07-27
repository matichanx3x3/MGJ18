using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class MiniGameBrain : MonoBehaviour,IPointerClickHandler, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public static MiniGameBrain _minigamebrain;
    Canvas _canva;
    Camera _camera;
    // Start is called before the first frame update
    private void Awake()
    {
        _canva = transform.parent.GetComponent<Canvas>();
        _minigamebrain = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        if (pointerEventData.button == PointerEventData.InputButton.Right)
        {
            //Output to console the clicked GameObject's name and the following message. You can replace this with your own actions for when clicking the GameObject.
            Debug.Log(name + " Game Object Right Clicked!");
        }
    }
    public void OnDrag(PointerEventData eventData)
    {
        //con canvas siempre anchored position!
        this.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition;
    }
    public virtual void OnPointerDown(PointerEventData eventData)
    {
    }

    public virtual void OnPointerUp(PointerEventData eventData)
    {
    }

}
