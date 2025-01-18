using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�����ꂽ�{�^�����猻�݂̃g���b�N�p�^�[�������蓖�Ă�A���݂̃g���b�N�p�^�[���̏��(����g���b�N��g���b�N�̌��ʂȂ�)�Ɖ����ꂽ�{�^����Ԃ�
public class PushedButton_CurrentTrickPattern : MonoBehaviour
{
    [Header("�ݒ肵�����g���b�N�p�^�[��")]
    [Tooltip("�ݒ肵�����g���b�N�p�^�[���̓{�^���̎�ނ̐��̕������ݒ肵�Ă�������")]
    [SerializeField] TrickPatternEffect[] trickPatterns;//�ݒ肵�����g���b�N�p�^�[��
    TrickPatternEffect currentTrickPattern;//���݂̃g���b�N�p�^�[��

    public TrickButton PushedButton//�����ꂽ�{�^����Ԃ�
    {
        get { return currentTrickPattern.Button; }
    }

    public int TrickCost//�������{�^���ɑΉ�����g���b�N�p�^�[���̏���g���b�N��Ԃ�
    {
        get { return currentTrickPattern.TrickCost; }
    }

    public void TrickEffect()//�g���b�N�̌���
    {
        currentTrickPattern.TrickEffect();//���݂̃g���b�N�̌���
    }


    public void SetTrickPattern(TrickButton button)//�󂯎�����{�^���̎�ނɉ����Č��݂̃g���b�N�p�^�[����ݒ�(���蓖�Ă�)
    {
        for(int i=0; i< trickPatterns.Length; i++)
        {
            if (button == trickPatterns[i].Button)//�w�肵���{�^���ƃg���b�N�p�^�[���ɐݒ肳��Ă���{�^������v������
            {
                currentTrickPattern = trickPatterns[i];//���݂̃g���b�N�p�^�[�������̃g���b�N�p�^�[���ɐݒ肷��
                return;
            }
        }
    }
}
