using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OvenWait : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteR;
    [SerializeField] Sprite imptyOven, Coq1, Coq2, roastCoq1, roastCoq2;
    ItemManager itemManager;
    public bool RoastingOven;
    bool OpenOven;
    int Tempi;

    private void Start()
    {
        itemManager = GameObject.Find("ItemManager").GetComponent<ItemManager>();

    }

    public void startCoroutine(int i)
    {
        StartCoroutine(RoastOven(i));
    }
    public IEnumerator RoastOven(int i)
    {
        Tempi = i;

        if (i == 0)
            spriteR.sprite = Coq1;
        else if (i == 1)
            spriteR.sprite = Coq2;

        RoastingOven = true;
        yield return new WaitForSeconds(3f);

        if (i == 0)
            spriteR.sprite = roastCoq1;
        else if (i == 1)
            spriteR.sprite = roastCoq2;

        OpenOven = true;
    }
    private void OnMouseDown()
    {
        if(OpenOven)
        {
            if (Tempi == 0)
                Instantiate(itemManager.roastCoq1);
            else if (Tempi == 1)
                Instantiate(itemManager.roastCoq2);

            RoastingOven = false;
            OpenOven = false;
            spriteR.sprite = imptyOven;
            
        }
    }
}
