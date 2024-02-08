using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Restart : MonoBehaviour
{

  void Start()
  {
    GetComponent<Button>().onClick.AddListener(RestartGame);
  }

  void RestartGame()
  {
    SceneManager.LoadScene("_Scene_0");

  }


}
