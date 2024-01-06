using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class ShelfItem : MonoBehaviour
{
    public bool OnItem;
    public bool SubmitTable;
    public GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Material"))
        {
            OnItem = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Material"))
        {
            OnItem = false;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        //submit?
        if (SubmitTable)
        {
            HoldAndDropFood holdAndDropFood = other.GetComponent<HoldAndDropFood>();
            if (holdAndDropFood.isInLine && !holdAndDropFood.isBeingHeld)
            {
                FinalFood finalFood = other.GetComponent<FinalFood>();
                if (finalFood != null)
                {
                    Debug.Log("TEST3");
                    gameManager.AddToMakedFood(finalFood.makedFood);
                    Destroy(other.gameObject);
                }
            }
        }
    }

    private void FixedUpdate()
    {
        
    }
}
