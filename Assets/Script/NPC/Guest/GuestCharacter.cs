using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuestCharacter : NPC
{
    private GuestData _guestData;

    public void StartGuestAct(GuestData guestData, Action cookingStartCallBack)
    {
        _guestData = guestData;

        _spriteRenderer.sprite = _guestData.defaultSprite;

        FirstAct(cookingStartCallBack);
    }

    private void FirstAct(Action callBack)
    {
        Act(_guestData.startAct, () => { _speachBurble.FinishTalk(); callBack?.Invoke(); });
    }

    public void RecieveFood(Foods food, Action<bool> finishCallBack)
    {
        Action<bool> act = (isSame) =>
        {
            finishCallBack?.Invoke(isSame);
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
