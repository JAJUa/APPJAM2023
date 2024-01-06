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
}
