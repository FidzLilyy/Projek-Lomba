using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderManager : MonoBehaviour
{
    public Slider staminaSlider;
    public Slider cleanSlider;

    public void SetStaminaValue(float stamina)
    {
        staminaSlider.value += GameManager.instance.GetStaminaValue(stamina);
    }

    public void SetCleanValue(float clean)
    {
        cleanSlider.value += GameManager.instance.GetCleanValue(clean);
    }
}
