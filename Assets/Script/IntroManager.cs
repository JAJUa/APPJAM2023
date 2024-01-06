using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroManager : StoryManager
{
    [SerializeField] private FadeInOut flashFade;
    [SerializeField] private FadeInOut screenFade;

    [Header("인트로 설정")]
    [SerializeField] private AudioClip bgmClip;
    [SerializeField] private CutSceneData[] introCutScenes;
    [SerializeField] private float endFadingTime;

    protected override void Start()
    {
        base.Start();

        SoundManager.Instance.SetBgm(bgmClip);

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
            SetButtonAction(null);
            screenFade.FadeIn(endFadingTime, Gamestart);
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