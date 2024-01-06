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
        Debug.Log("�� �̵�");
        //SceneManager.LoadScene("");
    }

    void Option_B()
    {
        Debug.Log("�ɼ�â Ȱ��ȭ");
        Option.SetActive(true);
    }

    void OptionBack_B()
    {
        Debug.Log("�ɼ�â ��Ȱ��ȭ");
        Option.SetActive(false);
    }

}
