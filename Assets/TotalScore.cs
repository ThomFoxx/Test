using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotalScore : MonoBehaviour
{
    public int _score;
    public bool _finalScore;

    private void Awake()
    {
        StartCoroutine(ScoringTest());
        
    }

    IEnumerator ScoringTest()
    {
        
            while (_score < 10)
        {
            _score++;
            Debug.Log(_score);
        }
            if(_score == 10)
        {
            _score = 10;
            FinalScore();
            StopCoroutine(ScoringTest());
        }
        yield return new WaitForSeconds(1.0f);
    }

    public void FinalScore()
    {
        _finalScore = true;
    }
}
