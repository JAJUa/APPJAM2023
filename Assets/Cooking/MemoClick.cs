using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MemoClick : MonoBehaviour
{
    [SerializeField] Button MemoBack;

    private void Start()
    {
        MemoBack.onClick.AddListener(Back);
    }

    private void OnMouseUp()
    {
        MemoBack.gameObject.SetActive(true);
    }

    void Back()
    {
        MemoBack.gameObject.SetActive(false);
    }
}
