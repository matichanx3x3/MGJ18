using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class transitionManager : MonoBehaviour
{
    public float timer = 0;

    public GameObject textRobot;
    public GameObject textHumano;
    public bool n1 = false;
    public bool n2 = true;
    public bool n3 = true;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (!n1 && timer > 3)
        {
            n1 = true;
            n2 = false;
            textHumano.SetActive(true);
            SoundManager.Instance.PlaySFX("DiagHumano");
            timer = 0;
        }
        if (!n2 && timer > 4)
        {
            n2 = true;
            n3 = false;
            textRobot.SetActive(true);
            textHumano.SetActive(false);
            
            SoundManager.Instance.PlaySFX("DiagRobot");
            timer = 0;
        }
        if (!n3 && timer > 4)
        {
            n3 = true;
            SceneManager.LoadScene("TestCasa");
            timer = 0;
        }
        
    }
}
