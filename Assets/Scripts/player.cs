using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class player : MonoBehaviour
{
    public float jumpForce = 10f; // ジャンプ力
    private Rigidbody2D rb2d;
    private bool isGrounded;
    int AJ = 0;
    public static int playerX = 0;
    public AudioClip jumpSE; //効果音クリップ

    public Sprite[] images;
    public float switchInterval = 1.0f;  // 画像を切り替える間隔（秒）
    public Vector2 imageSize = new Vector2(1.0f, 1.0f);  // 画像のサイズ

    private SpriteRenderer spriteRenderer;
    private int currentImageIndex = 0;
    private float timer = 0f;
    public AudioClip CoinSE; //効果音クリップ

    // Start is called before the first frame update
    void Start()
    {
        // Rigidbody2Dコンポーネントを取得する
        rb2d = GetComponent<Rigidbody2D>();

        if (rb2d != null)
        {
            // 回転を制限する
            rb2d.freezeRotation = true;
        }

        isGrounded = true;
        AJ = 0;

        spriteRenderer = GetComponent<SpriteRenderer>();

        // 最初の画像を表示
        if (images.Length > 0)
        {
            spriteRenderer.sprite = images[currentImageIndex];
            // 画像のサイズを設定
            spriteRenderer.transform.localScale = new Vector3(imageSize.x, imageSize.y, 1.0f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        /*if (rb2d.velocity.y < 0.0f)
        {
            isGrounded = false;
        }*/
        
        // 画面がタッチされたかどうかの判定
        if (Input.GetMouseButtonDown(0))
        {
            if (isGrounded == false)
            {
                AirJump();
                //Debug.LogError("地面についてないよ");
            }

            else if (isGrounded == true)
            {
                Jump();
            }
        }

        if (transform.position.y < -6.0f)
        {
            SceneManager.LoadScene("Result", LoadSceneMode.Single);
        }

        if (transform.position.x < -10.0f)
        {
            SceneManager.LoadScene("Result", LoadSceneMode.Single);
        }
        
        playerX = Mathf.FloorToInt(transform.position.x) +3;
        GameObject.Find("Score").GetComponent<scoreMan>().AddScore();

        
        // タイマーを更新
        timer += Time.deltaTime;

        // 指定された間隔ごとに画像を切り替え
        if (timer >= switchInterval)
        {
            // 次の画像のインデックスを計算
            currentImageIndex = (currentImageIndex + 1) % images.Length;

            // 次の画像を表示
            spriteRenderer.sprite = images[currentImageIndex];
            // 画像のサイズを設定
            spriteRenderer.transform.localScale = new Vector3(imageSize.x, imageSize.y, 1.0f);

            // タイマーをリセット
            timer = 0f;
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.name == "Coin(Clone)")
        {
            //指定した位置でオーディオクリップを再生する。z座標の変更でボリュームを調節
            AudioSource.PlayClipAtPoint(CoinSE, new Vector3(0, 0, -8));
            //衝突した相手のゲームオブジェクトを破棄する
            Destroy(coll.gameObject);
            //CanvasオブジェクトのUIControllerコンポーネントを取得し、スコアを加算する
            GameObject.Find("Score").GetComponent<scoreMan>().CoinScore();

        }

        if (coll.gameObject.name == "Ground(Clone)")
        {
            if (rb2d.velocity.y > 0.0f && AJ >= 1)
            {
                isGrounded = false;
                AJ = 2;
            }

            // ジャンプ中にも接地している場合、ジャンプを許可する
            else if (rb2d.velocity.y <= 0.0f )
            {
                isGrounded = true;
                AJ = 0;
            }
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
        AJ = 1;
    }

    void Jump()
    {
        
        /*if (isGrounded == false)
        {
            if(AJ == 1)
            {
                Debug.LogError("地面についてないよ");
            }

            if(AJ == 0)
            {
                rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
                AJ = 1;
                Debug.Log("空ジャンしたよ");
            }
        }

        // 地面に接触している場合にのみジャンプを許可
        if (isGrounded == true)
        {*/
            if(AJ == 0)
            {
                rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
                isGrounded = false; // ジャンプ中は地面にいない状態にする
                AudioSource.PlayClipAtPoint(jumpSE, new Vector3(0, 0, -8)); //効果音再生しつつ
                //Debug.Log("通常ジャンプしたよ");
            }
        //}
    }

    void AirJump()
    {
        if(AJ == 2)
        {
            //Debug.LogError("地面についてないよ");
        }

        if(AJ == 1)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
            AJ = 2;
            AudioSource.PlayClipAtPoint(jumpSE, new Vector3(0, 0, -8)); //効果音再生しつつ
            //Debug.Log("空ジャンしたよ");
        }
    }
}
