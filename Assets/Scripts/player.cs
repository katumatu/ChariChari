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

        //弾の位置が5よりも上に移動していた場合、
        if (transform.position.y < -6.0f)
        {
            SceneManager.LoadScene("Result", LoadSceneMode.Single);
        }

        if (transform.position.x < -10.0f)
        {
            SceneManager.LoadScene("Result", LoadSceneMode.Single);
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
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
        
        //isGrounded = true;
        //AJ = 0;
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
            //Debug.Log("空ジャンしたよ");
        }
    }
}
