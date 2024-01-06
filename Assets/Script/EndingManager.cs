using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingManager : StoryManager
{
    [Header("엔딩 설정")]
    [SerializeField] private Sprite sprite1;
    [SerializeField] private Sprite sprite2;
    [SerializeField] private Sprite sprite3;
    [TextArea][SerializeField] private string script1;
    [SerializeField] private Sprite sprite4;
    [TextArea][SerializeField] private string script2;
    [SerializeField] private FadeInOut screenFade;
    [SerializeField] private float endingFadeTime;

    protected override void Start()
    {
        base.Start();
        ShowImage(sprite1,
            () => ShowImage(sprite2,
            () =>
            {
                SetButtonAction(() =>
                {
                    ShowImage(sprite3);
                    ShowText(script1, () =>
                        {
                            SetButtonAction(() =>
                                {
                                    ShowImage(sprite4);
                                    ShowText(script2, () =>
                                    {
                                        SetButtonAction(() =>
                                        {
                                            screenFade.FadeIn(endingFadeTime, GoToTitle);
                                        });
                                    });
                                });
                        });
                });
            }));

    }

    private void GoToTitle()
    {
        SceneManager.LoadScene("Title");
    }
}
