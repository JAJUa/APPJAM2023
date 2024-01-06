using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if(_instance != null)
            {
                return _instance;
            }

            GameObject g = new GameObject("SoundManager");
            _instance = g.AddComponent<GameManager>();
            DontDestroyOnLoad(g);
            return _instance;
        }
    }

    /// <summary>
    /// 매개변수 : 여의주 변화량
    /// </summary>
    private int _dragonBallCount;
    public int DragonBallCount
    {
        get => _dragonBallCount;
        set
        {
            if(DragonBallCount != value)
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
            if(DragonBallShardCount != value)
            {
                int origin = DragonBallShardCount;
                _dragonBallShardCount = value;

                if(DragonBallShardCount >= 3)
                {
                    DragonBallShardCount -= 3;
                    DragonBallCount++;
                }
            }
        }
    }
}
