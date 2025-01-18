using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FeverPointDisplay : MonoBehaviour
{
    [Header("���v���C���[�̃t�B�[�o�[�Q�[�W")]
    [SerializeField] Image feverGaugeOfPlayer;//�v���C���[�̃t�B�[�o�[�Q�[�W
    [Header("���ʏ��Ԃ̃t�B�[�o�[�Q�[�W�̐F")]
    [SerializeField] Color feverGaugeNormalColor;//�ʏ��Ԃ̃t�B�[�o�[�Q�[�W�̐F
    [Header("���t�B�[�o�[��Ԃ̃t�B�[�o�[�Q�[�W�̐F")]
    [SerializeField] Color feverGaugeFeverModeColor;//�t�B�[�o�[��Ԃ̃t�B�[�o�[�Q�[�W�̐F
    [Header("�v���C���[�̃t�B�[�o�[�|�C���g")]
    [SerializeField] FeverPoint player_FeverPoint;
    [Header("�t�B�[�o�[���[�h�̃R���|�[�l���g")]
    [SerializeField] FeverMode processFeverPoint;
    [SerializeField] GameObject FeverLogo;
    private void Start()
    {
        processFeverPoint.TransitToFeverAction += EnableLogo;
        processFeverPoint.CancelFeverAction += DisableLogo;
    }

    

    void Update()
    {
        FeverGaugeOfPlayer();//�v���C���[�̃t�B�[�o�[�Q�[�W�̏���
    }

    void FeverGaugeOfPlayer()//�v���C���[�̃t�B�[�o�[�Q�[�W�̏���
    {
        float feverRatio = player_FeverPoint.FeverPoint_ / player_FeverPoint.FeverPointMax;
        feverGaugeOfPlayer.fillAmount = feverRatio;
        //�Q�[�W�̐F�̕ύX
        feverGaugeOfPlayer.color = processFeverPoint.FeverNow ? feverGaugeFeverModeColor : feverGaugeNormalColor;
    }
    void EnableLogo()
    {
        FeverLogo.SetActive(true);
    }
    void DisableLogo()
    {
        FeverLogo.SetActive(false);
    }
}
