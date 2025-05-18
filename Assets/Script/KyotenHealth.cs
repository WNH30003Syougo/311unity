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
        Debug.Log("���_���_���[�W���󂯂܂��� �c��HP: " + currentHP);

        if (currentHP <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("���_���j�󂳂�܂���");
        // �Q�[���I�[�o�[�����Ȃ�
        gameObject.SetActive(false);
    }
}
