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

    [SerializeField]
    GameObject Loading;

    public float rotationSpeed = 40.0f; // 回転速度 (度/秒)

    [SerializeField]
    GameObject asoA;

    [SerializeField]
    GameObject asoB;
    int ASO = 0;
    private AudioSource audioSource;

    //Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Explan")
        {
            TabletTouch.SetActive(false);
            Loading.SetActive(false);
            asoA.SetActive(true);
            asoB.SetActive(false);

            isExplan = false;
            // 一秒後に操作を受け付けるためにInvokeを使用
            Invoke("EnableInput", 1.0f);
            ASO = 0;
        }
        //ポインターデータの初期化
        pointer = new PointerEventData(EventSystem.current);

        // コルーチンを開始
        StartCoroutine(RotateLoading());

        audioSource = GetComponent<AudioSource>();
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
                        audioSource.PlayOneShot(click, 1.0f);
                        //AudioSource.PlayClipAtPoint(click, new Vector3(0, 0, -7)); //効果音再生しつつ
                        StartCoroutine(Resultbatton()); //シーン切り替えに関するコルーチン
                    }
                }
            }

            if (SceneManager.GetActiveScene().name == "Explan")
            {
                if (isExplan == true)
                {
                    if (ASO == 1)
                    {
                        // シーンの切り替え
                        SceneManager.LoadScene("Game", LoadSceneMode.Single);
                        TabletTouch.SetActive(false);
                        Loading.SetActive(true);
                    }

                    if (ASO == 0)
                    {
                        TabletTouch.SetActive(false);
                        asoA.SetActive(false);
                        asoB.SetActive(true);
                        Invoke("EnableInput", 1.0f);
                        isExplan = false;
                        ASO = 1;
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
            Loading.SetActive(true);
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
            //Debug.Log("Explanだよ");
        }
    }

    private IEnumerator RotateLoading()
    {
        while (true)
        {
            // 現在の回転を取得し、40度回転させる
            Vector3 currentRotation = Loading.transform.rotation.eulerAngles;
            Loading.transform.rotation = Quaternion.Euler(new Vector3(currentRotation.x, currentRotation.y, currentRotation.z - 40f));

            // 0.5秒待つ
            yield return new WaitForSeconds(0.1f);
        }
    }
}
