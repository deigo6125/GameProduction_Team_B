using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�Q�[�����̃J�����̐؂�ւ�����
public partial class CinemachineGameCamera
{
    [System.Serializable]
    class Range//�͈�
    {
        [SerializeField] float deadZoneHeight;
        bool outBeforeFrame = false;//�O�̃t���[���Ń^�[�Q�b�g���͈͊O�ɏo�Ă�����
        bool goOut = false;//�͈͊O�ɏo���u��
        bool goIn = false;//�͈͓��ɓ������u��

        public bool GoOut { get { return goOut; } }//�͈͊O�ɏo���u��
        public bool GoIn { get { return goIn; } }//�͈͓��ɓ������u��

        Range()//�R���X�g���N�^
        {

        }

        public void UpdateOutOfRange(Vector3 localPos_target)
        {
            bool outNow = localPos_target.y >= deadZoneHeight;//�͈͊O�ɏo�Ă��邩�̏���

            goOut = outNow && !outBeforeFrame;//�͈͊O�ɏo���u�Ԃ̔���̍X�V
            goIn = !outNow && outBeforeFrame;//�͈͓��ɓ������u�Ԃ̔���̍X�V

            outBeforeFrame = outNow;//�O�t���[���̃^�[�Q�b�g���͈͊O�ɏo�Ă������̔���̍X�V
        }
    }
}
