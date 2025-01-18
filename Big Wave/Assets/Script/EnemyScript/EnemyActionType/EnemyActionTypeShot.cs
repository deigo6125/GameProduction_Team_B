using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyActionTypeShot : EnemyActionTypeBase
{
    [Header("�A�j���[�V�����̐ݒ�")]
    [SerializeField] DelayAnimationTypeTrigger _animTrigger;
    [Header("�ˌ��ݒ�")]
    [SerializeField] ShotTypeBase shotType;
    [Header("�s�����̃G�t�F�N�g")]
    [SerializeField] GenerateEffect_Action _generateEffect;
    [Header("�s�����̌��ʉ�")]
    [SerializeField] PlayAudio_Action _playAudio;
    [SerializeField] CinemachineVirtualCamera _shotCamera;

    public override void OnEnter(EnemyActionTypeBase[] beforeActionType)
    {
        shotType.InitShotTiming();//�ˌ��̏���������
        if (_generateEffect != null) _generateEffect.OnEnter();//�G�t�F�N�g�̏���������
        if(_playAudio!=null) _playAudio.OnEnter();//���ʉ��̏���������
        _animTrigger.Start();//���[�V�����̍Đ������̏�����
        if (_shotCamera != null) _shotCamera.enabled = true;
    }

    public override void OnUpdate()
    {
        shotType.UpdateShotTiming();//�ˌ��̍X�V����
        if (_generateEffect != null) _generateEffect.OnUpdate();//�G�t�F�N�g�̍X�V����
        if (_playAudio!=null) _playAudio.OnUpdate();//���ʉ��̍X�V����
        _animTrigger.Update();//���[�V�����̍Đ������̍X�V
    }

    public override void OnExit(EnemyActionTypeBase[] nextActionType)
    {
        if(_shotCamera!=null) _shotCamera.enabled = false;
    }
}
