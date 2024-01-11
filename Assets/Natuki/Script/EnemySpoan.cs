using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpoan : MonoBehaviour
{
    [SerializeField] GameObject BaseEnemy;
    [SerializeField] Transform FarstPos;

    float timer = 0;
    float justTime = 5f;

    float coolTime;
    bool flag = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void EnemySpoans()
    {
        timer += Time.deltaTime;

        //5秒経過後に生成
        if (timer >= justTime && flag)
        {
            //Debug.Log("生成開始");
            Instantiate(BaseEnemy, FarstPos.position , FarstPos.rotation);
            flag = false;
        }
        else if(timer >= 6f)
        {
            //Debug.Log($"クールダウン中");
            coolTime += Time.deltaTime;

            if (coolTime >= 5f)
            {
                timer = 0;
                coolTime = 0;
                flag = true;
                //Debug.Log("生成再開");

            }

        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        EnemySpoans();
    }
}
