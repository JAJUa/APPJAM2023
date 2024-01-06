using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CookCycle : MonoBehaviour
{
    private void Update()
    {
        if (GameManager.Instance.makedFood != null)
        {
            Debug.Log(GameManager.Instance.makedFood.Length);
            if (GameManager.Instance.makedFood.Length >= 2)
            {
                SceneManager.LoadScene("GamePlayScene");
            }
        }
    }
}
