using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicketsPool : MonoBehaviour
{
    public static TicketsPool instance;

    public int ticketSpawnValue = 20;
    public GameObject ticketObject;

    public List<GameObject> tickets = new List<GameObject>();

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        for(int i = 0; i < ticketSpawnValue; i++)
        {
            GameObject obj = Instantiate(ticketObject, transform);
            obj.SetActive(false);
            tickets.Add(obj);
        }
    }

    public GameObject GetObjectPool()
    {
        for (int i = 0; i < tickets.Count; i++)
        {
            if (!tickets[i].activeInHierarchy)
            {
                return tickets[i];
            }

        }
        return null;
    }
}
