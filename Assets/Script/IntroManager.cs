using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroManager : MonoBehaviour
{
    [Header("컴포넌트 참조")]
    [SerializeField] private Button button;
    [SerializeField] private Image image1;
    [SerializeField] private Image image2;
    [SerializeField] private Image backGround;
    [SerializeField] private FadeInOut screenFade;
    private FadeInOut image1Fade;
    private FadeInOut image2Fade;

    [Header("인트로 설정")]
    [SerializeField] private Sprite backGroundSprite;
    [SerializeField] private Sprite[] introSprites;
    [SerializeField] private float fadingTime;
    [SerializeField] private float endFadingTime;

    private void Start()
    {
        image1Fade = image1.GetComponent<FadeInOut>();
        image2Fade = image2.GetComponent<FadeInOut>();

        image1.sprite = backGroundSprite;
        image2.sprite = backGroundSprite;
        backGround.sprite = backGroundSprite;


    }

    int spriteIndex;
    private void ShowLogic()
    {
        if(spriteIndex < introSprites.Length)
        {
            ShowImage(introSprites[spriteIndex++], () => SetButtonAction(ShowLogic));
        }
        else
        {
            screenFade.FadeIn(endFadingTime, Gamestart);
        }
    }

    private void SetButtonAction(Action action)
    {
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(new(action));
    }

    bool imageCounter;
    private void ShowImage(Sprite sprite, Action callBack)
    {
        if (imageCounter)
        {
            image1.sprite = sprite;
            image1Fade.FadeIn(fadingTime, callBack);
            image2Fade.FadeOut(fadingTime);
        }
        else
        {
            image2.sprite = sprite;
            image2Fade.FadeIn(fadingTime, callBack);
            image1Fade.FadeOut(fadingTime);
        }
        imageCounter = !imageCounter;
    }

    private void Gamestart()
    {
        SceneManager.LoadScene("GamePlayScene");
    }
}
