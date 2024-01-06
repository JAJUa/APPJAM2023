using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        List<Foods> l = makedFood.ToList();
        l.Add(food);
        makedFood = l.ToArray();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            SceneManager.LoadScene("GameEndScene");
        }
    }

    public GameState gameState = GameState.StartGame;

    /// <summary>
    /// �丮�� ���� �ϼ��� ���İ�
    /// </summary>
    public Foods[] makedFood { get
        {
            if(_makedFood == null)
            {
                _makedFood = new Foods[] { };
            }
            return _makedFood;
        }
        set
        {
            _makedFood = value;
        }
    }
    Foods[] _makedFood;

    /// <summary>
    /// �Ű����� : ������ ��ȭ��
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