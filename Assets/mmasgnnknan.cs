using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mmasgnnknan : MonoBehaviour
{
    public static mmasgnnknan _mmasgnnknan;
    public int counter;
    public int bad;
    public int good;
    // Start is called before the first frame update
    private void Awake()
    {
        _mmasgnnknan = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (counter >= 3)
        {
            if(bad<good)
            {
                GameManager.Instance.FinishingMinigame();
            }  
            if(bad> good)
            {
                GameManager.Instance.FinishingMinigame();
            }
            GameManager.Instance.FinishingMinigame(GameManager.GameState.plant);
        }
    }
}
