using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

//�쐬��:���R
//�Q�[�������X�^�[�g���鎞�ɌĂԏ���
public class QuitGameEvent : MonoBehaviour
{
    [Header("�V�[���ڍs�R���|�[�l���g")]
    [SerializeField] SceneController _sceneController;
    const float _defaultGameSpeed = 1;//���{�̃Q�[���̑��x

    public void Quit()//�Q�[�����f���̏���
    {
        Time.timeScale = _defaultGameSpeed;//���Ԃ����Ƃ̑��x�ɂ���
        _sceneController.StageSelectScene();//�X�e�[�W�Z���N�g�V�[���Ɉڍs
    }
}
