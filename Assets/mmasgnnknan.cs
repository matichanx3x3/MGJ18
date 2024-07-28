using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mmasgnnknan : MonoBehaviour
{
    public static mmasgnnknan _mmasgnnknan;
    public int counter;
    public int bad;
    public int good;
    bool done;
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
        if (counter >= 3 && !done)
        {
            if(bad<good)
            {
                GameManager.Instance.FinishingMinigame();
                done = true;
            }  
            if(bad>good)
            {
                GameManager.Instance.FinishingMinigame(GameManager.GameState.plant);
                done = true;
            }
            GameManager.Instance.gameDishes = true;
        }
    }
}
