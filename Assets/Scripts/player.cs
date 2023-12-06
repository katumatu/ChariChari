using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float jumpForce = 10f; // ジャンプ力
    private Rigidbody2D rb2d;
    private bool isGrounded;

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
    }

    // Update is called once per frame
    void Update()
    {
        // 画面がタッチされたかどうかの判定
        if (Input.GetMouseButton(0))
        {
            Jump();
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        //弾を破棄する
        //Destroy(gameObject);
        // ジャンプ中にも接地している場合、ジャンプを許可する
        if (rb2d.velocity.y < 0.01f && isGrounded)
        {
            isGrounded = true;
        }
        
        isGrounded = true;
    }

    void Jump()
    {
        // 地面に接触している場合にのみジャンプを許可
        if (isGrounded == true)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
            isGrounded = false; // ジャンプ中は地面にいない状態にする
        }

        if (isGrounded == false)
        {
            //Debug.LogError("地面についてないよ");
        }
    }
}
