using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Score : MonoBehaviour
{   
    public Text CurrentScore;
    public float score = 0;
    public float pointIncreasedPerSecond;
    
    void Start() {
        score = 0f;
        pointIncreasedPerSecond = 1f;
    }

    void Update() {
        CurrentScore.text = "Score: " + (int)score;
        score += pointIncreasedPerSecond * Time.deltaTime;
    }
}
