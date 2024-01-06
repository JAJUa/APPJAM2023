using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayManager : MonoBehaviour
{
    public int curruntDay { get; private set; } = 1;

    public event Action OnFinishedDay;
    public void FinishDay()
    {
        OnFinishedDay?.Invoke();
    }

    public event Action OnStartedDay;
    public void StartDay()
    {
        curruntDay++;
        OnStartedDay?.Invoke();
    }
}
