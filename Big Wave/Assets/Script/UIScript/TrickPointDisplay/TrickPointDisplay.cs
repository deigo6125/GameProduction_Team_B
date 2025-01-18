using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

//�쐬��:���R
public class TrickPointDisplay : MonoBehaviour
{
    [Header("�v���C���[�̃g���b�N�Q�[�W")]
    [Header("���ӓ_:�g���b�N�Q�[�W�̖{��������Ă�������")]
    [SerializeField] Image[] trickGauges;
    [Header("���ʏ��Ԃ̃g���b�N�Q�[�W�̐F")]
    [SerializeField] Color trickGaugeNormalColor;//�ʏ��Ԃ̃g���b�N�Q�[�W�̐F
    [Header("�����^����Ԃ̃g���b�N�Q�[�W�̐F")]
    [SerializeField] Color trickGaugeMaxColor;//���^����Ԃ̃g���b�N�Q�[�W�̐F
    [Header("�v���C���[�̃g���b�N�|�C���g")]
    [SerializeField] TrickPoint player_TrickPoint;
    const float maxRatio = 1;//�g���b�N�Q�[�W���^�����̊���

    // Start is called before the first frame update
    void Start()
    {
        //�G���[�R�[�h
        if (player_TrickPoint.TrickGaugeNum != trickGauges.Length) Debug.Log("�g���b�N�Q�[�W�̖{�����o�^���Ă�������");
    }

    void Update()
    {
        TRICKGaugeOfPlayer();//�v���C���[�̃g���b�N�Q�[�W�̏���
    }

    void TRICKGaugeOfPlayer()//�v���C���[�̃g���b�N�Q�[�W�̏���
    {
        for (int i = 0; i < trickGauges.Length; i++)
        {
            float trickRatio = player_TrickPoint[i] / player_TrickPoint.TrickPointMax;
            trickGauges[i].fillAmount = trickRatio;


            //�Q�[�W�̐F�̕ύX(�Q�[�W1���Ƃɖ��^�����Ƃ���ȊO�̎��ŃQ�[�W�̐F��؂�ւ���)
            trickGauges[i].color = trickRatio == maxRatio ? trickGaugeMaxColor : trickGaugeNormalColor;
        }
    }
}
