using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HoldAndDropFood : MonoBehaviour
{
    public bool EnterItem;
    public bool isInLine;
    public bool isBeingHeld = true;
    float startPosx, startPosY;
    float timelinePosX, timelinePosY;

    private void Update()
    {
        if (isBeingHeld)
        {
            Vector2 mousePos;
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            this.gameObject.transform.position = new Vector2(mousePos.x - startPosx, mousePos.y - startPosY);
        }
    }

    #region 마우스 드래그앤 드롭
    
    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0) && !EnterItem)
        {
            if (isInLine && isBeingHeld)
            {
                isBeingHeld = false;
                this.gameObject.transform.position = new Vector3(timelinePosX, timelinePosY, -1f);
                return;
            }
            else if (!isInLine && isBeingHeld)
                Destroy(gameObject);


            if (!isBeingHeld)
            {
                isBeingHeld = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Material"))
        {
            EnterItem = true;
        }
        if (other.CompareTag("shelf"))
        {
            ShelfItem OnItemShelf = other.GetComponent<ShelfItem>();
            if (!OnItemShelf.OnItem)
            {
                isInLine = true;
                timelinePosY = other.transform.position.y;
                timelinePosX = other.transform.position.x;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Material"))
        {
            EnterItem = false;
        }
        if (other.CompareTag("shelf"))
        {
            isInLine = false;
        }
    }

    #endregion

    
}
