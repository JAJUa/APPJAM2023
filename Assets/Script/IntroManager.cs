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
    [SerializeField] private Text text1;
    [SerializeField] private Text text2;
    [SerializeField] private Image backGround;
    [SerializeField] private FadeInOut flashFade;
    [SerializeField] private FadeInOut screenFade;
    private FadeInOut image1Fade;
    private FadeInOut image2Fade;
    private FadeInOut text1Fade;
    private FadeInOut text2Fade;

    [Header("인트로 설정")]
    [SerializeField] private Sprite backGroundSprite;
    [SerializeField] private CutSceneData[] introCutScenes;
    [SerializeField] private Sprite endingSprite;
    [SerializeField] private string endingText;
    [SerializeField] private float fadingTime;
    [SerializeField] private float flashFadingTime;
    [SerializeField] private float endFadingTime;

    private void Start()
    {
        image1Fade = image1.GetComponent<FadeInOut>();
        image2Fade = image2.GetComponent<FadeInOut>();
        text1Fade = text1.GetComponent<FadeInOut>();
        text2Fade = text2.GetComponent<FadeInOut>();

        image1.sprite = backGroundSprite;
        image2.sprite = backGroundSprite;
        text1.text = string.Empty;
        text2.text = string.Empty;
        backGround.sprite = backGroundSprite;

        ShowLogic();
    }

    int cutIndex;
    int scriptsIndex;
    private void ShowLogic()
    {
        if (cutIndex < introCutScenes.Length)
        {
            if (scriptsIndex == 0)
            {
                ShowImage(introCutScenes[cutIndex].sprite);
            }
            ShowText(introCutScenes[cutIndex].scripts[scriptsIndex], () => SetButtonAction(ShowLogic));

            scriptsIndex++;
            if (scriptsIndex >= introCutScenes[cutIndex].scripts.Length)
            {
                scriptsIndex = 0;
                cutIndex++;
            }
        }
        else
        {
            ShowImage(endingSprite);
            ShowText(endingText, () => flashFade.FadeIn(flashFadingTime, () => screenFade.FadeIn(endFadingTime, Gamestart)));
        }
    }

    private void SetButtonAction(Action action)
    {
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(new(action));
    }

    bool imageCounter;
    private void ShowImage(Sprite sprite)
    {
        if (imageCounter)
        {
            image1.sprite = sprite;
            image1Fade.FadeIn(fadingTime);
            image2Fade.FadeOut(fadingTime);
        }
        else
        {
            image2.sprite = sprite;
            image2Fade.FadeIn(fadingTime);
            image1Fade.FadeOut(fadingTime);
        }
        imageCounter = !imageCounter;
    }

    bool textCounter;
    private void ShowText(string text, Action callBack)
    {
        if (textCounter)
        {
            text1.text = text;
            text1Fade.FadeIn(fadingTime, callBack);
            text2Fade.FadeOut(fadingTime);
        }
        else
        {
            text2.text = text;
            text2Fade.FadeIn(fadingTime, callBack);
            text1Fade.FadeOut(fadingTime);
        }
    }

    private void Gamestart()
    {
        SceneManager.LoadScene("GamePlayScene");
    }
}

[Serializable]
public struct CutSceneData
{
    public Sprite sprite;
    [TextArea]
    public string[] scripts;
}