using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "ScriptableObject/WeaponsData")]
public class WeaponsData : ScriptableObject   //ScriptableObjectを継承する
{
    public string id;          //登録ID

    public string charName;    //キャラクターの名前

    public float hp;           //体力
    public float strength;     //攻撃力
    public float attackinterval;    //攻撃間隔
    public float lange;         //射程
    public GameObject bullet;   //弾丸
    public int bulletType;      //弾種
    public float bulletSpead;   //弾速
}
