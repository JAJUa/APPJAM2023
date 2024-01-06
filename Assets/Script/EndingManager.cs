using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingManager : MonoBehaviour
{
    public GameObject HappyEnd;
    public GameObject BadEnd;
    public bool isDebug;

    void Awake()
    {
        if (!isDebug)
        {
            if (GameManager.Instance.DragonBallCount == 5)
            {
                HappyEnd.SetActive(true);
                BadEnd.SetActive(false);
            }
            else
            {
                BadEnd.SetActive(true);
                HappyEnd.SetActive(false);
            }
        }
    }
}
