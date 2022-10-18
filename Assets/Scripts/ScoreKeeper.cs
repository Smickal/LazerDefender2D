using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    float currentScore = 0;

    static ScoreKeeper instace;
    
    private void Awake()
    {
        ManageSingleton();
    }

    void ManageSingleton()
    {
        if(instace != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instace = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    public float GetCurrentScore()
    {
        return currentScore;
    }

    public void AddToCurrentScore(float score)
    {
        currentScore += score;
        Mathf.Clamp(currentScore, 0, float.MaxValue);
    }

    public void ResetCurrentScore()
    {
        currentScore = 0;
    }


}
