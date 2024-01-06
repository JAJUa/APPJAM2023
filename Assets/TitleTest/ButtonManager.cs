using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ButtonManager : MonoBehaviour
{
    [SerializeField] Button StartButton;
    [SerializeField] Button OptionButton;
    [SerializeField] Button OptionBackButton;

    [SerializeField] GameObject Option;

    private void Start()
    {
        StartButton.onClick.AddListener(Start_B);
        OptionButton.onClick.AddListener(Option_B);
        OptionBackButton.onClick.AddListener(OptionBack_B);
    }
    void Start_B()
    {
        Debug.Log("씬 이동");
        //SceneManager.LoadScene("");
    }

    void Option_B()
    {
        Debug.Log("옵션창 활성화");
        Option.SetActive(true);
    }

    void OptionBack_B()
    {
        Debug.Log("옵션창 비활성화");
        Option.SetActive(false);
    }

}
