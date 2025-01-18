using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�o�^�������̂̒�����m���ŕԂ�(�^�w��\)
[System.Serializable]
public partial class ProbabilityGet<T>
{
    [SerializeField] Element_ProbabilityGet[] elements;
    float probabilitySum=0;//�o�^���ꂽ�v�f�����̊m�����v
    const float errorProbabilitySum = 0;//�m�����v�����̒l�ȉ����Ɖ����ݒ肳��ĂȂ�����ɂ���

    public T this[int i]
    {
        get { return elements[i].Element; }
    }

    public int ElementsNum { get { return elements.Length; } }//�v�f����Ԃ�

    public ProbabilityGet() { }//�f�t�H���g�R���X�g���N�^
    

    public void CalcSum()//Get�g�p�O��1��͕K���ĂԁA�m���̍��v���Z�o����
    {
        //�m���̍��v���Z�o
        for(int i=0; i<elements.Length;i++)
        {
            probabilitySum += elements[i].Probability;
        }
    }

    //�Ă΂��Ɗm���ŕԂ�
    public T Get()
    {
        if (elements == null||probabilitySum<= errorProbabilitySum)//�����o�^����Ă��Ȃ������ꍇ
        {
            Debug.Log("�����ݒ肳��Ă��܂���");
            return default(T);
        }

        //�I�o���@
        //1...0�`�S�Ă̗v�f�̊m�����v���烉���_���Œl���o��
        //2...�v�f�ԍ���0�̗v�f���珇�Ɋm���̒l�𑫂��Ă���
        //3...���̍��v�������_���ŏo�����l�ȏ�ɂȂ�������������m���̒l�𑫂����v�f��Ԃ�
        
        float randomNum= Random.Range(0f, probabilitySum);//1�ԂŐ������������_���̒l

        float searchProbabilitySum = 0;//2�ԂŊm���̒l�𑫂��Ă����ϐ�

        //�ǂ̗v�f��Ԃ��������肷�鏈��
        for(int i=0;i< elements.Length; i++)
        {
            searchProbabilitySum += elements[i].Probability;

            if(randomNum<=searchProbabilitySum)//3�ԂŐ��������ʂ�
            {
                return elements[i].Element;
            }
        }

        //�z��O�̎��p(���ʂ͋N����Ȃ��̂ňȉ��̏������Ă΂�邱�Ƃ͂Ȃ��͂�)
        Debug.Log("�G���[");
        return default(T);

    }
}
