using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragonBallUI : MonoBehaviour
{
    [SerializeField] Text dragonBallCountText;
    [SerializeField] Text dragonBallShardCountText;

    private void Update()
    {
        dragonBallCountText.text = GameManager.Instance.DragonBallCount.ToString();
        dragonBallShardCountText.text = GameManager.Instance.DragonBallShardCount.ToString();
    }
}
