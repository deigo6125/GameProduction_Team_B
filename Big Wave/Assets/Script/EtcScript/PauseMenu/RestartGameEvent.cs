using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

//�쐬��:���R
//�Q�[�������X�^�[�g���鎞�ɌĂԏ���
public class RestartGameEvent : MonoBehaviour
{
    const float _defaultGameSpeed = 1;//���{�̃Q�[���̑��x
    public void Restart()//�Q�[�����X�^�[�g���̏���
    {
        Time.timeScale = _defaultGameSpeed;//���Ԃ����Ƃ̑��x�ɂ���
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);//���̃V�[���������̏�Ԃɂ���
    }
}
