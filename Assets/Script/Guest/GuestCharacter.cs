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

    }

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

    private void Act(GuestAct[] actData, Action callBack)
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
