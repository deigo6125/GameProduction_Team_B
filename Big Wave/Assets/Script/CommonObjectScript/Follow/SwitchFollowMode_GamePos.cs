using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�ǐՏ�Ԃ�؂�ւ���
//�Ƃ肠�����ǐՂ�����I�u�W�F�N�g���ǐՂ���^�[�Q�b�g�̏���z���W���z������ǐՃ��[�h�ɐ؂�ւ���(����܂ł͒ǐՂ�����I�u�W�F�N�g�͒P���ɑO�ɐi�܂���)
public class SwitchFollowMode_GamePos : MonoBehaviour
{
    [Header("�ǐՂ���^�[�Q�b�g")]
    [SerializeField] Transform _target;
    [Header("�ǐՂ�����I�u�W�F�N�g")]
    [SerializeField] Transform _followObject;
    [Header("�ǐՃ��[�h�ɐ؂�ւ���܂ł̑O���ړ����x")]
    [SerializeField] float _speed;
    [Header("�ǐՂ̐ݒ�")]
    [SerializeField] FollowPassOfObject _follow;
    float _targetDefaultPos_Z;//�ǐՃ^�[�Q�b�g�̏���z���W

    private void Start()
    {
        //�ǐՃ^�[�Q�b�g�̏���z���W��ۑ�
        _targetDefaultPos_Z=_target.position.z;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        //���ɒǐՃ��[�h�ɂȂ��Ă�Ζ���
        if (_follow.IsFollow) return;

        //�ǐՂ�����I�u�W�F�N�g���ǐՃ^�[�Q�b�g�̏���z���W���z����܂ł�
        //���ʂɑO���ړ�
        //�z������ǐՃ��[�h�ɐ؂�ւ�

        bool exceeded=_followObject.position.z >= _targetDefaultPos_Z;//����z���W�𒴂�����

        if (exceeded)
        {
            _follow.IsFollow = true;
        }
        else
        {
            Vector3 moveVec = Vector3.forward;
            _followObject.transform.Translate(moveVec * _speed * Time.deltaTime);
        }
    }
}
