using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class SceneMan : MonoBehaviour
{
    //マウスイベントの情報を格納するための変数
    PointerEventData pointer;

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
                            //ResultSceneからTitleSceneへシーンを切り替える
                            SceneManager.LoadScene("titleScene", LoadSceneMode.Single);
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }
}
