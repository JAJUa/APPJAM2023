using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragonBallUI : MonoBehaviour
{
    [SerializeField] Text dragonBallCountText;
    [SerializeField] Text dragonBallShardCountText;

    private void Awake()
    {
        GameManager.Instance.OnChangedDragonBallCount += (_) =>
        {
            dragonBallCountText.text = GameManager.Instance.DragonBallCount.ToString();
        };

        GameManager.Instance.OnChangedDragonBallShardCount += (_) =>
        {
            dragonBallShardCountText.text = GameManager.Instance.DragonBallShardCount.ToString();
        };
    }
}
