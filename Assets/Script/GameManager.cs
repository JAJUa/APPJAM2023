using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance != null)
            {
                return _instance;
            }

            GameObject g = new GameObject("SoundManager");
            _instance = g.AddComponent<GameManager>();
            DontDestroyOnLoad(g);
            return _instance;
        }
    }

    public void AddToMakedFood(Foods food)
    {
        if(makedFood == null)
        {
            makedFood = new Foods[] { };
        }
        System.Array.Resize(ref makedFood, makedFood.Length + 1);
        makedFood[makedFood.Length - 1] = food;
    }

    private void FixedUpdate()
    {
        if (makedFood == null)
        {
            if (makedFood.Length >= 2)
            {
                SceneManager.LoadScene("GamePlayScene");
            }
        }
    }

    public GameState gameState = GameState.StartGame;

    /// <summary>
    /// 요리를 통해 완성한 음식값
    /// </summary>
    public Foods[] makedFood;

    /// <summary>
    /// 매개변수 : 여의주 변화량
    /// </summary>
    private int _dragonBallCount;
    public int DragonBallCount
    {
        get => _dragonBallCount;
        set
        {
            if (DragonBallCount != value)
            {
                int origin = DragonBallCount;
                _dragonBallCount = value;
            }
        }
    }

    private int _dragonBallShardCount;
    public int DragonBallShardCount
    {
        get => _dragonBallShardCount;
        set
        {
            if (DragonBallShardCount != value)
            {
                int origin = DragonBallShardCount;
                _dragonBallShardCount = value;

                if (DragonBallShardCount >= 3)
                {
                    DragonBallShardCount -= 3;
                    DragonBallCount++;
                }
            }
        }
    }

    public GuestData CurrentGuestData;
    public List<GuestData> CurruntDaysGuestPool;
    public int curruntDay;
}

public enum GameState
{
    StartGame,
    FinishCooking
}