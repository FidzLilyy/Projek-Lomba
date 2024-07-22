using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipTicket : MonoBehaviour
{
    public void SkipTicketMiniGame()
    {
        GameManager.instance.SkipTicket();
        for(int i = 0; i < TicketsPool.instance.tickets.Count; i++)
        {
            if (TicketsPool.instance.tickets[i].activeInHierarchy)
            {
                TicketsPool.instance.tickets[i].SetActive(false);
            }
        }
    }
}
