using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GamePlayManager : MonoBehaviour
{
    [SerializeField] private AudioClip _bgmClip;
    [Header("손님")]
    [SerializeField] private GuestCharacter _guestCharacter;
    [SerializeField] private GuestData[] _day1GuestPool;
    [SerializeField] private GuestData[] _day2GuestPool;
    [SerializeField] private GuestData[] _day3GuestPool;
    [SerializeField] private GuestData[] _day4GuestPool;
    [SerializeField] private GuestData[] _day5GuestPool;
    private GuestData[][] _guestDatas
    {
        get
        {
            return new GuestData[][]
            {
                _day1GuestPool,
                _day2GuestPool,
                _day3GuestPool,
                _day4GuestPool,
                _day5GuestPool,
            };
        }
    }
    [Header("페이드 인아웃")]
    [SerializeField] private FadeInOut _fadeInOut;
    [Header("날짜 전환 연출")]
    [SerializeField] private float _dayChangeFadingTime;
    [SerializeField] private Text _dayUIText;
    [SerializeField] private FadeInOut _dayUIfade;
    [Header("손님<->요리 전환 연출")]
    [SerializeField] private float _cookingFadingTime;

    public int curruntDay { get => GameManager.Instance.curruntDay; private set => GameManager.Instance.curruntDay = value; }

    private void Start()
    {
        if (SoundManager.Instance.CurruntBgm != _bgmClip)
        {
            SoundManager.Instance.SetBgm(_bgmClip);
        }

        _fadeInOut.SetFade(true);
        if (GameManager.Instance.gameState == GameState.StartGame)
        {
            StartDay();
        }
        else
        {
            _fadeInOut.FadeOut(_dayChangeFadingTime);
            _guestCharacter.WaitFood(() => _guestCharacter.RecieveFood(GameManager.Instance.makedFood, ProcessGuestResult));
            GameManager.Instance.makedFood = new Foods[] { };
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
            if (_guestDatas.Length > curruntDay)
            {
                StartDay();
            }
            else
            {
                FinishGame();
            }
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
            if (GameManager.Instance.CurruntDaysGuestPool.Count > 0)
            {
                SummonRandomGuest();
            }
            else
            {
                FinishDay();
            }
        }
    }

    private void SummonRandomGuest()
    {
        GameManager.Instance.CurrentGuestData = GameManager.Instance.CurruntDaysGuestPool[Random.Range(0, GameManager.Instance.CurruntDaysGuestPool.Count)];
        GameManager.Instance.CurruntDaysGuestPool.Remove(GameManager.Instance.CurrentGuestData);

        _guestCharacter.StartGuestAct(GameManager.Instance.CurrentGuestData, StartCooking);
    }

    private void StartCooking()
    {

        GameManager.Instance.gameState = GameState.FinishCooking;
        _fadeInOut.FadeIn(1, () => SceneManager.LoadScene("TempCookingScene"));
    }

    private void FinishGame()
    {
        _fadeInOut.FadeIn(1, () => SceneManager.LoadScene("GameEndScene"));
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
            else
            {
                FinishDay();
            }
        }
    }
}
