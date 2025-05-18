using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public int damage = 10;
    public float speed = 5f;

    void Update()
    {
        var v = Vector3.right; // 右方向に進む（必要に応じて変更）
        transform.position += v * speed * Time.deltaTime;
    }

    void OnTriggerEnter(Collider collision)
    {
        Debug.Log("衝突されたオブジェクト：" + collision.gameObject.name);

        // Enemyに当たったときだけ処理
        if (collision.CompareTag("Enemy"))
        {
            Enemy enemy = collision.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage); // ダメージを与える
            }

            Destroy(gameObject); // 攻撃オブジェクトを削除（弾）
        }
        else if (!collision.CompareTag("Attack")) // ほかの攻撃と衝突した場合は無視
        {
            Destroy(gameObject); // 敵以外に当たったら消す
        }
    }
}
