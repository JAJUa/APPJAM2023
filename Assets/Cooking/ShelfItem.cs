using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelfItem : MonoBehaviour
{
    public bool OnItem;

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
}
