using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//ProbabilityGet�N���X�̓����N���X(�v�f)�̒�`
public partial class ProbabilityGet<T>
{
    //ProbabilityGet�N���X������o�����v�f�̃N���X
    [System.Serializable]
    class Element_ProbabilityGet
    {
        [Header("�v�f��")]
        [Header("�����ɂ͑S���֌W�Ȃ����A�C���X�y�N�^�[�����₷�����邽��")]
        [SerializeField] string name;
        [Header("�v�f")]
        [SerializeField] T element;//�v�f
        [Header("�m��")]
        [SerializeField] float probability;//�m��

        public T Element { get { return element; } }
        public float Probability { get {  return probability; } }
    }
}
