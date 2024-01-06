using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInOut : MonoBehaviour
{
    [SerializeField] private Graphic _graphic;

    private bool _isShow;
    private float _fadingTime;
    private float _remainingFadeTime;

    private Action _callBack;

    private void Awake()
    {
        _graphic.enabled = false;
    }

    private void Update()
    {
        if (_remainingFadeTime > 0)
        {
            _remainingFadeTime -= Time.deltaTime;

            if (_remainingFadeTime <= 0)
            {
                _callBack?.Invoke();
                _callBack = null;
                
                _graphic.enabled = _isShow;
            }
            else
            {
                _graphic.enabled = true;
            }

            Color c = _graphic.color;
            if (_isShow)
            {
                c.a = 1 - _remainingFadeTime / _fadingTime;
            }
            else
            {
                c.a = _remainingFadeTime / _fadingTime;
            }
            _graphic.color = c;
        }
    }

    /// <summary>
    /// 암전
    /// </summary>
    public void FadeIn(float fadingTime)
    {
        _isShow = true;
        _fadingTime = fadingTime;
        _remainingFadeTime = _fadingTime;
        _callBack = null;
    }

    /// <summary>
    /// 복원
    /// </summary>
    public void FadeOut(float fadingTime)
    {
        _isShow = false;
        _fadingTime = fadingTime;
        _remainingFadeTime = _fadingTime;
        _callBack = null;
    }

    public void FadeOut(float fadingTime, Action callBack)
    {
        FadeOut(fadingTime);
        _callBack = callBack;
    }

    public void FadeIn(float fadingTime,Action callBack)
    {
        FadeIn(fadingTime);
        _callBack = callBack;
    }

    public void SetFade(bool isShow)
    {
        if (!isShow)
        {
            _graphic.enabled = false;
            return;
        }

        _graphic.enabled = true;
        Color c = _graphic.color;
        if (isShow)
        {
            c.a = 1;
        }
        else
        {
            c.a = 0;
        }
        _graphic.color = c;
    }
}
