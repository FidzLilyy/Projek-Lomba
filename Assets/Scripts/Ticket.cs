using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Ticket : MonoBehaviour, IPointerClickHandler
{
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        anim.SetTrigger("isClicked");
        GameManager.instance.TicketSystem();
    }

    public void DeactiveObject()
    {
        gameObject.SetActive(false);
    }
}
