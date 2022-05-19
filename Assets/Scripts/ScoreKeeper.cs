using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{

    static ScoreKeeper instance;


    void Awake()
    {
        ManageSingleton();
    }

    void ManageSingleton()
    {
        if (instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }


    int score = 0;

    public int GetScore()
    {
        return score;
    }

    public void UpdateScore(int value)
    {
        score += value;
        Mathf.Clamp(score, 0, int.MaxValue);
        //Debug.Log(score);
    }

    public void ResetScore()
    {
        score = 0;
    }
}
