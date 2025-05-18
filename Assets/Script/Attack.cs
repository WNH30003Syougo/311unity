using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public int damage = 10;
    public float speed = 5f;

    void Update()
    {
        var v = Vector3.right; // �E�����ɐi�ށi�K�v�ɉ����ĕύX�j
        transform.position += v * speed * Time.deltaTime;
    }

    void OnTriggerEnter(Collider collision)
    {
        Debug.Log("�Փ˂��ꂽ�I�u�W�F�N�g�F" + collision.gameObject.name);

        // Enemy�ɓ��������Ƃ���������
        if (collision.CompareTag("Enemy"))
        {
            Enemy enemy = collision.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage); // �_���[�W��^����
            }

            Destroy(gameObject); // �U���I�u�W�F�N�g���폜�i�e�j
        }
        else if (!collision.CompareTag("Attack")) // �ق��̍U���ƏՓ˂����ꍇ�͖���
        {
            Destroy(gameObject); // �G�ȊO�ɓ������������
        }
    }
}
