using System;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
public class CamFX : MonoBehaviour
{
    public static CamFX Instance;
    public VolumeProfile ppVol;
    public FilmGrain fmGrain;
    private void Awake() => Instance = this;

    private void Start()
    {
        ppVol.TryGet(out fmGrain);
    }

    private void OnShake(float duration, float strength)
    {
        transform.DOShakePosition(duration, strength);
        transform.DOShakeRotation(duration, strength);
    }

    public void Shake(float duration, float strength) => Instance.OnShake(duration, strength);
}