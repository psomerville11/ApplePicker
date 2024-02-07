using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartScreen : MonoBehaviour
{
    public Button button;
    void Start()
    {
        button.onClick.AddListener(OnClick);
    }
    public void OnClick()
    {
        SceneManager.LoadScene("_Scene_0");
    }
}
