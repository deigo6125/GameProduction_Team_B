using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�^�[�Q�b�g��ǂ�������UI
public class ChaseObjectOnUI : MonoBehaviour
{
    [Header("�I�u�W�F�N�g���ڂ��J����")]
    [SerializeField] Camera _targetCamera;
    [Header("�ǂ�������Ώ�")]
    [SerializeField] private Transform _target;
    [Header("���炩�ɃQ�[�W���ړ�����悤�ɂ���")]
    [Tooltip("�Q�[�W���U������̂����܂������߂̏��u")]
    [SerializeField] SmoothMovement _smoothMovement;
    private RectTransform _parentUI;//�e�̈ʒu

    void Start()
    {
        // �J�������w�肳��Ă��Ȃ���΃��C���J�����ɂ���
        if (_targetCamera == null)
            _targetCamera = Camera.main;

        // �eUI��RectTransform��ێ�
        _parentUI = transform.parent.GetComponent<RectTransform>();

        _smoothMovement.SecureBuffer();//�o�b�t�@�̊m��
    }

    void Update()
    {
        UpdateUIPos();
    }

    void UpdateUIPos()//UI�̈ʒu���X�V
    {
        // �I�u�W�F�N�g�̈ʒu
        var targetWorldPos = _target.position;
       
        if (!TargetIsFront(targetWorldPos)) return;

        // �I�u�W�F�N�g�̃��[���h���W���X�N���[�����W�ϊ�
        var targetScreenPos = _targetCamera.WorldToScreenPoint(targetWorldPos);

        // �X�N���[�����W�ϊ���UI���[�J�����W�ϊ�
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            _parentUI,
            targetScreenPos,
            null,//Canvas��renderMode��Overray�̎���null�ɂ���
            out var uiLocalPos
        );

        // RectTransform�̃��[�J�����W���X�V
        transform.localPosition = _smoothMovement.Smooth(uiLocalPos);//���������炩�ɂ���
    }

    bool TargetIsFront(Vector3 targetWorldPos)//�^�[�Q�b�g���J�����̑O�ɂ��邩
    {
        Transform cameraTransform = _targetCamera.transform;

        // �J�����̌����x�N�g��
        Vector3 cameraDir = cameraTransform.forward;

        // �J��������^�[�Q�b�g�ւ̃x�N�g��
        Vector3 targetDir = targetWorldPos - cameraTransform.position;

        // ���ς��g���ăJ�����O�����ǂ����𔻒�
        bool isFront = Vector3.Dot(cameraDir, targetDir) > 0;

        // �J�����O���Ȃ�UI�\���A����Ȃ��\��
        gameObject.SetActive(isFront);

        return isFront;
    }
}
