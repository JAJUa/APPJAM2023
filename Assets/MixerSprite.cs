using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MixerSprite : MonoBehaviour
{
    public SpriteRenderer spriteR;
    public Sprite ice, milk, VibBase1, VibBase2, VibBase3, Base1, Base2, Base3;
    public bool Mixing;
    public bool OpenMixer;
    public int Tempi;

    public void ChangeSprite(int i)
    {
        Tempi = i;

        if (i == 0)
            spriteR.sprite = null;
        else if(i == 1)
            spriteR.sprite = ice;
        else if (i == 2)
            spriteR.sprite = milk;

        if(i >= 3)
            StartCoroutine(RoastOven(i));

    }
    public IEnumerator RoastOven(int i)
    {

        if (i == 3)
            spriteR.sprite = VibBase1;
        else if (i == 4)
            spriteR.sprite = VibBase2;
        else if (i == 5)
            spriteR.sprite = VibBase3;

        Mixing = true;
        yield return new WaitForSeconds(3f);

        if (i == 3)
            spriteR.sprite = Base1;
        else if (i == 4)
            spriteR.sprite = Base2;
        else if (i == 5)
            spriteR.sprite = Base3;

        OpenMixer = true;
    }
}
