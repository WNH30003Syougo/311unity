using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOrbit : MonoBehaviour
{
    public Transform kyoten; // ���S�ɂ���I�u�W�F�N�g
    public float distance = 5.0f; // ���S����J�����܂ł̋���
    public float xSpeed = 120.0f;  // �}�E�X���ړ��̉�]���x
    public float ySpeed = 120.0f;  // �}�E�X�c�ړ��̉�]���x

    public float yMinLimit = -20f; // �c��]�̉����p�x
    public float yMaxLimit = 80f;  // �c��]�̏���p�x

    private float x = 0.0f;
    private float y = 0.0f;

    void Start()
    {
        Vector3 angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;

        // �}�E�X�J�[�\�����Q�[���E�B���h�E���ɌŒ肵�����ꍇ�͂�����Lock
        // Cursor.lockState = CursorLockMode.Locked;
    }

    void LateUpdate()
    {
        if (kyoten != null)
        {
            if (Input.GetMouseButton(1)) // ���N���b�N�������Ȃ����
            {
                x += Input.GetAxis("Mouse X") * xSpeed * Time.deltaTime;
                y -= Input.GetAxis("Mouse Y") * ySpeed * Time.deltaTime;
                //y = Mathf.Clamp(y, yMinLimit, yMaxLimit); // �㉺�p�x�𐧌�
            }

            Quaternion rotation = Quaternion.Euler(y, x, 0);
            Vector3 position = rotation * new Vector3(0.0f, 0.0f, -distance) + kyoten.position;

            transform.rotation = rotation;
            transform.position = position;
        }
    }
}
