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

    [SerializeField]
    GameObject TabletTouch;

    private bool isExplan = false;

    //Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Explan")
        {
            TabletTouch.SetActive(false);
        }
        
        isExplan = false;
        //ポインターデータの初期化
        pointer = new PointerEventData(EventSystem.current);

        // 一秒後に操作を受け付けるためにInvokeを使用
        Invoke("EnableInput", 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        //マウスクリックされた時、
        if(Input.GetMouseButtonDown(0))
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
                if(target.gameObject.name == "Button")
                {
                    if (SceneManager.GetActiveScene().name == "Result")
                    {
                        AudioSource.PlayClipAtPoint(click, new Vector3(0, 0, -7)); //効果音再生しつつ
                        StartCoroutine(Resultbatton()); //シーン切り替えに関するコルーチン
                    }
                }
            }

            if (SceneManager.GetActiveScene().name == "Explan")
            {
                if (isExplan == true)
                {
                    // シーンの切り替え
                    SceneManager.LoadScene("Game", LoadSceneMode.Single);
                }
            }
        }
    }

    //効果音がなってタイトルシーンに移行する
    IEnumerator Resultbatton()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            //ResultSceneからTitleSceneへシーンを切り替える
            SceneManager.LoadScene("titleScene", LoadSceneMode.Single); 
        }
    }

    void EnableInput()
    {
        if (SceneManager.GetActiveScene().name == "Explan")
        {
            TabletTouch.SetActive(true);
            isExplan = true;
            Debug.Log("Explanだよ");
        } 
    }
}
