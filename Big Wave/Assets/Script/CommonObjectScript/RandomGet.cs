using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�o�^�������̂̒����烉���_���ɕԂ�(�^�w��\)
[System.Serializable]
public class RandomGet<T>
{
    [SerializeField] T[] elements;

    public T this[int i]
    {
        get { return elements[i]; }
    }

    public int ElementsNum { get { return elements.Length; } }//�v�f����Ԃ�

    public RandomGet()//�R���X�g���N�^
    {

    }

    //�Ă΂��ƃ����_���ɕԂ�
    public T Get()
    {
        if (elements == null)
        {
            Debug.Log("�����ݒ肳��Ă��܂���");
            return default(T);
        }

        return elements[Random.Range(0,elements.Length)];
    }
}
