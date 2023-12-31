using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //UI関係の為のライブラリ
using UnityEngine.SceneManagement; //ロード関係上必要なライブラリ

/// <summary>
/// system構造体変数ひとまとめしました。
/// </summary>
[System.Serializable]
public struct SystemDataSet
{
    public GameObject startButton; //開始ボタン
    public GameObject exitButton; //終了ボタン
    public Text startText; //開始ボタン内にあるテキスト
    public string LodedName;

}

public class TitleManager : MonoBehaviour
{
    //点滅処理処理関連変数
    float time;
    float speed = 0.3f;

    public SystemDataSet system; //実体宣言

    //ゲームのイメージプレイヤーの作成
    [SerializeField] Transform player;
    Vector3 startPos;
    Vector3 moveVec;

    // Start is called before the first frame update
    void Start()
    {
        startPos = player.position; //最初の位置保存
        Debug.Log($"startPos = {startPos}");
    }

    public void StartBUtton()
    {
        SceneManager.LoadScene(system.LodedName);
    }

    /// <summary>
    /// 点滅処理関数
    /// </summary>
    /// <param name="color"></param>
    /// <returns></returns>
    Color Text_Invicivil(Color color)
    {
        time += Time.deltaTime * 4.0f * speed; //点滅する速度設定
        color.a = Mathf.Sin(time); //α値を変更して点滅処理を促す


        return color; //こちらに返す
    }


    void ImageMove()
    {

        player.Translate(0.05f ,0,0);

        if (player.position.x >= 8.10f)
        {
            player.position = startPos;
        }
    }

    // Update is called once per frame
    void Update()
    {
        system.startText.color = Text_Invicivil(system.startText.color); //返した値に代入し関数に渡す
        
    }

    private void FixedUpdate()
    {
        ImageMove();
    }
}
