using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//���[�v��`���G�t�F�N�g�̈ʒu(�G�t�F�N�g���o���n�_�ƃ^�C�~���O��)���
class Pos_AlongWay
{
    GenerateType_AlongWay type;
    int posNum_GenerateEffect;//�G�t�F�N�g���o���n�_�̗v�f�ԍ�
    float generateTime;//�G�t�F�N�g�𐶐�����^�C�~���O���Ǘ����鎞��


    public GenerateType_AlongWay Type { get { return type; } }
    public int PosNum_GenerateEffect { get { return posNum_GenerateEffect; } }
    public float GenerateTime { get { return generateTime; } }

    //�R���X�g���N�^
    public Pos_AlongWay(GenerateType_AlongWay generateType, float defaultTime)
    {
        type = generateType;
        posNum_GenerateEffect = 0;
        generateTime = defaultTime;
    }

    public bool Should_Generate(float transitNextPosInterval)//�G�t�F�N�g�𐶐�����Ȃ�true��Ԃ�
    {
        return (generateTime >= transitNextPosInterval);
    }

    public void TransitNextPos()//���̒n�_�ɐݒ�
    {
        posNum_GenerateEffect++;//���̏ꏊ��ݒ�
        generateTime = 0;//�G�t�F�N�g�𐶐�����^�C�~���O���Ǘ����鎞�Ԃ����Z�b�g
    }

    public void UpdateGenerateTime()//�G�t�F�N�g�𐶐�����^�C�~���O���Ǘ����鎞�Ԃ��X�V
    {
        generateTime += Time.deltaTime;
    }
}
