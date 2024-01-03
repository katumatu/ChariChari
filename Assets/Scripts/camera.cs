using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class camera : MonoBehaviour
{
    // 目標のフレームレート
    public int targetFrameRate = 60;
    private float idleTime = 0f;  // アイドル時間のカウント
    private float idleThreshold = 15f;  // アイドルとみなす閾値（秒）
    private bool isTimerRunning = true;  // タイマーが動作中かどうか

    public Transform targetPlayer;  // プレイヤーのTransformを格納する変数
    public float yOffset = -10.0f;     // プレイヤーからのY軸のオフセット

    private void Awake()
    {
        // フレームレートを設定
        Application.targetFrameRate = targetFrameRate;
    } 

    /*public int targetWidth = 2160; // 目標の幅
    public int targetHeight = 1080; // 目標の高さ
    public bool fullscreen = true; // フルスクリーンモードを使用するかどうか*/

    void Start()
    {
        /*if (fullscreen)
        {
            Screen.SetResolution(targetWidth, targetHeight, true);
        }

        else
        {
            Screen.SetResolution(targetWidth, targetHeight, false);
        }*/

        Time.timeScale = 1;//読み込みの時間が正常値に戻り
        
        //Debug.Log("画面サイズを変更しました");
    }

    // Update is called once per frame
    void Update()
    {
        // 現在のフレームレートを取得してコンソールに表示
        /*float currentFrameRate = 1.0f / Time.deltaTime;
        Debug.Log("Current Frame Rate: " + currentFrameRate.ToString("F2"));*/

        //左CTRLキーが押されている時、
        if (Input.GetKey(KeyCode.LeftControl))
        {
            //Rキーも押された場合、
            if (Input.GetKeyDown(KeyCode.R))
            {
                //現在読み込まれているシーンを再度読み込む
                switch (SceneManager.GetActiveScene().name)
                {
                    case "titleScene":
                        SceneManager.LoadScene("titleScene", LoadSceneMode.Single);
                        break;
                    case "Game":
                        SceneManager.LoadScene("Game", LoadSceneMode.Single);
                        break;
                    case "Result":
                        SceneManager.LoadScene("Result", LoadSceneMode.Single);
                        break;
                    default:
                        break;
                }
            }
        }

        //左CTRLを押しているとき、
        if (Input.GetKey(KeyCode.LeftControl))
        {
            //Tキーも押すと、
            if (Input.GetKeyDown(KeyCode.T))
            {
                Time.timeScale = 1;//読み込みの時間が正常値に戻り
                SceneManager.LoadScene("titleScene", LoadSceneMode.Single);//タイトルシーン単体を読み込む
            }
        }

        //入力があった場合はタイマーをリセット
        if (Input.anyKey)
        {
            idleTime = 0f;
        }

        //タイマーが動作中であればアイドル時間をカウント
        if (isTimerRunning)
        {
            idleTime += Time.deltaTime;

            //アイドル時間が閾値を超えた場合、titleSceneSceneに戻る
            if (idleTime >= idleThreshold)
            {
                if(SceneManager.GetActiveScene().name != "titleScene"){
                    SceneManager.LoadScene("titleScene");
                }
            }
        }

        //ESCキーでゲームを終わる
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }

        switch (SceneManager.GetActiveScene().name)
        {
            case "Game":
                if (targetPlayer.position.y > 0)
                {
                    if(targetPlayer.position.y < 4)
                    // プレイヤーの位置にカメラを追従させる（Y軸のみ）
                    transform.position = new Vector3(transform.position.x, targetPlayer.position.y, transform.position.z);
                }
                break;
            default:
                break;
        }
    }
}