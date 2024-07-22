using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private float staminaValue;
    private float cleanValue;
    private int ticketValue = 0;
    private int ticketTarget;
    private int dayValue = 1;

    private void Awake()
    {
        instance = this;
    }

    public void IncreaseDay()
    {
        if (dayValue != 5)
        {
            dayValue += 1;
        }
        else
        {
            dayValue = 1;
        }
        Debug.Log(dayValue);
    }

    public void TicketSystem()
    {
        ticketValue++;
        if(ticketValue >= ticketTarget)
        {
            ticketValue = 0;
            Uang.uang = 30000;
            IncreaseDay();
        }
    }

    public int GetDayValue()
    {
        return dayValue;
    }

    public void SkipTicket()
    {
        ticketValue = 0;
        Uang.uang = 20000;
        IncreaseDay();
    }

    public float GetStaminaValue(float stamina)
    {
        return staminaValue = stamina;
    }

    public float GetCleanValue(float clean)
    {
        return cleanValue = clean;
    }

    public void GetTicketObject()
    {
        ticketTarget = Random.Range(1, 10);
        for(int i = 0; i < ticketTarget; i++)
        {
            GameObject ticket = TicketsPool.instance.GetObjectPool();
            if(ticket != null)
            {
                ticket.SetActive(true);
            }
        }
    }
}
