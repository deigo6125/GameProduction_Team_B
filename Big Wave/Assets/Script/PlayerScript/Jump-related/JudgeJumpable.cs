using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//�쐬��:���R
//���W�����v�ł��邩���肷��
public class JudgeJumpable : MonoBehaviour
{
    public event Action<bool> SwitchJumpable;//�W�����v�\�����؂�ւ��u�ԂɌĂԁAtrue�Ȃ�W�����v�ł���悤�ɂȂ������Afalse�Ȃ�W�����v�ł��Ȃ��Ȃ�����
    public event Action ToJumpable;//�W�����v�\�ɂȂ������ɌĂ�
    public event Action ToNotJumpable;//�W�����v�s�\�ɂȂ������ɌĂ�
    [SerializeField] JudgeJumpNow _judgeJumpNow;
    [SerializeField] JudgeTouchWave _judgeTouchWave;
    bool _jumpableBeforeFrame = false;//�O�t���[���̃W�����v�\���

    public bool Jumpable//�W�����v�\����
    {
        get { return _judgeTouchWave.TouchWaveNow&&!_judgeJumpNow.JumpNow(); }//�g�ɐG��Ă��鎞���W�����v���Ă��Ȃ����̂݃W�����v�\
    }

    void Update()
    {
        JudgeSwitchJumpable();
    }

    void JudgeSwitchJumpable()
    {
        if(_jumpableBeforeFrame!=Jumpable)//�W�����v�\��Ԃ��؂�ւ�������ɐ؂�ւ��̏u�Ԃ̏������Ă�
        {
            bool switchJumpable = !_jumpableBeforeFrame;//�O�t���[���ŃW�����v�s�\�ł���� �W�����v�\�ɂȂ����Ƃ�������

            //�W�����v�\�󋵂̐؂�ւ�莞�̏������Ă�
            SwitchJumpable?.Invoke(switchJumpable);

            if(switchJumpable)
            {
                ToJumpable?.Invoke();
            }
            else
            {
                ToNotJumpable?.Invoke();
            }
        }

        _jumpableBeforeFrame = Jumpable;//�O�t���[���̃W�����v�\��Ԃ̍X�V
    }
}
