using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�A���N���e�B�J���񐔂��v��
public partial class Count_Trick_Critical
{
    class CountContinuanceCritical
    {
        private int _continuanceCriticalCount = 0;//�A���N���e�B�J����
        private bool _continueCritical = false;//�N���e�B�J���������Ă��邩
        const int _resetContinuanceCriticalCount = 0;//���Z�b�g���̘A���N���e�B�J����

        public int ContinuanceCriticalCount { get { return  _continuanceCriticalCount; } }//�A���N���e�B�J����
        public bool ContinueCritical { get { return _continueCritical; } }//�N���e�B�J���������Ă��邩

        public CountContinuanceCritical() { }//�R���X�g���N�^

        public void Add()//�N���e�B�J���������Ă��鎞�̉��Z����
        {
            _continuanceCriticalCount++;
            _continueCritical = true;
        }

        public void Reset()//�N���e�B�J�����r�؂ꂽ���̃��Z�b�g����
        {
            _continuanceCriticalCount = _resetContinuanceCriticalCount;
            _continueCritical = false;
        }
    }
}