using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialClick : MonoBehaviour
{
    [SerializeField] GameObject Food;
    private void OnMouseDown()
    {
        Instantiate(Food);
    }
}
