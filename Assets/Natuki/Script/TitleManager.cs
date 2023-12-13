using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// system構造体変数ひとまとめしました。
/// </summary>
[System.Serializable]
public struct SystemDataSet
{
    public GameObject startButton; //開始ボタン
    public GameObject exitButton; //終了ボタン
    public Text startText; //開始ボタン内にあるテキスト

}

public class TitleManager : MonoBehaviour
{
    //点滅処理処理関連変数
    float time;
    float speed = 0.5f;

    public SystemDataSet system; //実体宣言

    // Start is called before the first frame update
    void Start()
    {

    }

    public void StartBUtton()
    {
        system.startButton.SetActive(false);
        system.exitButton.SetActive(false);
    }

    /// <summary>
    /// 点滅処理関数
    /// </summary>
    /// <param name="color"></param>
    /// <returns></returns>
    Color Text_Invicivil(Color color)
    {
        time += Time.deltaTime * 5.0f * speed; //点滅する速度設定
        color.a = Mathf.Sin(time); //α値を変更して点滅処理を促す


        return color; //こちらに返す
    }

    // Update is called once per frame
    void Update()
    {
        system.startText.color = Text_Invicivil(system.startText.color); //返した値に代入し関数に渡す

    }
}
