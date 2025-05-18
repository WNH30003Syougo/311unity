using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    void Start()
    {
        if (target == null)
        {
            GameObject baseObj = GameObject.FindWithTag("Base");
            if (baseObj != null)
            {
                target = baseObj.transform;
            }
            else
            {
                Debug.LogError("��n�iBase�^�O�t���I�u�W�F�N�g�j��������܂���I");
            }
        }
    }

    public Transform kyoten;
    public float moveSpeed = 2f;
    public int damage = 10;
    public int maxHp = 30;
    private int currentHp;

    private LineRenderer line;

    void Awake()
    {
        currentHp = maxHp;

        // ���[�g�\���p LineRenderer ������
        //line = gameObject.AddComponent<LineRenderer>();
        line = GetComponent<LineRenderer>();
        if (line == null)
        {
            line = gameObject.AddComponent<LineRenderer>();
        }

        line.positionCount = 2;
        line.startWidth = 1.0f;
        line.endWidth = 1.0f;
        line.material = new Material(Shader.Find("Sprites/Default"));
        line.startColor = Color.blue;
        line.endColor = Color.blue;
        line.enabled = false;

        //if (lineRenderer == null)
        //{
        //    lineRenderer = GetComponent<LineRenderer>();
        //}

        //if (lineRenderer != null)
        //{
        //    lineRenderer.positionCount = 2;
        //}
        //else
        //{
        //    Debug.LogError("LineRenderer ��������܂���I");
        //}

        //if (GetComponent<LineRenderer>() == null)
        //{
        //    gameObject.AddComponent<LineRenderer>();
        //}
    }

    void Update()
    {
        if (kyoten == null)
        {
            line.enabled = false;
            return;
        }

        line.enabled = true;

        // �ړ�����
        Vector3 direction = (kyoten.position - transform.position).normalized;
        transform.position += direction * moveSpeed * Time.deltaTime;

        // ��]����
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);

        // ���[�g�`��
        line.SetPosition(0, transform.position);
        line.SetPosition(1, kyoten.position);
    }

    void OnTriggerEnter(Collider other)
    {
        // kyoten �ɂԂ������ꍇ
        if (other.CompareTag("kyoten"))
        {
            KyotenHealth health = other.GetComponent<KyotenHealth>();
            if (health != null)
            {
                health.TakeDamage(damage);
            }
            Destroy(gameObject); // ����������
        }

        // Attack �I�u�W�F�N�g�ɂԂ������ꍇ
        if (other.CompareTag("Attack"))
        {
            TakeDamage(10); // �C�ӂ̃_���[�W�l
        }
    }

    public void TakeDamage(int amount)
    {
        currentHp -= amount;
        if (currentHp <= 0)
        {
            Destroy(gameObject); // HP��0�ȉ��Ȃ�폜
        }
    }
}
