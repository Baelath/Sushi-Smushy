using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightFlicker : MonoBehaviour
{
    [SerializeField] [Range(0,1f)] private float multiplier;
    [SerializeField] private float timeScale;

    private Light2D _light;

    private float intensityOriginal;
    private float intensityAlteredMax;
    private float intensityAlteredMin;

    private void Start()
    {

        _light = transform.GetComponent<Light2D>();

        intensityOriginal = _light.intensity;
        intensityAlteredMax = intensityOriginal * (1f + multiplier);
        intensityAlteredMin = intensityOriginal * (1f - multiplier);

        
    }

    private void Update()
    {
        //Debug.LogFormat("{0} {1} {2}", intensityOriginal.ToString(), intensityAlteredMin.ToString(), intensityAlteredMax.ToString());

        if (_light.enabled == true)
        {
            _light.intensity = Mathf.Lerp(intensityAlteredMin, intensityAlteredMax, Mathf.PingPong(Time.time * timeScale, 1));
        }
    }
}


