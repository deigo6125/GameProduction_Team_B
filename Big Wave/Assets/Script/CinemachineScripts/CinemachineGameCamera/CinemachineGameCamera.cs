using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�Q�[�����̃J�����̓���
public partial class CinemachineGameCamera : MonoBehaviour
{
    [Header("���ɂ��鎞�̃J����")]
    [SerializeField] CinemachineVirtualCamera _underCamera;
    [Header("��ɂ��鎞�̃J����")]
    [SerializeField] CinemachineVirtualCamera _upCamera;
    [Header("�J�����؂�ւ�����")]
    [Tooltip("�^�[�Q�b�g�̃��[�J�����W�����̒l�ȏ�̎��A�J������؂�ւ���")]
    [SerializeField] Range _range_switchCamera;
    [Header("�^�[�Q�b�g")]
    [SerializeField] Transform _target;

    void Update()
    {
        MonitoringTarget();
    }

    void MonitoringTarget()//�v���C���[�̈ʒu���Ď�(�ʒu�ɂ���ăJ������؂�ւ���)
    {
        _range_switchCamera.UpdateOutOfRange(_target.localPosition);

        if (_range_switchCamera.GoOut) UpdateCamera(false);//�͈͊O�ɏo���u��

        if (_range_switchCamera.GoIn) UpdateCamera(true);//�͈͓��ɓ������u��
    }

    void UpdateCamera(bool underCameraOn)
    {
        _underCamera.enabled = underCameraOn;
        _upCamera.enabled = !underCameraOn;
    }
}
