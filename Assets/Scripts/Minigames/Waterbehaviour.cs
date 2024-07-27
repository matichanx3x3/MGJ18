using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waterbehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroyWater());
    }

    private IEnumerator DestroyWater()
    {
        yield return new WaitForSeconds(1);
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.y <= 2)
        {
            Destroy(this.gameObject);
        }
    }
}
