using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//��莞�Ԓe���z�[�~���O���Ȃ��瓮��
public class HomingBullet : MonoBehaviour
{
    float m_startHomingTime;//���˂���ĉ��b�ォ��z�[�~���O���n�߂邩                      
    float m_homingTime;//���b�ԃz�[�~���O���邩
    float m_homingSpeed;//�W�I�Ɍ������x
    float m_speed;//�e�̈ړ����x

    private float currentHomingTime = 0;//���݂̃z�[�~���O����
    private float finishHomingTime;//���˂���ĉ��b��Ƀz�[�~���O����߂邩
    Transform target;//�z�[�~���O���̕W�I(�v���C���[)

    //������startHomingTime�͔��˂���ĉ��b�ォ��z�[�~���O���n�߂邩�A
    //homingTime�͉��b�ԃz�[�~���O���邩
    //homingSpeed�͕W�I�Ɍ������x
    //speed�͑O���ړ����x
    public void SetBullet(float startHomingTime,float homingTime,float homingSpeed,float speed)//�z�[�~���O�e�̃X�e�[�^�X(�W�I�Ɍ������x�Ȃ�)��ݒ�
    {
        m_startHomingTime=startHomingTime;
        m_homingTime=homingTime;
        m_homingSpeed=homingSpeed;
        m_speed=speed;
    }

    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        finishHomingTime = m_startHomingTime + m_homingTime;//�z�[�~���O�I�����Ԃ�ݒ�
    }

    void Update()
    {
        currentHomingTime += Time.deltaTime;

        bool homingNow = (m_startHomingTime <= currentHomingTime && currentHomingTime <= finishHomingTime);

        if(homingNow)//���ԂɂȂ�܂ŕW�I�̕�������������
        {
            Homing();//�W�I����������
        }

        MoveForward();//�O(���Ă����)�ɐi�ݑ�����
    }

    void Homing()//�W�I����������
    {
        Vector3 targetPos = target.transform.position - transform.position;//�����̈ʒu����W�I�̈ʒu�܂ł̃x�N�g���̎擾
        Quaternion targetRotation = Quaternion.LookRotation(targetPos);//���݂̃x�N�g�������]����p�x��ݒ�
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, m_homingSpeed*Time.deltaTime);
    }

    void MoveForward()//�O(���Ă����)�ɐi�ݑ�����
    {
        Vector3 move = Vector3.forward;
        transform.Translate(move * Time.deltaTime * m_speed);
    }
}
