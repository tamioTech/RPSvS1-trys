using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SlotDrop : MonoBehaviour, IDropHandler
{
    GameHandler gameHandler;
    SFXManager sfxManager;

    Draggable draggable;
    bool isDragging;

    private void Awake()
    {
        gameHandler = FindObjectOfType<GameHandler>();
        sfxManager = FindObjectOfType<SFXManager>();
        draggable = FindObjectOfType<Draggable>();
        isDragging = draggable.IsDragging();
    }

    private void Update()
    {
        isDragging = draggable.IsDragging();
    }

    public void OnDrop(PointerEventData eventData)
    {
        if(eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<Transform>().position = this.transform.position;
            sfxManager.playCardDroppedSFX();
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isDragging) return;
        print(isDragging);
        if(gameObject.tag == "P1a")
        {
            gameHandler.P1AChoice(collision.tag);
        }
        else if (gameObject.tag == "P1b")
        {
            gameHandler.P1BChoice(collision.tag);
        }
    }

    public void GloveButton()
    {
        print("gloves up");
    }

    public void NewsPaperButton()
    {
        print("extra extra read all about it");
    }

    public void SwordButton()
    {
        print("It cuts like a knife");
    }

}
