using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoRigidBullet : MonoBehaviour
{
    float m_speed;//�e�̈ړ����x
    Vector3 m_shotVec;//�e�̈ړ�����

    public void SetBullet(float speed,Vector3 shotVec)//�e�̃X�e�[�^�X��ݒ�
    {
        m_speed = speed;
        m_shotVec = shotVec;
    }

    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = Quaternion.LookRotation(m_shotVec, Vector3.up);
    }

    // Update is called once per frame
    void Update()
    {
        MoveForward();
    }

    void MoveForward()//�O(���Ă����)�ɐi�ݑ�����
    {
        Vector3 move = Vector3.forward;
        transform.Translate(move * Time.deltaTime * m_speed);
    }
}
