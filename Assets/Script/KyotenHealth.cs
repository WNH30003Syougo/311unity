using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KyotenHealth : MonoBehaviour
{
    public int maxHP = 100;
    private int currentHP;

    void Start()
    {
        currentHP = maxHP;
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        Debug.Log("拠点がダメージを受けました 残りHP: " + currentHP);

        if (currentHP <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("拠点が破壊されました");
        // ゲームオーバー処理など
        gameObject.SetActive(false);
    }
}
