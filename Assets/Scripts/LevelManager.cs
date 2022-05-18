using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] float sceneDelayAmount;

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }


    public void LoadGame()
    {
        SceneManager.LoadScene(1);
    }


    public void LoadGameOver()
    {
        //SceneManager.LoadScene(2);
        StartCoroutine(DelayScreenLoad(2, sceneDelayAmount));
    }


    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }

    IEnumerator DelayScreenLoad(int sceneIndex, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneIndex);
    }
}
