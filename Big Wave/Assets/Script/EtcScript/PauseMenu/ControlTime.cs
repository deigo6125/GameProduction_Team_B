using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlTime : MonoBehaviour
{
    public void ChangeTimeScale(bool stopTime)//�Q�[�����Ԃ̑�����ύX�AstopTime��true�Ȃ玞�Ԃ��~�߂�Afalse�Ȃ玞�Ԃ�1�{���ɖ߂�
    {
        Time.timeScale = stopTime ? 0 : 1;// �Q�[���̎��Ԍo�߂𐧌䂷��
    }
}
