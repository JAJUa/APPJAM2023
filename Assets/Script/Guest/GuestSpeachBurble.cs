using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuestSpeachBurble : MonoBehaviour
{
    [SerializeField] private Text _text;
    [SerializeField] private GameObject _speachBurbleLayer;
    [SerializeField] private Button _button;

    public void Talk(GuestAct act, Action callBack)
    {
        _speachBurbleLayer.SetActive(true);
        _text.text = act.text;

        _button.onClick.AddListener(new(() =>
        {
            callBack?.Invoke();
            _button.onClick.RemoveAllListeners();
        }));
    }

    public void FinishTalk()
    {
        _speachBurbleLayer.SetActive(false);
    }

    public void Talk(GuestAct act)
    {
        Talk(act, null);
    }
}
