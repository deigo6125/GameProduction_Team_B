using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�G�̉��ړ�
public class EnemyActionTypeMove : EnemyActionTypeBase
{
    [Header("�������������I�u�W�F�N�g")]
    [SerializeField] GameObject moveObject;//�����������I�u�W�F�N�g(�G)
    [Header("�������ŏ��X�s�[�h")]
    [SerializeField] float speedMin = 15f;//�����ŏ��X�s�[�h
    [Header("�������ő�X�s�[�h")]
    [SerializeField] float speedMax = 20f;//�����ő�X�s�[�h
    [Header("���i�s�������ς��ŏ�����")]
    [SerializeField] float changeTimeMin;//�i�s�������ς��ŏ�����
    [Header("���i�s�������ς��ŏ�����")]
    [SerializeField] float changeTimeMax;//�i�s�������ς��ő厞��
    [Header("������Ă�������Ɣ��Α������Ɉړ�����m��(%)")]
    [SerializeField] float directionProbability = 60f;
    private float speed;//�����X�s�[�h
    private float currentChangeTime=0;//���ꂪ�i�s�����ύX���鎞��(changeTime)�ɒB����ƁA�i�s������ύX����
    private float changeTime;//�i�s�����ύX����
    private Vector3 move;

    public override void OnEnter(EnemyActionTypeBase[] beforeActionType)
    {
        ChangeMove();//��������ύX����
    }

    public override void OnUpdate()
    {
        currentChangeTime += Time.deltaTime;

        bool moveChange = (currentChangeTime >= changeTime);//�i�s�����ύX���ԂɒB����ƁA�i�s������ύX����

        if(moveChange)//�i�s�����ύX
        {
            ChangeMove();//��������ύX����
        }
        
        Move();//����
    }

    public override void OnExit(EnemyActionTypeBase[] nextActionType)
    {
       
    }

    void ChangeMove()//��������ύX����
    {
        //���������������_���ݒ�
        float change = Random.Range(0, 100);

        if (IsLeft())//�����ɂ��鎞
        {
            //�����ɂ��鎞�E�����Ɉړ����₷������
            if (change <= directionProbability)
            {
                move = Vector3.right;
            }
            else
            {
                move = Vector3.left;
            }
        }
        else//�E���ɂ��鎞
        {
            //�E���ɂ��鎞�������Ɉړ����₷������
            if (change <= directionProbability)
            {
                move = Vector3.left;
            }
            else
            {
                move = Vector3.right;
            }
        }

        //�X�s�[�h�������_���ݒ�
        speed = Random.Range(speedMin, speedMax);

        //�i�s�����ύX���Ԃ������_���ݒ�
        changeTime = Random.Range(changeTimeMin, changeTimeMax);
        //currentChangeTime�����Z�b�g
        currentChangeTime = 0;
    }

    bool IsLeft()//�������ɂ��邩�m�F
    {
        Vector3 currentPos;//���݈ʒu

        currentPos = moveObject.transform.position;

        if (currentPos.x <= 0)//�����ɂ���
        {
            return true;
        }
        else//�E���ɂ���
        {
            return false;
        }
    }

    //����
    void Move()
    {
        moveObject.transform.Translate(move * speed * Time.deltaTime);
    }
}
