using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GraphicsConfigurator.API.URP;
using UnityEngine.Rendering.Universal;
using ShadowResolution = UnityEngine.Rendering.Universal.ShadowResolution;

public class GraphicsSettingsTest : MonoBehaviour
{
    public void RenderScaleChange(float scale)
    {
        if(scale >= 0.2 && scale <= 2)
        {
            Configuring.CurrentURPA.RenderScale(scale);
        }
    }

    public void UpscalingFilterChange(int change)
    {
        if(change == 0)
            Configuring.CurrentURPA.UpscalingFilter(UpscalingFilterSelection.Auto);
        else if (change == 1)
            Configuring.CurrentURPA.UpscalingFilter(UpscalingFilterSelection.Linear);
        else if (change == 2)
            Configuring.CurrentURPA.UpscalingFilter(UpscalingFilterSelection.Point);
        else if (change == 3)
            Configuring.CurrentURPA.UpscalingFilter(UpscalingFilterSelection.FSR);
    }

    public void MainLightShadowsToggle(bool value)
    {
        Configuring.CurrentURPA.MainLightShadowsCasting(value);
    }

    public void AddLightShadowsToggle(bool value)
    {
        Configuring.CurrentURPA.AdditionalLightsShadowsCasting(value);
    }
}
