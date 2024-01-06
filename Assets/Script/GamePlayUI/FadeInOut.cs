using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInOut : MonoBehaviour
{
    [SerializeField] private Image _image;

    private bool _isBlack;
    private float _fadingTime;
    private float _remainingFadeTime;

    private void Update()
    {
        if (_remainingFadeTime > 0)
        {
            _remainingFadeTime -= Time.deltaTime;
            Color c = _image.color;
            if (_isBlack)
            {
                c.a = 1 - _remainingFadeTime / _fadingTime;
            }
            else
            {
                c.a = _remainingFadeTime / _fadingTime;
            }
            _image.color = c;
        }
    }

    public void FadeIn(float fadingTime)
    {
        _isBlack = true;
        _fadingTime = fadingTime;
        _remainingFadeTime = _fadingTime;
    }

    public void FadeOut(float fadingTime)
    {
        _isBlack = false;
        _fadingTime = fadingTime;
        _remainingFadeTime = _fadingTime;
    }
}
