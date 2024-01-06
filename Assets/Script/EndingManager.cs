using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingManager : StoryManager
{
    [Header("¿£µù ¼³Á¤")]
    [SerializeField] private float scriptDelay;
    [SerializeField] private Sprite sprite1;
    [TextArea][SerializeField] private string script1;
    [TextArea][SerializeField] private string script2;
    [SerializeField] private Sprite sprite2;
    [TextArea][SerializeField] private string script3;
    [TextArea][SerializeField] private string script4;
    [SerializeField] private Sprite sprite3;
    [TextArea][SerializeField] private string script5;
    [TextArea][SerializeField] private string script6;
    [SerializeField] private Sprite sprite4;
    [TextArea][SerializeField] private string script7;
    [TextArea][SerializeField] private string script8;
    [TextArea][SerializeField] private string script9;
    [SerializeField] private FadeInOut screenFade;
    [SerializeField] private float endingFadeTime;

    protected override void Start()
    {
        base.Start();

        //Á¤½Å³ª°¥°Í°°¿¨¿¨¿¡¤Ä¤·¿¨¤·
        ShowImage(sprite1, null);
        ShowText(script1, () =>
        Delay(scriptDelay, () =>
        ShowText(script2, () =>
        Delay(scriptDelay, () =>
        {
            ShowImage(sprite2, null);
            ShowText(script3, () =>
            Delay(scriptDelay, () =>
            ShowText(script4, () =>
            Delay(scriptDelay, () =>
            {
                ShowImage(sprite3);
                ShowText(script5, () =>
                Delay(scriptDelay, () =>
                ShowText(script6, () =>
                Delay(scriptDelay, () =>
                {
                    ShowImage(sprite4);
                    ShowText(script7, () =>
                    Delay(scriptDelay, () =>
                    ShowText(script8, () =>
                    Delay(scriptDelay, () =>
                    ShowText(script9, () =>
                    Delay(scriptDelay, () =>
                    {
                        SetButtonAction(null);
                        screenFade.FadeIn(endingFadeTime, GoToTitle);
                    }))))));
                }))));
            }))));
        }))));

    }

    private void Delay(float delay, Action action)
    {
        StartCoroutine(Routine());
        IEnumerator Routine()
        {
            yield return new WaitForSeconds(delay);
            action?.Invoke();
        }
    }

    private void GoToTitle()
    {
        SceneManager.LoadScene("Title");
    }
}
