using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬�ҁ�:�K��

public class BuffStockDisplay : MonoBehaviour
{
    //[Header("���o�t�̃X�g�b�N����\���Q�[�W�̍�������")]
    //[SerializeField] GameObject outOfBuffStockGaugeOfPlayer;//�o�t�̃X�g�b�N����\���Q�[�W�̍�������
    //[Header("���o�t�̃X�g�b�N����\���Q�[�W")]
    [SerializeField] GameObject buffStockGaugeOfPlayer;//�o�t�̃X�g�b�N����\���Q�[�W
    [Header("���������ꂽ�o�t�X�g�b�N�Q�[�W���ǂꂭ�炢������")]
    [SerializeField] float buffStockGaugeInterval;//�������ꂽ�o�t�X�g�b�N�Q�[�W���ǂꂭ�炢������
    [Header("�����^����Ԃ̃g���b�N�Q�[�W�̐F")]
    [SerializeField] Color buffStockedGaugeColor;//�X�g�b�N��Ԃ̃o�t�X�g�b�N�Q�[�W�̐F
    // private GameObject[] buffStockGauges;//�v���C���[�̃o�t�X�g�b�N�Q�[�W(���������p)

    // Start is called before the first frame update
    void Start()
    {

        // buffOfPlayer = GameObject.FindWithTag("Player").GetComponent<BuffOfPlayer>();
        //�o�t�X�g�b�N�Q�[�W�̐���(�Q�[�W����)
        //GenerateBuffStockGauge();
        ////�o�t�X�g�b�N�Q�[�W�̈ʒu����    
        //PositioningBuffStockGauge();
    }

    // Update is called once per frame
    void Update()
    {
        /* BuffStockGaugeOfPlayer();*///�v���C���[�̃o�t�X�g�b�N�Q�[�W�̏���
    }

    //�v���C���[�̃o�t�X�g�b�N�֌W�̃��\�b�h
    //void GenerateBuffStockGauge()
    //{
    //    buffStockGauges = new GameObject[buffOfPlayer.TrickBoost.BuffStockMax];

    //    for (int i = 0; i < buffStockGauges.Length; i++)
    //    {
    //        buffStockGauges[i] = Instantiate(buffStockGaugeOfPlayer,
    //            outOfBuffStockGaugeOfPlayer.transform);
    //    }
    //}

    //void PositioningBuffStockGauge()//�o�t�X�g�b�N�Q�[�W�̈ʒu����
    //{
    //    //���������̃o�t�X�g�b�N�Q�[�W��(����)�傫�����擾
    //    Vector2 sd_OutOfBuffStockGauge = outOfBuffStockGaugeOfPlayer.GetComponent<RectTransform>().sizeDelta;
    //    //��������Ă���o�t�X�g�b�N�Q�[�W�̑傫�������߂�(�S�ē����傫��)
    //    Vector2 sd_BuffStockGauge = buffStockGauges[0].GetComponent<RectTransform>().sizeDelta;
    //    sd_BuffStockGauge.x = (sd_OutOfBuffStockGauge.x - (buffStockGauges.Length - 1) * buffStockGaugeInterval) / buffStockGauges.Length;
    //    sd_BuffStockGauge.y = sd_OutOfBuffStockGauge.y;

    //    //��������Ă���o�t�X�g�b�N�Q�[�W�̑傫���ƈʒu��ύX
    //    for (int i = 0; i < buffStockGauges.Length; i++)
    //    {
    //        //�傫����ύX
    //        buffStockGauges[i].GetComponent<RectTransform>().sizeDelta = sd_BuffStockGauge;
    //        //�ʒu��ύX
    //        Vector3 pos_BuffStockGauge;
    //        pos_BuffStockGauge = buffStockGauges[i].GetComponent<RectTransform>().anchoredPosition3D;

    //        //��ڂ̃Q�[�W�͍��[�̂ǂ��ɒu���������߂�
    //        if (i == 0)
    //        {
    //            pos_BuffStockGauge.x = -sd_OutOfBuffStockGauge.x / 2 + sd_BuffStockGauge.x / 2;
    //        }
    //        //����ȍ~�̃Q�[�W�͑O�ɒu�����Q�[�W�ƈ��Ԋu�Œu��
    //        else
    //        {
    //            Vector3 pos_BeforeBuffStockGauge = buffStockGauges[i - 1].GetComponent<RectTransform>().anchoredPosition3D;
    //            pos_BuffStockGauge.x = pos_BeforeBuffStockGauge.x + sd_BuffStockGauge.x + buffStockGaugeInterval;
    //        }

    //        pos_BuffStockGauge.y = 0;
    //        buffStockGauges[i].GetComponent<RectTransform>().anchoredPosition3D = pos_BuffStockGauge;
    //    }
    //}

    //void BuffStockGaugeOfPlayer()//�v���C���[�̃o�t�X�g�b�N�Q�[�W�̏���
    //{
    //    int buffStockCount = buffOfPlayer.TrickBoost.BuffStockCount;

    //    for (int i = 0; i < buffStockGauges.Length; i++)
    //    {
    //        if (i < buffStockCount)
    //        {
    //            buffStockGauges[i].GetComponent<Image>().color = buffStockedGaugeColor;
    //        }

    //        else
    //        {
    //            buffStockGauges[i].GetComponent<Image>().color = Color.clear;
    //        }
    //    }
    //}
}
