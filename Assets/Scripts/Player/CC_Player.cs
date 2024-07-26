using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CC_Player : MonoBehaviour
{
    [ SerializeField] private CharacterController cc_player;

    [SerializeField] private Vector3 vectorPlayer;

    [SerializeField] private float speed;
    // Start is called before the first frame update
    void Start()
    {
        cc_player = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        float movX = Input.GetAxis("Horizontal");
        float movY = Input.GetAxis("Vertical");
        
        vectorPlayer = new Vector3(movX,0,movY) * speed;
        vectorPlayer = transform.TransformDirection(vectorPlayer);
        StartCoroutine(movDelay(vectorPlayer));
    }
    
    IEnumerator movDelay(Vector3 vecPlayer)
    {
        float num = Random.Range(0.1f, 0.15f);
        yield return new WaitForSeconds(num);
        cc_player.SimpleMove(vecPlayer);
    }
}
