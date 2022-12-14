using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoringSystem : MonoBehaviour
{
    public static ScoringSystem instance;

    public Text scoreText;
    //public Text highscoreText;
    public static int myScore = 0;
    [SerializeField] GameObject scoreAnimPrefab;
    //public static int highscore = 0;

    private void Awake()
    {
        instance = this;
    }

    public void Start()
    {
        //highscore = PlayerPrefs.GetInt("highscore", 0);
        scoreText.text = " Score : " + myScore.ToString();
        //highscoreText.text = "Highscore : " + highscore.ToString();
    }

    public void AddPoint()
    {
        myScore += 10;
        scoreText.text = "Score : " + myScore.ToString();
        showScoreAnim("+10");
        //if (highscore < score)
        //    PlayerPrefs.SetInt("highscore", score);
    }
    public void showScoreAnim(string text){
        if(scoreAnimPrefab)
        {
            GameObject prefab = Instantiate(scoreAnimPrefab, transform.position, Quaternion.identity);
            prefab.GetComponentInChildren<TMP_Text>().text = text;
        }
    }
}