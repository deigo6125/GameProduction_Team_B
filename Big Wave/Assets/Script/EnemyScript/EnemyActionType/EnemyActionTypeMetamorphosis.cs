using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�`�ԕω�
public class EnemyActionTypeMetamorphosis : EnemyActionTypeBase
{
    [Header("�`�ԕω����̃J����")]
    [Header("�J�����𓮂��������Ȃ���΋�ɂ��Ă�������")]
    [SerializeField] CinemachineVirtualCamera _metamorCamera;
    [Header("�I�u�W�F�N�g�̕\����Ԃ�؂�ւ���ݒ�")]
    [Header("�I�[���̕\���ؑւɎg���Ă�������")]
    [SerializeField] ChangeActiveOfObject _changeActive;
    [Header("�A�j���[�V�����̐ݒ�")]
    [SerializeField] DelayAnimationTypeTrigger _animTrigger;
    [Header("�s�����̃G�t�F�N�g")]
    [SerializeField] GenerateEffect_Action _generateEffect;
    [Header("�s�����̌��ʉ�")]
    [SerializeField] PlayAudio_Action _playAudio;

    public override void OnEnter(EnemyActionTypeBase[] beforeActionType)
    {
        _changeActive.Init();//�I�u�W�F�N�g�̕\����Ԃ�؂�ւ��鏉��������
        if (_generateEffect != null) _generateEffect.OnEnter();//�G�t�F�N�g�̏���������
        if (_playAudio != null) _playAudio.OnEnter();//���ʉ��̏���������
        _animTrigger.Start();//���[�V�����̍Đ������̏�����
        if (_metamorCamera != null) _metamorCamera.enabled = true;//�`�ԕω����̃J�������N��
    }

    public override void OnUpdate()
    {
        _changeActive.UpdateActive();//�I�u�W�F�N�g�̕\����Ԃ�؂�ւ���X�V����
        if (_generateEffect != null) _generateEffect.OnUpdate();//�G�t�F�N�g�̍X�V����
        if (_playAudio != null) _playAudio.OnUpdate();//���ʉ��̍X�V����
        _animTrigger.Update();//���[�V�����̍Đ������̍X�V
    }

    public override void OnExit(EnemyActionTypeBase[] nextActionType)
    {
        if (_metamorCamera != null) _metamorCamera.enabled = false;//�`�ԕω����̃J�������I��
    }
}
