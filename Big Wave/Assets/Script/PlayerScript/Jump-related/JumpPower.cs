using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�W�����v�͂�Ԃ�
public class JumpPower : MonoBehaviour
{
    [Header("�ő�ɂȂ�܂ł̎���")]
    [SerializeField] float _maxTime;//�ő�ɂȂ�܂ł̎���(�b)
    [Header("�W�����v�֌W�̃R���g���[������")]
    [SerializeField] ControllerOfJump _controllerOfJump;//�W�����v�֌W�̃R���g���[������
    [Header("�ő�W�����v��")]
    [SerializeField] float _powerMax;
    [Header("�ŏ��W�����v��")]
    [SerializeField] float _powerMin;
    [Header("�K�v�ȃR���|�[�l���g")]
    [SerializeField] JudgeJumpable _judgeJumpable;
    float _currentPowerRatio;//���݂̃W�����v��(�ő�{���ɑ΂��Ă̊���)
    const float _maxPowerRatio = 1;
    const float _minPowerRatio = 0;
    float _powerRatioLastJump;//�Ō�ɃW�����v�������̃W�����v��(�ő�{���ɑ΂��Ă̊���)

    public float Power//�W�����v��
    {
        get
        {
            float gap=_powerMax - _powerMin;//�ő�W�����v�͂ƍŏ��W�����v�͂̍�
            return _powerMin+gap*_currentPowerRatio;
        }
    }

    public float Ratio { get { return _currentPowerRatio; } }//�W�����v�͂̊���(�ŏ��Ȃ�0�A�ő�Ȃ�1)

    public float PowerLastJump//�Ō�ɃW�����v�������̃W�����v��
    {
        get
        {
            float gap = _powerMax - _powerMin;//�ő�W�����v�͂ƍŏ��W�����v�͂̍�
            return _powerMin + gap * _powerRatioLastJump;
        }
    }

    public float RatioLastJump { get { return _powerRatioLastJump; } }//�Ō�ɃW�����v�������̃W�����v�͂̊���(�ŏ��Ȃ�0�A�ő�Ȃ�1)

    public bool ChargeNow { get { return _judgeJumpable.Jumpable && _controllerOfJump.Pushing; } }//�W�����v�̓`���[�W�����A�W�����v�ł��鎞���R���g���[���̃W�����v�{�^�������������Ă��鎞

    //�W�����v�͂̃��Z�b�g�A�W�����v���o���Ȃ��Ȃ�������ɂ���
    //
    public void ResetJumpPower()
    {
        _currentPowerRatio = _minPowerRatio;
    }

    public void MemorizeJumpPowerLastJump()//�Ō�ɔ�񂾎��̃W�����v�͂��L�^
    {
        _powerRatioLastJump = _currentPowerRatio;
    }

    void Start()
    {
        ResetJumpPower();
        MemorizeJumpPowerLastJump();
        _judgeJumpable.ToNotJumpable += ResetJumpPower;
    }

    void Update()
    {
        Charge();
    }

    void Charge()//�W�����v�͂̃`���[�W
    {
        if (ChargeNow)
        {
            //�W�����v�͂𑝉�������
            float chargeAmount=Time.deltaTime/_maxTime;//������
            _currentPowerRatio += chargeAmount;
            //���E�˔j���Ȃ��悤�ɂ���
            _currentPowerRatio = Mathf.Clamp(_currentPowerRatio, _minPowerRatio, _maxPowerRatio);
        }    
    }
}
