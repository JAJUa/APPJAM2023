using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuestCharacter : NPC
{
    private GuestData _guestData;
    private Action<bool> _guestFinishCallBack;

    public void StartGuestAct(GuestData guestData, Action cookingStartCallBack, Action<bool> finishCallBack)
    {
        _guestData = guestData;

        _spriteRenderer.sprite = _guestData.defaultSprite;
        _guestFinishCallBack = finishCallBack;

        FirstAct(cookingStartCallBack);
    }

    private void FirstAct(Action callBack)
    {
        Act(_guestData.startAct, () => { _speachBurble.FinishTalk(); callBack?.Invoke(); });
    }

    public void RecieveFood(Foods food)
    {
        Action<bool> act = (isSame) =>
        {
            _guestFinishCallBack?.Invoke(isSame);
            _speachBurble.FinishTalk();
        };

        if (food == _guestData.neededFood)
        {
            GoodReaction(() => act?.Invoke(true));
        }
        else
        {
            BadReaction(() => act?.Invoke(false));
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
}
