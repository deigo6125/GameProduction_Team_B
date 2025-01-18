using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�J�����̎���Ǐ]�ڕW�Ɠ��������Ɍ����悤�ɌŒ肳����
public class CinemachineExtend_Look : CinemachineExtension
{
    [Header("�Ǐ]�ڕW")]
    [SerializeField] Transform target;
    [Header("�Œ肷�鎲")]
    [SerializeField] bool x;
    [SerializeField] bool y;
    [SerializeField] bool z;

    public bool X
    {
        get { return x; }
        set { x = value; }
    }

    public bool Y
    { 
        get { return y; }
        set {  y = value; } 
    }

    public bool Z
    {
        get { return z; }
        set { z = value; }
    }

    // �J�������[�N����
    protected override void PostPipelineStageCallback(
        CinemachineVirtualCameraBase vcam,
        CinemachineCore.Stage stage,
        ref CameraState state,
        float deltaTime
    )
    {
        // Aim�̒��ゾ�����������{
        if (stage != CinemachineCore.Stage.Aim)
            return;

        //�`�F�b�N����ꂽ�Œ莲�ɑ΂��ČŒ肷��
        var eulerAngles = state.RawOrientation.eulerAngles;
        if (x) eulerAngles.x = target.eulerAngles.x;//x���̌Œ�
        if (y) eulerAngles.y = target.eulerAngles.y;//x���̌Œ�
        if (z) eulerAngles.z = target.eulerAngles.z;//x���̌Œ�
        state.RawOrientation = Quaternion.Euler(eulerAngles);
    }

    
}
