using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    public WeaponsData data;
    public GameObject langeobject;
    public List<GameObject> lookEnemyList = new List<GameObject>();
    bool Attack = false;        //攻撃中か
    // Start is called before the first frame update
    void Start()
    {
        langeobject.transform.localScale = new Vector3(data.lange, data.lange, data.lange);
    }

    // Update is called once per frame
    void Update()
    {
        if (Attack == false&&lookEnemyList.Count!=0)
        {
            InvokeRepeating("BulletPop", 0.1f, data.attackinterval);
            Attack = true;
        }
        if(Attack == true && lookEnemyList.Count == 0)
        {
            CancelInvoke("BulletPop");
            Attack = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            lookEnemyList.Add(other.gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            lookEnemyList.Remove(other.gameObject);
        }
    }
    private void BulletPop()
    {
        if (lookEnemyList.Count != 0)
        {
            GameObject memo = Instantiate(data.bullet, this.transform.position, Quaternion.identity);
            Bullet bu = memo.GetComponent<Bullet>();
            bu.bulletType = data.bulletType;    //弾種割り当て
            bu.bulletSpead = data.bulletSpead;  //弾速割り当て
            bu.LockEnemy = lookEnemyList[0];    //攻撃対象割り当て
            bu.strength = data.strength;        //攻撃力割り当て
        }
    }
}