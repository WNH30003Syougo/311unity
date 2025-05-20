using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    public Transform target;        // �J��������������^�[�Q�b�g
    public float zoomSpeed = 10f;   // �Y�[���̃X�s�[�h
    public float minDistance = 5f;  // �ŏ�����
    public float maxDistance = 20f; // �ő勗��

    private float currentDistance;

    // Start is called before the first frame update
    void Start()
    {
        if (target == null)
        {
            Debug.LogError("�^�[�Q�b�g���ݒ肳��Ă��܂���I");
            return;
        }

        // �����������v�Z
        currentDistance = Vector3.Distance(transform.position, target.position);

    }

    // Update is called once per frame
    void Update()
    {
        if (target == null) return;

        // �z�C�[���̓��͂��擾
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        // �������X�V�i�Y�[���C���F���A�Y�[���A�E�g�F���j
        currentDistance -= scroll * zoomSpeed;
        currentDistance = Mathf.Clamp(currentDistance, minDistance, maxDistance);

        // �^�[�Q�b�g�����苗���̈ʒu�ɃJ������z�u
        transform.position = target.position - transform.forward * currentDistance;

    }
}
