using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//�쐬��:���R
//�V�[���̎n�߂ɑO�̉�ʂɖ߂�{�^����o�^����
public class StartOpenMenu : MonoBehaviour
{
    [Header("�Ώۃ{�^��")]
    [SerializeField] Button _targetButton;//�Ώۃ{�^��
    [SerializeField] CloseMenuEasily _closeMenuEasily;

    void Start()
    {
        //����E�O�̉�ʂɖ߂�{�^���ɑΏۃ{�^����o�^
        _closeMenuEasily.OpenNewMenu(_targetButton);
    }
}
