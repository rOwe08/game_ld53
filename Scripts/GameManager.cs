using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public DialogController DialogController;
    void Start()
    {
    }

    public void LoadSceneByIndex(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
        if(sceneIndex == 1 )
        {
            DialogController.ShowDialog("Hello!");
        }
    }
}
