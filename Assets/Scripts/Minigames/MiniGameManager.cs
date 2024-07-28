using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameManager : MonoBehaviour
{
    public static MiniGameManager _minigamemanager;

    public GameObject selectedobject;
    public LayerMask draggableMask;
    public Camera _camera;
    public bool isDragging;
    public bool isEnabled;

    private void Awake()
    {
        _minigamemanager = this;
    }
    private void Start()
    {
        isDragging = false;
    }
    private void Update()
    {
        if (isEnabled)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

                RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity, draggableMask);

                if (hit.collider != null)
                {
                    Debug.Log(hit.collider.gameObject.name);
                    selectedobject = hit.collider.gameObject;
                    isDragging = true;
                    SoundManager.Instance.PlaySFX("Agarrar");
                }
            }
            if (isDragging)
            {
                Vector3 pos = mousePos();
                selectedobject.transform.position = pos;
            }

            if (Input.GetMouseButtonUp(0))
            {
                isDragging = false;
            }

            Vector3 mousePos()
            {
                return _camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f));
            }
        }
    }
}