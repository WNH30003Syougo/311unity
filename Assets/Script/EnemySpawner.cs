using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public class EnemySpawner : MonoBehaviour
//{
//    public GameObject enemyPrefab;
//    public Transform spawnPoint;
//    public Transform kyoten;
//    public float spawnInterval = 3f;
//    public int maxEnemies = 10;  // �ő�X�|�[����

//    private float timer;
//    private int spawnedEnemies = 0;

//    void Update()
//    {
//        // ���_�����݂��Ȃ� or ��A�N�e�B�u�Ȃ�X�|�[�����Ȃ�
//        if (kyoten == null || !kyoten.gameObject.activeInHierarchy)
//            return;

//        timer += Time.deltaTime;

//        if (timer >= spawnInterval && spawnedEnemies < maxEnemies)
//        {
//            SpawnEnemy();
//            timer = 0f;
//        }
//    }

//    void SpawnEnemy()
//    {
//        GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
//        //Instantiate(enemyPrefab, transform.position, Quaternion.identity);
//        Enemy enemyScript = enemy.GetComponent<Enemy>();
//        if (enemyScript != null)
//        {
//            enemyScript.kyoten = kyoten;
//        }
//        spawnedEnemies++;
//    }
//}

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;   // ��������G�̃v���n�u
    public float spawnInterval = 3f; // �G�𐶐�����Ԋu�i�b�j

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnEnemy();
            timer = 0f;
        }
    }

    void SpawnEnemy()
    {
        // ����GameObject�i�X�|�[���u���b�N�j�̈ʒu�ɓG�𐶐�
        Instantiate(enemyPrefab, transform.position, Quaternion.identity);
    }
}