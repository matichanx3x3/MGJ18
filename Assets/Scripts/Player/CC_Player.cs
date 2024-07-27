using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CC_Player : MonoBehaviour
{
    [ SerializeField] private CharacterController cc_player;

    [SerializeField] private Vector3 vectorPlayer;

    [SerializeField] private float speed;

    public GameObject test;
    // Start is called before the first frame update
    void Start()
    {
        cc_player = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.Instance.inMiniGame)
        {
            if (GameManager.Instance.enableMov)
            {
                float movX = Input.GetAxis("Horizontal");
                float movY = Input.GetAxis("Vertical");
        
                vectorPlayer = new Vector3(movX,0,movY) * speed;
                vectorPlayer = transform.TransformDirection(vectorPlayer);
                StartCoroutine(movDelay(vectorPlayer));
            }
        }
        
        if (Input.GetKey(KeyCode.J))
        {
            CamFX.Instance.ShakeCamNavigation(.2f,.3f);
            GameManager.Instance.EnterMiniGame();
            //GameManager.Instance.testVP(true);
        }
        if (Input.GetKey(KeyCode.K))
        {
            GameManager.Instance.FinishingMinigame();
           // GameManager.Instance.testVP(false);
        }

        if (Input.GetKey(KeyCode.N))
        {
            GameManager.Instance.goodGame++;
        }
        
        if (GameManager.Instance.goodGame > 5)
        {
            Debug.Log("hola");
            CamFX.Instance.ActiveShakeTimer();
        }

        if (Input.GetKey(KeyCode.U))
        {
            test.SetActive(true);
        }
    }
    
    IEnumerator movDelay(Vector3 vecPlayer)
    {
        float num = Random.Range(0.1f, 0.15f);
        yield return new WaitForSeconds(num);
        cc_player.SimpleMove(vecPlayer);
    }
}
