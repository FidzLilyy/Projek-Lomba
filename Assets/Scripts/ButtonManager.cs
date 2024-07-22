using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public GameObject nextDayButton;
    public GameObject showButton;
    public GameObject skipButton;
    private void Update()
    {
        if(GameManager.instance.GetDayValue() != 5)
        {
            nextDayButton.SetActive(true);
            showButton.SetActive(false);
            skipButton.SetActive(false);
        }
        else
        {
            nextDayButton.SetActive(false);
            showButton.SetActive(true);
            skipButton.SetActive(true);
        }
    }
}
