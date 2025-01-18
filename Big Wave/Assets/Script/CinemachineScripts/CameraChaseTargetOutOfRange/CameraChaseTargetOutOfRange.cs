using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

//�쐬��:���R
//�J�������w��͈̔͊O�ɏo����^�[�Q�b�g��Ǐ]���n�߂�
public partial class CameraChaseTargetOutOfRange : MonoBehaviour
{
    [SerializeField] CinemachineTargetGroup m_TargetGroup;
    [SerializeField] float weight;
    [SerializeField] float radius;
    [SerializeField] Transform target;
    [SerializeField] Range range;

    void Update()
    {
        UpdateCameraChase();
    }

    void UpdateCameraChase()
    {
        range.UpdateOutOfRange(target.localPosition);

        if(range.GoOut)//�͈͊O�ɏo���u��
        {
            m_TargetGroup.AddMember(target, weight, radius);
        }
        //�͈͓��ɓ������u��
        if(range.GoIn)
        {
            m_TargetGroup.RemoveMember(target);
        }
    }
}
