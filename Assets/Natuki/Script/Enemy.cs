using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct EnemyDataSet
{
    public Vector3 moveVec;
    public float x, y, z;
    public float speed;
}

public class Enemy : MonoBehaviour
{
    EnemyDataSet data = new EnemyDataSet();

    [SerializeField] Transform tarGetObj;
    Vector3 direction;

    string tarGetName = "tyari";

    // Start is called before the first frame update
    void Start()
    {
        data.speed = 2f;
    }

    void Move()
    {
        direction = (tarGetObj.position - this.transform.position).normalized;
        transform.Translate(direction * data.speed * Time.deltaTime);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (tarGetObj != null)
        {
            Move();
        }
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == tarGetName)
        {
            Destroy(collision.gameObject);
        }

    }
}
