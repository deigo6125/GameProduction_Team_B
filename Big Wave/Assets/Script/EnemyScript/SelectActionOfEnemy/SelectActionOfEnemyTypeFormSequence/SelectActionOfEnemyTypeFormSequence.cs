using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�`�Ԃ��ƂɃ����_���ōs���p�^�[��(�R���{�݂����Ȋ����ň�A�̓����ݒ�ł���)��I��(�`�Ԃ��Ƃɍŏ��ɂ���s�����ݒ�\)
public class SelectActionOfEnemyTypeFormSequence : SelectActionOfEnemyTypeBase
{
    [Header("�`�Ԃ��Ƃ̍s���p�^�[��")]
    [SerializeField] SequenceOfActionPatternPerForm[] _forms;//�`�Ԃ��Ƃ̍s���p�^�[��
    [Header("�����݂̌`�Ԃ�Ԃ��R���|�[�l���g")]
    [SerializeField] FormOfEnemyTypeBase _formOfEnemy;//���݂̌`�Ԃ�Ԃ��R���|�[�l���g
    bool _actedFirst = false;//�ŏ��̍s����������
    int _beforeFormNum;//�O(�ɌĂ΂ꂽ��)�̌`�Ԕԍ�
    const int _defaultActionIndex = 0;//�s�����e�̍ŏ��̍s���ԍ�(��ŃR�����g��������)
    int _actionIndex = _defaultActionIndex;//�s�����e�̍s���ԍ�(��ŃR�����g��������)
    SequenceOfActionPattern _currentAction=null;//���݂̍s�����e

    void Start()
    {
        _beforeFormNum = _formOfEnemy.DefaultForm();//�O(�ɌĂ΂ꂽ��)�̌`�Ԕԍ��̏����l���ŏ��̌`�Ԕԍ��ɐݒ�

        //�S�Ă̌`�Ԃ̍s���m���̍��v���Z�o
        for (int i = 0; i < _forms.Length; i++)
        {
            _forms[i].CalcSum();
        }
    }

    public override ActionPattern SelectAction()//���ɂ��s����Ԃ�
    {
        //�Z�`�Ԃ��m�F
        int currentFormNum=_formOfEnemy.CurrentForm();//���݂̌`�Ԕԍ�

        //���݂̌`�Ԕԍ����ݒ肳��ĂȂ����̂ł���Όx�����b�Z�[�W���o���Ă���
        if(currentFormNum>=_forms.Length)
        {
            Debug.Log("���݂̌`�Ԕԍ��̍s���͐ݒ肳��Ă���܂���I");
        }

        //�`�Ԃ��ς���Ă�����
        //�ŏ��̍s����������������Z�b�g(���ĂȂ���Ԃɖ߂�)�A���݂̍s�����e����ɂ���A�s���ԍ������Z�b�g
        if(currentFormNum!=_beforeFormNum)
        {
            _actedFirst = false;
            _actionIndex = _defaultActionIndex;
            _currentAction = null;
        }

        //�O�ɌĂ΂ꂽ���̌`�Ԕԍ��Ɍ��݂̌`�Ԕԍ����L�^
        _beforeFormNum=currentFormNum;


        //�Z�ŏ��̍s�����m�F

        //�܂��ŏ��̍s�����s���Ă��Ȃ�������
        if(!_actedFirst)
        {
            _actedFirst=true;

            //�ŏ��̍s��������ݒ�ɂȂ��Ă����猻�݂̍s�����e���ŏ��̍s�����e�ɐݒ�
            if(_forms[currentFormNum].ActFirst)
            {
                _currentAction = _forms[currentFormNum].FirstAction;
            }
        }


        //�Z��A�̍s���������Ă��邩���m�F

        //���݂̍s�����e����ɂȂ��Ă�����
        //or ���݂̍s���ԍ����͈͊O�̂��̂�������...
        //���݂̍s���𒊑I�A�s���ԍ������Z�b�g
        if (_currentAction==null || _currentAction.ActionNum <= _actionIndex)
        {
            _currentAction = _forms[currentFormNum].SelectAfterAction();
            _actionIndex = _defaultActionIndex;
        }

        //���݂̍s���ԍ��̍s����Ԃ�
        int currentActionIndex = _actionIndex;//���݂̍s���ԍ�
        _actionIndex++;//�s�����e�̎��̍s���ɐݒ�
        return _currentAction[currentActionIndex];
    }
}
