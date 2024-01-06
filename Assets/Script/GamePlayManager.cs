using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GamePlayManager : MonoBehaviour
{
    [Header("손님")]
    [SerializeField] private GuestCharacter _guestCharacter;
    [SerializeField] private GuestData[][] _guestDatas;
    [Header("페이드 인아웃")]
    [SerializeField] private FadeInOut _fadeInOut;
    [Header("날짜 전환 연출")]
    [SerializeField] private float _dayChangeFadingTime;
    [SerializeField] private Text _dayUIText;
    [SerializeField] private FadeInOut _dayUIfade;
    [Header("손님<->요리 전환 연출")]
    [SerializeField] private float _cookingFadingTime;

    public int curruntDay { get; private set; }

    private void Start()
    {
        _fadeInOut.SetFade(true);
        if (GameManager.Instance.gameState == GameState.StartGame)
        {
            StartDay();
        }
        else
        {
            _guestCharacter.WaitFood(() => _guestCharacter.RecieveFood(GameManager.Instance.makedFood, ProcessGuestResult));
        }
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
        GameManager.Instance.CurruntDaysGuestPool = _guestDatas[curruntDay - 1].ToList();
        OnStartedDay?.Invoke();

        _dayUIText.text = "Day " + curruntDay.ToString();
        _dayUIfade.FadeIn(_dayChangeFadingTime);

        StartCoroutine(Delay());
        IEnumerator Delay()
        {
            yield return new WaitForSeconds(_dayChangeFadingTime + 1);
            _dayUIfade.FadeOut(_dayChangeFadingTime);
            _fadeInOut.FadeOut(_dayChangeFadingTime);
            SummonRandomGuest();
        }
    }

    private void SummonRandomGuest()
    {
        GameManager.Instance.CurrentUntGuestData = GameManager.Instance.CurruntDaysGuestPool[Random.Range(0, GameManager.Instance.CurruntDaysGuestPool.Count)];
        GameManager.Instance.CurruntDaysGuestPool.Remove(GameManager.Instance.CurrentUntGuestData);

        _guestCharacter.StartGuestAct(GameManager.Instance.CurrentUntGuestData, StartCooking);
    }

    private void StartCooking()
    {
        //나중에 연결해야됨
    }

    private void ProcessGuestResult(bool isSuccess)
    {
        if (isSuccess)
        {
            GameManager.Instance.DragonBallShardCount++;
        }

        StartCoroutine(Delay());
        IEnumerator Delay()
        {
            yield return new WaitForSeconds(1);
            if (GameManager.Instance.CurruntDaysGuestPool.Count > 0)
            {
                SummonRandomGuest();
            }
        }
    }
}
