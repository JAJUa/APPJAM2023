using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    [SerializeField] protected GuestSpeachBurble _speachBurble;
    [SerializeField] protected Image _image;

    protected void Act(GuestAct[] actData, Action callBack)
    {
        int actIndex = 0;
        void NextAct()
        {
            if (actIndex < actData.Length)
            {
                if (actData[actIndex].guestSprite != null)
                {
                    _image.sprite = actData[actIndex].guestSprite;
                }
                if (actData[actIndex].clip != null)
                {
                    SoundManager.Instance.Play(actData[actIndex].clip);
                }
                _speachBurble.Talk(actData[actIndex], NextAct);
            }
            else
            {
                callBack?.Invoke();
            }
            actIndex++;
        }

        NextAct();
    }
}
