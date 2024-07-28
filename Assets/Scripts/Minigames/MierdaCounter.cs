using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MierdaCounter : MonoBehaviour
{
    public static MierdaCounter _mierdaCounter;
    public int counter = 11;
    public int bien = 0;
    public int mal = 0;

    public Sprite spriteroto;
    public SpriteRenderer spriterenderer;
    // Start is called before the first frame update
    private void Awake()
    {
        _mierdaCounter = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (counter == 0 && (bien - mal) > 0 )
        {
            GameManager.Instance.FinishingMinigame();
        }
        if (counter == 0 && (mal - bien) > 0 )
        {
            GameManager.Instance.FinishingMinigame(GameManager.GameState.window);
        }
        if (mal >= 6)
        {
            spriterenderer.sprite = spriteroto;
        }
    }
    public void SumarLimpiaBien()
    {
        counter--;
        bien++;
    }
    public void SumarLimpiaMal()
    {
        counter--;
        mal++;
    }
}
