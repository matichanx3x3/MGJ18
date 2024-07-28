using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        SoundManager.Instance.PlayMusic("IntroUI");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnterGame()
    {
        SoundManager.Instance.InstantStop("IntroUI");
        SceneManager.LoadScene("TestCasa");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
