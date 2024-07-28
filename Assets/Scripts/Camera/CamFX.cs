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
        firstFXGrain();
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
        SoundManager.Instance.PlaySFX("CameraFX");
    }
    
    public void ShakeCamNavigation(float duration, float strength)
    {
        OnShake(duration,strength);
    }

    public void ActiveShakeTimer()
    {
        activeRandomTimer = true;
    }

    public void addFXGrain()
    {
        float intensity = fmGrain.intensity.value;
        fmGrain.intensity.Override(intensity + .1f);    
    }

    public void firstFXGrain()
    {
        fmGrain.intensity.Override(.1f); 
    }
    
    public void Shake(float duration, float strength) => Instance.OnShake(duration, strength);
}