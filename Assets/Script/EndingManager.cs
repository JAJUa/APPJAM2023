using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingManager : MonoBehaviour
{
    public GameObject HappyEnd;
    public GameObject BadEnd;
    public bool isDebug;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F3))
        {
            HappyEnd.SetActive(true);
            BadEnd.SetActive(false);
        }else if(Input.GetKeyDown(KeyCode.F4))
        {
            BadEnd.SetActive(true);
            HappyEnd.SetActive(false);
        }
    }

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
