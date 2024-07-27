using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMov : MonoBehaviour
{
    [SerializeField] private Camera cam;
    
    [SerializeField] private float m_rotationSpeedX;
    [SerializeField] private float m_rotationSpeedY;
    [SerializeField] private float m_yRotationLimit = 90f;
    [SerializeField]private float m_MouseDeltaX;
    [SerializeField]private float m_MouseDeltaY;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.enableRot)
        {
            m_MouseDeltaY += m_rotationSpeedX*Input.GetAxis("Mouse X");
            m_MouseDeltaX -= m_rotationSpeedY*Input.GetAxis("Mouse Y");
            
            m_MouseDeltaX = Mathf.Clamp(m_MouseDeltaX, -m_yRotationLimit, m_yRotationLimit);
            StartCoroutine(camDelay(m_MouseDeltaX, m_MouseDeltaY));
            
        }
        
    }

    IEnumerator camDelay(float x, float y)
    {
        float num = Random.Range(0.1f, 0.15f);
        yield return new WaitForSeconds(num);
        cam.transform.eulerAngles = new Vector3(x, y, 0);
    }

}
