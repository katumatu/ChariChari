using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerMove : MonoBehaviour
{

    public float floatSpeed = 1.0f; // 浮遊の速さ
    public float floatHeight = 1.0f; // 浮遊の高さ
    private Vector3 startPos; // 初期位置
    private bool isGrounded;
    float newY = 0;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position; // 初期位置を保存
    }

    // Update is called once per frame
    void Update()
    {
        //タイマーの位置が-15よりも左に移動していた場合、
        if(transform.position.x < -15.0f)
        {
            //タイマーを破棄する
            Destroy(gameObject);
        }

        if(isGrounded == false)
        {
            // 上下にふわふわ浮かせる
            newY = startPos.y + Mathf.Sin(Time.time * floatSpeed) * floatHeight;

            // Y軸方向のみを変更するため、第一引数には Vector3.up を指定します。
            Vector3 newPosition = new Vector3(transform.position.x - 0.05f, newY, transform.position.z);
            transform.Translate(newPosition - transform.position, Space.World);
        }
    }

    void OnTriggerStay2D(Collider2D coll)
    {
        if(coll.gameObject.name == "ground(Clone)")
        {
            isGrounded = true;
            transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
            startPos = transform.position; // 初期位置を保存
            //Debug.Log("CoinsMove");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        isGrounded = false;
        //Debug.Log("トラ瞬間移動");
    }
}
