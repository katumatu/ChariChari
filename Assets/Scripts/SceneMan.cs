using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class SceneMan : MonoBehaviour
{
    //マウスイベントの情報を格納するための変数
    PointerEventData pointer;
    public AudioClip click; //効果音クリップ
    private float delayTimer; // ディレイの経過時間

    //Start is called before the first frame update
    void Start()
    {
        //ポインターデータの初期化
        pointer = new PointerEventData(EventSystem.current);
    }

    // Update is called once per frame
    void Update()
    {
        //マウスの左クリックが押された時、
        if (Input.GetMouseButtonDown(0))
        {
            List<RaycastResult> results = new List<RaycastResult>();
            //ポインターデータにマウス座標を設定
            pointer.position = Input.mousePosition;
            //イベントシステムを使用してUI上のオブジェクトをレイキャスト
            EventSystem.current.RaycastAll(pointer, results);
            //レイキャストの結果を処理
            foreach (RaycastResult target in results)
            {
                Debug.Log(target.gameObject.name);
                //StartButtonという名前のオブジェクトがクリックされた場合の処理
                if (target.gameObject.name == "Button")
                {
                    switch (SceneManager.GetActiveScene().name)
                    {
                        /*case "TitleScene":
                            //TitleSceneからGameSceneへシーンを切り替える
                            SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
                            break;*/
                        case "Result":
                            AudioSource.PlayClipAtPoint(click, new Vector3(0, 0, -5)); //効果音再生しつつ
                            StartCoroutine(Resultbatton()); //シーン切り替えに関するコルーチン
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }

    //効果音がなってタイトルシーンに移行する
    IEnumerator Resultbatton()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.0f); //0.25秒のディレイ。次の弾が生成されるまでの間隔をコントロールしてる
            //ResultSceneからTitleSceneへシーンを切り替える
            SceneManager.LoadScene("titleScene", LoadSceneMode.Single); 
            }
    }
}
