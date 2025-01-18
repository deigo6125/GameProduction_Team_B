using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//�쐬��:���R
//�g�ɐG���Ă��邩���f
public class JudgeTouchWave : MonoBehaviour
{
    public event Action<bool> SwitchTouchNowAction;//�g�̐ڐG��Ԃ��؂�ւ�������ɌĂ�(true���ƐG�ꂽ�Afalse���Ɨ��ꂽ)
    public event Action TouchAction;//�g�ɐG�ꂽ�u�ԂɌĂ�
    public event Action LeaveAction;//�g���痣�ꂽ�u�ԂɌĂ�
    [SerializeField] OnTriggerActionEvent onTriggerActionEvent;
    [SerializeField] float touchBorderTime = 0.1f;//�G�����E�G���ĂȂ��̋��E�̎���
    private bool touchWaveNow=false;//���g�ɐG���Ă��邩
    private float sinceLastTouchWaveTime = 0.1f;//�Ō�ɔg�ɐG���Ă���̎���
   
    public bool TouchWaveNow
    {
        get { return touchWaveNow; }
    }

    void Start()
    {
        onTriggerActionEvent.EnterAction += TouchWave;
        sinceLastTouchWaveTime = touchBorderTime;
    }

    void Update()
    {
        JudgeTouchWaveNow();//�g�ɐG��Ă��邩����
    }

    public void TouchWave(Collider c)
    {
        if (c.gameObject.CompareTag("InsideWave") || c.gameObject.CompareTag("OutsideWave"))
        {
            sinceLastTouchWaveTime = 0f;//�Ō�ɔg�ɐG���Ă���̎��Ԃ��X�V
            touchWaveNow = true;
            //�o�^�����������Ă�
            TouchAction?.Invoke();
            SwitchTouchNowAction?.Invoke(true);
        }
    }

    void JudgeTouchWaveNow()//�g�ɐG��Ă��邩����
    {
        if (!touchWaveNow) return;

        sinceLastTouchWaveTime += Time.deltaTime;

        //�Ō�ɔg�ɐG��Ă���touchBorderTime�b�ȏ�o������g���痣�ꂽ����Ƃ���
        if(sinceLastTouchWaveTime >= touchBorderTime)
        {
            touchWaveNow = false;
            //�o�^�����������Ă�
            LeaveAction?.Invoke();
            SwitchTouchNowAction?.Invoke(false);
        }
    }
}
