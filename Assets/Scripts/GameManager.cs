using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static bool enableMov = true;
    public static bool enableRot = true;

    [SerializeField] private bool gm_EMOVE;
    [SerializeField] private bool gm_EROT;

    private void Awake()
    {
        gm_EMOVE = enableMov;
        gm_EROT = enableRot;
    }
}
