using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinMove : MonoBehaviour
{

    public float floatSpeed = 2.0f; // 浮遊の速さ
    public float floatHeight = 0.5f; // 浮遊の高さ
    private Vector3 startPos; // 初期位置
    public GameObject coin; //生成するcoinのプレハブ
    int increase = 0;
    private bool isGrounded;
    float newY = 0;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position; // 初期位置を保存
        increase = Random.Range(1, 7);
        if (increase >= 5)
        {
            //画面の上部端より少し上から、画面の左端から右端の間でランダムな位置に敵を生成する
            Instantiate(coin, new Vector3(startPos.x + 1.5f, startPos.y, startPos.z), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //コインの位置が-15よりも左に移動していた場合、
        if (transform.position.x < -15.0f)
        {
            //弾を破棄する
            Destroy(gameObject);
        }

        if (isGrounded == false)
        {
        // 上下にふわふわ浮かせる
        newY = startPos.y + Mathf.Sin(Time.time * floatSpeed) * floatHeight;

        // Y軸方向のみを変更するため、第一引数には Vector3.up を指定します。
        Vector3 newPosition = new Vector3(transform.position.x - 0.1f, newY, transform.position.z);
        transform.Translate(newPosition - transform.position, Space.World);
        }
    }

    void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.name == "Ground(Clone)")
        {
            isGrounded = true;
            transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
            startPos = transform.position; // 初期位置を保存
            Debug.Log("CoinsMove");
        }

        //他のコインと重なって生成されるのを防ぐ
        if (coll.gameObject.name.Contains("Coin"))
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        isGrounded = false;
        Debug.Log("トラ瞬間移動");
    }
}
