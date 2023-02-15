using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class LightingManager : MonoBehaviour
{
    [SerializeField] private Light DirectionalLight;
    [SerializeField] private LightingPreset Preset;
    [SerializeField, Range(0, 24)] private float CurrentTimeOfDay = 12f;
    private float DesiredTimeOfDay = 0f;
    private bool ShouldTransition;

    [SerializeField] private float TransitionSpeed = 1f;

    private enum DayState
    {
        DAY, NIGHT
    };

    DayState _dayState = DayState.DAY;

    private void Update()
    {
        if (Preset == null) return;

        if (Application.isPlaying)
        {
            if(ShouldTransition)
            {

                CurrentTimeOfDay += Time.deltaTime * TransitionSpeed;
                CurrentTimeOfDay %= 24;

                if (CurrentTimeOfDay >= DesiredTimeOfDay && CurrentTimeOfDay < DesiredTimeOfDay + 1f)
                {
                    ShouldTransition = false;
                    CurrentTimeOfDay = DesiredTimeOfDay;
                }
            }
          
            UpdateLighting(CurrentTimeOfDay / 24f);
        }
        else {
            UpdateLighting(CurrentTimeOfDay / 24f);
        }
    }

    public void TransitionToState()
    {

        if(_dayState == DayState.DAY)
        {
            _dayState = DayState.NIGHT;        
        }
        else
        { 
            _dayState = DayState.DAY;
        }

        DesiredTimeOfDay = CurrentTimeOfDay + 12;
        DesiredTimeOfDay%= 24;

        ShouldTransition = true;

    }



    private void UpdateLighting(float timePercent)
    {
        RenderSettings.ambientLight = Preset.AmbientColor.Evaluate(timePercent);
        RenderSettings.fogColor = Preset.FogColor.Evaluate(timePercent);

        if (DirectionalLight != null)
        {
            DirectionalLight.color = Preset.DirectionalColor.Evaluate(timePercent);
            DirectionalLight.transform.localRotation = Quaternion.Euler(new Vector3((timePercent * 360f) - 90f, 170f, 0f));
        }
    }

    private void OnValidate()
    {
        if (DirectionalLight != null)
        {
            return;
        }

        if(RenderSettings.sun != null) 
        { 
            DirectionalLight= RenderSettings.sun;
        }
        else
        {
            Light[] lights = GameObject.FindObjectsOfType<Light>();
            foreach (Light light in lights)
            {
                if (light.type == LightType.Directional)
                {
                    DirectionalLight = light;
                    return;
                }
            }
        }
    }
}
