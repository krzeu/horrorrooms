using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    public Material lens;

    private Light _light;
    private AudioSource _audioSource;
    void Start()
    {
        _light = GetComponentInChildren<Light>();
        _audioSource = GetComponent<AudioSource>();
    }

    public void LightOn()
    {
        _audioSource.Play();
        lens.EnableKeyword("_Emission");
        _light.enabled = true;
    }

    public void LightOff()
    {
        _audioSource.Play();
        lens.DisableKeyword("_Emission");
        _light.enabled = false;
    }
    // denna kod är för ficklampan, plcokar jag upp lampan så sättts ljuset på och droppar jag den så stängs den av
}
