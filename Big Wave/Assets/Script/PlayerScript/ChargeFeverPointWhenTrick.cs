using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�g���b�N�񐔂ɂ���Ă��̕��t�B�[�o�[�|�C���g�����܂�
public class ChargeFeverPointWhenTrick : MonoBehaviour
{
    [Header("�񐔂��Ƃ̗��܂�t�B�[�o�[�|�C���g�̒l")]
    [Header("����:�g���b�N�Q�[�W�̌����z���p�ӂ��Ă�������")]
    [SerializeField] float[] chargeFeverPoint;//�񐔂��Ƃ̗��܂�t�B�[�o�[�|�C���g�̒l
    [Header("�K�v�ȃR���|�[�l���g")]
    [SerializeField] FeverPoint player_FeverPoint;
    [SerializeField] FeverMode feverMode;
    [SerializeField] CountTrickWhileJump countTrickWhileJump;
    [SerializeField] Critical critical;
    int count;

    //�t�B�[�o�[�|�C���g�̃`���[�W
    public void Charge()
    {
        if (!feverMode.FeverNow&&critical.CriticalNow)//�t�B�[�o�[��ԂłȂ����g���b�N�������������̂ݗ��܂�悤�ɂ���
        {
             count = countTrickWhileJump.TrickCount;//�g���b�N���������̂���1��̃W�����v���ɂ����g���b�N��(1�W�����v���̃g���b�N�񐔂̉��Z��ɂ��̏���������悤�ɂ���)

            if (count>chargeFeverPoint.Length) count = chargeFeverPoint.Length;//��O�����΍�

            player_FeverPoint.FeverPoint_ += chargeFeverPoint[count - 1];//�t�B�[�o�[�|�C���g���Z(�g���b�N�������邲�Ƃɉ��Z����悤�ɂ���)
          
        }
    }
}
