using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BadEndingManager : MonoBehaviour
{
    [SerializeField] private FadeInOut screenFade;

    void Start()
    {
        SoundManager.Instance.StopBgm();

        screenFade.FadeOut(3, () =>
        Delay(() =>
        screenFade.FadeIn(3, () =>
        SceneManager.LoadScene("Title"))));
    }

    void Delay(Action action)
    {
        StartCoroutine(Routine());
        IEnumerator Routine()
        {
            yield return new WaitForSeconds(2);
            action?.Invoke();
        }
    }
}
