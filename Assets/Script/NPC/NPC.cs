using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField] protected GuestSpeachBurble _speachBurble;
    [SerializeField] protected SpriteRenderer _spriteRenderer;

    protected void Act(GuestAct[] actData, Action callBack)
    {
        int actIndex = 0;
        void NextAct()
        {
            if (actIndex < actData.Length)
            {
                if (actData[actIndex].guestSprite != null)
                {
                    _spriteRenderer.sprite = actData[actIndex].guestSprite;
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
