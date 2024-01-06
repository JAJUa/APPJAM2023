using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuestCharacter : MonoBehaviour
{
    [SerializeField] private GuestSpeachBurble _speachBurble;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private GuestData _guestData;
    private Action<bool> _guestFinishCallBack;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void StartGuestAct(GuestData guestData, Action cookingStartCallBack, Action<bool> recieveFoodCallBack)
    {
        _guestData = guestData;

        _spriteRenderer.sprite = _guestData.defaultSprite;
        _guestFinishCallBack = recieveFoodCallBack;

        FirstAct(cookingStartCallBack);
    }

    private void FirstAct(Action callBack)
    {
        Act(_guestData.startAct, callBack);
    }

    public void RecieveFood(Foods food)
    {
        if (food == _guestData.neededFood)
        {
            GoodReaction(() => _guestFinishCallBack?.Invoke(true));
        }
        else
        {
            BadReaction(() => _guestFinishCallBack?.Invoke(false));
        }
    }

    private void GoodReaction(Action callBack)
    {
        Act(_guestData.goodReaction, callBack);
    }

    private void BadReaction(Action callBack)
    {
        Act(_guestData.badReaction, callBack);
    }

    private void Act(GuestAct[] actData, Action callBack)
    {
        int actIndex = 0;
        void NextAct()
        {
            actIndex++;
            if (actIndex < actData.Length)
            {
                _speachBurble.Talk(actData[actIndex], NextAct);
            }
            else
            {
                callBack?.Invoke();
            }
        }

        _speachBurble.Talk(actData[actIndex], NextAct);
    }
}
