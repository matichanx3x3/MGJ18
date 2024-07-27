using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamTEst : MonoBehaviour
{
    private Vector3 mousePos;
    private Transform actualObject;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ( Input.GetMouseButtonDown (0)){ 
            RaycastHit hit; 
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); 
            if ( Physics.Raycast (ray,out hit,100.0f))
            {
                actualObject = hit.transform;
                Debug.Log("You selected the " + hit.transform.name); // ensure you picked right object
            }
        }
    }

    private void OnMouseDown()
    {
        mousePos = Input.mousePosition - GetMousePos();
    }

    private void OnMouseDrag()
    {
        actualObject.position = Camera.main.ScreenToWorldPoint(Input.mousePosition - mousePos);
    }

    public Vector3 GetMousePos()
    {
        return Camera.main.WorldToScreenPoint(actualObject.position);
    }
}
