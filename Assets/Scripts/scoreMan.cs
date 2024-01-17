using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class ScoreMan : MonoBehaviour
{
    //スクリプトに格納するもの、変数
    int BaceScore = 0;
    public static int score = 0; //グローバルなスコア変数
    GameObject scoreText; //スコアテキストのゲームオブジェクト
    private int framesPassed = 0;
    private int framesPerIncrement = 10;
    //public Transform targetPlayer;  // プレイヤーのTransformを格納する変数

    // Start is called before the first frame update
    void Start()
    {
        switch (SceneManager.GetActiveScene().name)
                {
                    case "Title":
                        BaceScore = 0;
                        break;
                    case "Explan":
                        BaceScore = 0;
                        break;
                    case "Game":
                        BaceScore = 0;
                        break;
                    case "Result":
                        break;
                    default:
                        break;
                }
        //スコアテキストのゲームオブジェクトを検索して取得する
        scoreText = GameObject.Find("Score");
    }

    // Update is called once per frame
    void Update()
    {

        switch (SceneManager.GetActiveScene().name)
                {
                    case "Title":
                        break;
                    case "Explan":
                        break;
                    case "Game":
                        // フレーム数をカウント
                        framesPassed++;
                        if(Player.quickflg == true)
                        {
                            framesPerIncrement = 5;
                        }

                        if(Player.quickflg == false)
                        {
                            framesPerIncrement = 10;
                        }
                        // 10フレームごとにスコアを増やす
                        if(framesPassed >= framesPerIncrement)
                        {
                            BaceScore++;
                            framesPassed = 0; // フレーム数をリセット
                        }
                        
                        break;
                    case "Result":
                        break;
                    default:
                        break;
                }
        //スコアテキストの表示を更新する
        scoreText.GetComponent<Text>().text = "Score: " + Mathf.Clamp(score, 0, 99999).ToString("D5");
    }

    public void AddScore()
    {
        score = BaceScore + (Player.playerX);
    }

    public void CoinScore()
    {
        //スコアを10加算する
        BaceScore += 10;
    }
}
