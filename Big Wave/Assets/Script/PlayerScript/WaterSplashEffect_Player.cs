using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�v���C���[�̐����Ԃ��̓���
//�W�����v���͏����悤�ɂ���
public class WaterSplashEffect_Player : MonoBehaviour
{
    [SerializeField] JudgeJumpNow _judgeJumpNow;
    [Header("�����Ԃ��̃G�t�F�N�g")]
    [SerializeField] GameObject _waterSplashEffect;

    private void OnEnable()
    {
        _judgeJumpNow.SwitchJumpNowAction += Effect;
    }

    private void OnDisable()
    {
        _judgeJumpNow.SwitchJumpNowAction -= Effect;
        _waterSplashEffect.SetActive(false);//�����Ԃ����\����
    }

    void Effect(bool switchJumpNow)
    {
        _waterSplashEffect.SetActive(!switchJumpNow);//�����Ԃ����W�����v�J�n���ɏ����A���n���ɏo��
    }
}
