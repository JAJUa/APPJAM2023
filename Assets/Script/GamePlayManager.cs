using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayManager : MonoBehaviour
{
    [Header("날짜 전환 연출")]
    [SerializeField] private float _dayChangeFadingTime;
    [SerializeField] private FadeInOut _fadeInOut;
    [SerializeField] private Text _dayUIText;
    [SerializeField] private FadeInOut _dayUIfade;

    public int curruntDay { get; private set; }

    private void Start()
    {
        _fadeInOut.SetFade(true);
        StartDay();
    }

    public event Action OnFinishedDay;
    public void FinishDay()
    {
        OnFinishedDay?.Invoke();

        _fadeInOut.FadeIn(_dayChangeFadingTime);

        StartCoroutine(Delay());
        IEnumerator Delay()
        {
            yield return new WaitForSeconds(_dayChangeFadingTime);
            StartDay();
        }
    }

    public event Action OnStartedDay;
    private void StartDay()
    {
        curruntDay++;
        OnStartedDay?.Invoke();

        _dayUIText.text = "Day " + curruntDay.ToString();
        _dayUIfade.FadeIn(_dayChangeFadingTime);

        StartCoroutine(Delay());
        IEnumerator Delay()
        {
            yield return new WaitForSeconds(_dayChangeFadingTime + 1);
            _dayUIfade.FadeOut(_dayChangeFadingTime);
            _fadeInOut.FadeOut(_dayChangeFadingTime);
        }
    }
}
