using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�`�Ԃ��ƂɃ����_���ōs���p�^�[����I��
public class SelectActionOfEnemyTypeFormRandom : SelectActionOfEnemyTypeBase
{
    [Header("���G�̌`�Ԃ��Ƃ̍s��")]
    [SerializeField] ProbabilityGet<ActionPattern>[] forms;//�`�Ԃ��Ƃ̍s���p�^�[��
    [Header("�����݂̌`�Ԃ�Ԃ��R���|�[�l���g")]
    [SerializeField] FormOfEnemyTypeBase formOfEnemy;//���݂̌`�Ԃ�Ԃ��R���|�[�l���g

    void Start()
    {
        //�S�Ă̌`�Ԃ̍s���m���̍��v���Z�o
        for (int i = 0; i < forms.Length; i++)
        {
            forms[i].CalcSum();
        }
    }

    public override ActionPattern SelectAction()//���ɂ��s����Ԃ�
    {
        int formNum = formOfEnemy.CurrentForm();//���ݑ扽�`�Ԃ��Aforms�̗v�f�ԍ��l�Ȃ̂łɓ����v�f�Ⴆ�Α��`�ԂȂ�1������

        return forms[formNum].Get();
    }
}
