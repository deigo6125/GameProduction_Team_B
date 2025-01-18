using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//�쐬��:���R
//���������炩�ɂ���(Vector3��ԋp)
[System.Serializable]
public class SmoothMovement
{
    [Header("�o�b�t�@�[��")]
    [Tooltip("��������ƒx�����������₷���Ȃ�܂�")]
    [SerializeField] int _bufferNum;//"�o�b�t�@�[���A��������ƒx�����������₷���Ȃ�܂�
    private Queue<Vector3> _posBuffer; // �o�b�t�@��Queue�ŊǗ�
    Vector3 sum = new Vector3();//���v

    public SmoothMovement(int bufferNum)//�R���X�g���N�^
    {
        _bufferNum = bufferNum;

        SecureBuffer();
    }

    //�o�b�t�@�[�m��(�R���X�g���N�^��p�����Ɏg���ꍇ�͍ŏ��ɂ�����Ă�)
    public void SecureBuffer()
    {
        _posBuffer = new Queue<Vector3>(_bufferNum);
    }

    public Vector3 Smooth(Vector3 nowPos)
    {
        // �o�b�t�@�Ɍ��݂̒l��ǉ�&���v�Ɍ��݂̒l�����Z
        _posBuffer.Enqueue(nowPos);
        sum += nowPos;

        // �o�b�t�@�̃T�C�Y���w�肵���o�b�t�@�[���𒴂����ꍇ�A�Â��l���폜&���v���炻�̒l������
        if (_posBuffer.Count > _bufferNum)
        {
            sum-=_posBuffer.Dequeue();
        }

        //�o�b�t�@�[�Ɋi�[����Ă���S�Ă̒l�̕��ς��Ƃ�
        //���݃o�b�t�@�[�Ɋi�[����Ă���l�̌����A�o�b�t�@�[���ɖ����Ȃ��ꍇ�͌��݊i�[����Ă���l�̌����畽�ς��Ƃ�
        Vector3 ret = sum / _posBuffer.Count;

        //����ꂽ�l��Ԃ�
        return ret;
    }
}
