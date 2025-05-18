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
                Debug.LogError("基地（Baseタグ付きオブジェクト）が見つかりません！");
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

        // ルート表示用 LineRenderer 初期化
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
        //    Debug.LogError("LineRenderer が見つかりません！");
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

        // 移動処理
        Vector3 direction = (kyoten.position - transform.position).normalized;
        transform.position += direction * moveSpeed * Time.deltaTime;

        // 回転処理
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);

        // ルート描画
        line.SetPosition(0, transform.position);
        line.SetPosition(1, kyoten.position);
    }

    void OnTriggerEnter(Collider other)
    {
        // kyoten にぶつかった場合
        if (other.CompareTag("kyoten"))
        {
            KyotenHealth health = other.GetComponent<KyotenHealth>();
            if (health != null)
            {
                health.TakeDamage(damage);
            }
            Destroy(gameObject); // 自分を消す
        }

        // Attack オブジェクトにぶつかった場合
        if (other.CompareTag("Attack"))
        {
            TakeDamage(10); // 任意のダメージ値
        }
    }

    public void TakeDamage(int amount)
    {
        currentHp -= amount;
        if (currentHp <= 0)
        {
            Destroy(gameObject); // HPが0以下なら削除
        }
    }
}
