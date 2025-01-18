using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

//�쐬��:���R
//�|�[�Y�̔��f
public class JudgePauseNow : MonoBehaviour
{
    public event Action PauseAction;
    public event Action ResumeAction;
    public event Action<bool> SwitchPauseAction;//�|�[�Y��ԂɂȂ鎞��true�A�|�[�Y��������Ƃ���false
    bool pauseNow = false;

    public bool PauseNow
    {
        get { return pauseNow; }
    }

    public void SwitchPause()//�|�[�Y��Ԃ𔽓]
    {
        pauseNow=!pauseNow;

        SwitchPauseAction?.Invoke(pauseNow);

        if(pauseNow)//�|�[�Y��
        {
            PauseAction?.Invoke();
        }
        else//�ĉ
        {
            ResumeAction?.Invoke();
        }
    }
}
