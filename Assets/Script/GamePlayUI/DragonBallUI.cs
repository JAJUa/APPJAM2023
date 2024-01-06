using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragonBallUI : MonoBehaviour
{
    [SerializeField] Text text;

    private void Awake()
    {
        text = GetComponent<Text>();

        GameManager.Instance.OnChangedDragonBallCount += (_) =>
        {
            RefreshUI(GameManager.Instance.DragonBallCount);
        };
    }

    private void RefreshUI(int dragonBallCount)
    {
        text.text = dragonBallCount.ToString();
    }
}
