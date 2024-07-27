using System;
using System.Collections;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using Random = UnityEngine.Random;

public class CamFX : MonoBehaviour
{
    public static CamFX Instance;
    public Camera cam;
    public VolumeProfile ppVol;
    public FilmGrain fmGrain;
    public float ShakeTimer = 3;
    private float DefaultShakeTimer;
    public bool activeRandomTimer = false;
    private void Awake() => Instance = this;

    private void Start()
    {
        DefaultShakeTimer = ShakeTimer;
        cam = Camera.main;
        ppVol.TryGet(out fmGrain);
    }

    private void Update()
    {
        if (activeRandomTimer)
        {
            ShakeTimer -= Time.deltaTime;
            if (ShakeTimer <= 0)
            {
                OnShake(.2f,.3f);
                ShakeTimer = DefaultShakeTimer;
            }
        }
    }

    private void OnShake(float duration, float strength)
    {
        print("hola");
        cam.transform.DOShakePosition(duration, strength);
        cam.transform.DOShakeRotation(duration, strength);
    }
    
    public void ShakeCamNavigation(float duration, float strength)
    {
        OnShake(duration,strength);
    }

    public void ActiveShakeTimer()
    {
        activeRandomTimer = true;
    }
    
    public void Shake(float duration, float strength) => Instance.OnShake(duration, strength);
}