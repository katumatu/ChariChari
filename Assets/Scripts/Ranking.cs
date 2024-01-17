using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Ranking : MonoBehaviour
{

    public static int score01 = 0; //グローバルなスコア変数
    public static int score02 = 0; //グローバルなスコア変数
    public static int score03 = 0; //グローバルなスコア変数
    public static int score04 = 0; //グローバルなスコア変数
    public static int score05 = 0; //グローバルなスコア変数
    GameObject scoreText01; //スコアテキストのゲームオブジェクト
    GameObject scoreText02; //スコアテキストのゲームオブジェクト
    GameObject scoreText03; //スコアテキストのゲームオブジェクト
    GameObject scoreText04; //スコアテキストのゲームオブジェクト
    GameObject scoreText05; //スコアテキストのゲームオブジェクト

    // Start is called before the first frame update
    void Start()
    {
        if(score01 >= ScoreMan.score)
        {
            if(score02 >= ScoreMan.score)
            {
                if(score03 >= ScoreMan.score)
                {
                    if(score04 >= ScoreMan.score && score05 < ScoreMan.score)
                    {
                        score05 = ScoreMan.score;
                    }

                    if(score04 < ScoreMan.score)
                    {
                        score05 = score04;
                        score04 = ScoreMan.score;
                    }
                }

                if(score03 < ScoreMan.score)
                {
                    score05 = score04;
                    score04 = score03;
                    score03 = ScoreMan.score;
                }
            }

            if(score02 < ScoreMan.score)
            {
                score05 = score04;
                score04 = score03;
                score03 = score02;
                score02 = ScoreMan.score;
            }
        }
        
        if(score01 < ScoreMan.score)
        {
            score05 = score04;
            score04 = score03;
            score03 = score02;
            score02 = score01;
            score01 = ScoreMan.score;
        }

        //スコアテキストのゲームオブジェクトを検索して取得する
        scoreText01 = GameObject.Find("score01");
        scoreText02 = GameObject.Find("score02");
        scoreText03 = GameObject.Find("score03");
        scoreText04 = GameObject.Find("score04");
        scoreText05 = GameObject.Find("score05");
    }

    // Update is called once per frame
    void Update()
    {
        //スコアテキストの表示を更新する
        scoreText01.GetComponent<Text>().text = "1st: " + score01.ToString("D5");
        scoreText02.GetComponent<Text>().text = "2nd: " + score02.ToString("D5");
        scoreText03.GetComponent<Text>().text = "3rd: " + score03.ToString("D5");
        scoreText04.GetComponent<Text>().text = "4th: " + score04.ToString("D5");
        scoreText05.GetComponent<Text>().text = "5th: " + score05.ToString("D5");
        //scoreText.GetComponent<Text>().text = "Score: " + Mathf.Clamp(score, 0, 99999).ToString("D5");
    }
}
