using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleManager : MonoBehaviour
{
    [SerializeField] private FadeInOut screenFade;
    [SerializeField] private Button button;

    void Start()
    {
        screenFade.FadeOut(1);
        button.onClick.AddListener(new(LoadScene));
    }

    void LoadScene()
    {
        GameManager.Instance.gameState = GameState.StartGame;
        GameManager.Instance.makedFood = new Foods[0];
        GameManager.Instance.DragonBallCount = 0;
        GameManager.Instance.DragonBallShardCount = 0;
        GameManager.Instance.CurrentGuestData = null;
        GameManager.Instance.CurruntDaysGuestPool = null;

        screenFade.FadeIn(1, () => SceneManager.LoadScene("IntroScene"));
    }
}
