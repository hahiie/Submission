using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject LockEnemy;
    public float bulletSpead;
    public int bulletType;      //1ならミサイル,2なら弾丸
    Rigidbody2D rb;
    Vector3 Target;
    public float strength;  //攻撃力
    // Start is called before the first frame update
    void Start()
    {
        //this.gameObject.transform.LookAt(LockEnemy.transform);                   //敵を正面に
        Target = LockEnemy.transform.position - this.transform.position;
        rb = this.GetComponent<Rigidbody2D>();
        if (bulletType == 2)
        {
            rb.AddForce(Target.normalized * bulletSpead, ForceMode2D.Impulse);  //速度を与える
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (bulletType == 1 && LockEnemy != null)
        {
            Target = LockEnemy.transform.position - this.transform.position;
            rb.AddForce(Target.normalized * bulletSpead);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Enemy enemy = other.gameObject.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.HPDown(strength);
                Destroy(this.gameObject);
            }
        }
    }
}
