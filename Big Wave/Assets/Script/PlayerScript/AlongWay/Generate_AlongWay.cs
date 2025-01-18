using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//���[�v��`���G�t�F�N�g�𐶐�����
public class Generate_AlongWay : MonoBehaviour
{
    [Header("�ʏ�̃g���b�N�̃G�t�F�N�g")]
    [SerializeField] EffectType_AlongWay normalTrickEffect=new EffectType_AlongWay();//�ʏ�̃g���b�N�̃G�t�F�N�g
    [Header("�N���e�B�J���̃g���b�N�̃G�t�F�N�g")]
    [SerializeField] EffectType_AlongWay criticalTrickEffect = new EffectType_AlongWay();//�N���e�B�J���̃g���b�N�̃G�t�F�N�g
    [Header("�N���e�B�J���t�B�[�o�[�̃g���b�N�̃G�t�F�N�g")]
    [SerializeField] EffectType_AlongWay criticalFeverTrickEffect = new EffectType_AlongWay();//�N���e�B�J���t�B�[�o�[�̃g���b�N�̃G�t�F�N�g
    [Header("�G�t�F�N�g�𐶐�����C���^�[�o��")]
    [SerializeField] float generateInterval;//�G�t�F�N�g�𐶐�����C���^�[�o��
    [Header("�G�t�F�N�g�̒ʂ�n�_")]
    [SerializeField] Transform[] effectWays;//�G�t�F�N�g�̒ʂ�n�_�A�ŏ��̒n�_����w�莞�Ԃ��Ƃɐi��ł����čŌ�̒n�_�Œ��e�G�t�F�N�g���o��
    [SerializeField] Critical critical;
    [SerializeField] FeverMode feverMode;
    private List<Pos_AlongWay> generatePosList = new List<Pos_AlongWay>();//�G�t�F�N�g�����ʒu���̃��X�g

    public EffectType_AlongWay NormalTrickEffect { get { return  normalTrickEffect; }}
    public EffectType_AlongWay CriticalTrickEffect { get { return criticalTrickEffect; }}

    public EffectType_AlongWay CriticalFeverTrickEffect { get { return criticalFeverTrickEffect; }}

    void Update()
    {
        GenerateEffectAtGeneratePos();
        DestroyGeneratePos();
    }

    //�g���b�N���ɌĂяo��(�G�t�F�N�g��V���ɐ���������)
    public void ActivateEffect()
    {
        GenerateType_AlongWay generateType;

        //�g���b�N�̏�(�N���e�B�J���Ƃ��t�B�[�o�[���Ƃ�)�ɂ���ăG�t�F�N�g��ς���
        if (critical.CriticalNow&&feverMode.FeverNow)//�t�B�[�o�[�����N���e�B�J��
        {
            generateType = GenerateType_AlongWay.criticalFever;
        }
        else if(critical.CriticalNow)//�N���e�B�J������
        {
            generateType = GenerateType_AlongWay.critical;
        }
        else//�ʏ�g���b�N
        {
            generateType = GenerateType_AlongWay.normal;
        }

        generatePosList.Add(new Pos_AlongWay(generateType, generateInterval));
    }

    void GenerateEffectAtGeneratePos()//�ʂ�n�_�ɃG�t�F�N�g�𐶐�
    {
        for (int i = 0; i < generatePosList.Count; i++)
        {
            generatePosList[i].UpdateGenerateTime();

            if (generatePosList[i].Should_Generate(generateInterval))
            {
                Transform passPos = effectWays[generatePosList[i].PosNum_GenerateEffect];//�G�t�F�N�g�𐶐�����n�_��ݒ�

                bool isLastPoint = (generatePosList[i].PosNum_GenerateEffect == effectWays.Length - 1);//�ŏI(���e)�n�_��

                EffectType_AlongWay effectType = EffectType(generatePosList[i].Type);//�G�t�F�N�g�̐����^�C�v

                GameObject effect = isLastPoint ? effectType.LandEffect() : effectType.PassEffect();//�ŏI�n�_�Ȃ璅�e�G�t�F�N�g�������łȂ��Ȃ�`���G�t�F�N�g�ɐݒ�

                if(effect!=null) Instantiate(effect, passPos.position, passPos.rotation, passPos);//����

                generatePosList[i].TransitNextPos();//���̏ꏊ��ݒ�
            }
        }
    }

    void DestroyGeneratePos()//�ŏI�n�_�ŃG�t�F�N�g���o����PassPos�C���X�^���X������
    {
        while (generatePosList.Count != 0)
        {
            if (generatePosList[0].PosNum_GenerateEffect >= effectWays.Length)
            {
                generatePosList.RemoveAt(0);//�폜
            }
            else
            {
                break;
            }
        }
    }

    EffectType_AlongWay EffectType(GenerateType_AlongWay generateType)//�����̃G�t�F�N�g�̐����^�C�v���炻��ɑΉ������G�t�F�N�g�^�C�v��Ԃ�
    {
        switch(generateType)
        {
            case GenerateType_AlongWay.normal: return normalTrickEffect;
            case GenerateType_AlongWay.critical: return criticalTrickEffect;
            case GenerateType_AlongWay.criticalFever: return criticalFeverTrickEffect;
            default: return null;
        }
    }
}


