using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GuestCharacter : NPC
{
    [SerializeField] private Image _guestInfoImage;

    private GuestData _guestData { get => GameManager.Instance.CurrentGuestData; set { GameManager.Instance.CurrentGuestData = value; } }

    private void Awake()
    {
        if (_guestData != null)
        {
            _image.sprite = _guestData.defaultSprite;
        }

        image = GetComponentInChildren<Image>();
    }

    Image image;

    private void Update()
    {
        image.enabled = image.sprite != null;
    }

    public void StartGuestAct(GuestData guestData, Action cookingStartCallBack)
    {
        _guestData = guestData;

        _image.sprite = _guestData.defaultSprite;
        _guestInfoImage.enabled = true;
        _guestInfoImage.sprite = _guestData.infoSprite;

        FirstAct(cookingStartCallBack);
    }

    private void FinishGuestAct()
    {
        _guestData = null;
        _speachBurble.FinishTalk();
        _guestInfoImage.enabled = false;
        _image.sprite = null;
    }

    private void FirstAct(Action callBack)
    {
        Act(_guestData.startAct, () => { _speachBurble.FinishTalk(); callBack?.Invoke(); });
    }

    public void RecieveFood(Foods[] food, Action<bool> finishCallBack)
    {
        Action<bool> act = (isSame) =>
        {
            finishCallBack?.Invoke(isSame);
            FinishGuestAct();
        };

        if (CompareFood(food, _guestData.neededFood))
        {
            GoodReaction(() => act?.Invoke(true));
        }
        else
        {
            BadReaction(() => act?.Invoke(false));
        }
    }

    private bool CompareFood(Foods[] a, Foods[] b)
    {
        if (a.Length != b.Length) return false;

        for (int i = 0; i < a.Length; i++)
        {
            if (!b.Contains(a[i])) return false;
        }

        return true;
    }

    public void WaitFood(Action callBack)
    {
        Act(_guestData.waitAct, callBack);
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
