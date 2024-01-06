using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseDrag : MonoBehaviour
{
    public Vector3 LoadedPos;
    float startPosx;
    float startPosY;
    public bool isBeingHeld = false;
    public bool isInLine;
    float timelinePosY;
    bool ClickOn;
    bool EnterItem;

    private void Start()
    {
        LoadedPos = this.transform.position;
    }
    private void Update()
    {
        if (isBeingHeld)
        {
            Vector2 mousePos;
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            this.gameObject.transform.position = new Vector2(mousePos.x - startPosx, mousePos.y - startPosY);
        }
    }

    public void DropBass()
    {
        isBeingHeld = false;
        this.gameObject.transform.position = LoadedPos;
    }


    #region 마우스 드래그앤 드롭



    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0) && !EnterItem)
        {
            if (!ClickOn)
            {
                isBeingHeld = true;
                Vector3 mousePos;
                mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);


                startPosx = mousePos.x - this.transform.position.x;
                startPosY = mousePos.y - this.transform.position.y;
            }
            else
            {
                isBeingHeld = false;
                this.gameObject.transform.position = LoadedPos;
            }


        }
    }

    private void OnMouseUp()
    {
        if (ClickOn)
            ClickOn = false;
        else
            ClickOn = true;
    }



    #endregion


    #region 타임라인이랑 맞는지

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Material"))
        {
            EnterItem = true;
        }
        if (other.CompareTag("Material"))
        {
            timelinePosY = other.transform.position.y;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Material"))
        {
            EnterItem = false;
        }
        if (other.CompareTag("Material"))
        {
            isInLine = false;
        }
    }


    #endregion
}
