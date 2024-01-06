using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryManager : MonoBehaviour
{
    [Header("컴포넌트 참조")]
    [SerializeField] private Button button;
    [SerializeField] private Image image1;
    [SerializeField] private Image image2;
    [SerializeField] private Text text1;
    [SerializeField] private Text text2;
    [SerializeField] private Image backGround;
    private FadeInOut image1Fade;
    private FadeInOut image2Fade;
    private FadeInOut text1Fade;
    private FadeInOut text2Fade;

    [SerializeField] private Sprite backGroundSprite;
    [SerializeField] private float fadingTime;

    // Start is called before the first frame update
    protected virtual void Start()
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

    }

    protected void SetButtonAction(Action action)
    {
        button.onClick.RemoveAllListeners();
        if (action != null)
        {
            button.onClick.AddListener(new(() =>
            {
                button.onClick.RemoveAllListeners();
                action?.Invoke();
            }));
        }
    }

    bool imageCounter;
    protected void ShowImage(Sprite sprite, Action callBack = null)
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

    bool textCounter;
    protected void ShowText(string text, Action callBack)
    {
        if (textCounter)
        {
            text2Fade.FadeOut(fadingTime);
            text1Fade.FadeIn(fadingTime, callBack);
            text1.text = text;
        }
        else
        {
            text1Fade.FadeOut(fadingTime);
            text2Fade.FadeIn(fadingTime, callBack);
            text2.text = text;
        }
    }
}
