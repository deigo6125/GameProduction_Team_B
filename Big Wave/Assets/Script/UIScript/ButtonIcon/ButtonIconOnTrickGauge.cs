using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonIconOnTrickGauge : MonoBehaviour
{
    [Header("�{�^���̃A�C�R��")]
    [Tooltip("�ŏ��ɗ��܂�Q�[�W�̏�ɂ���A�C�R����[0]�ɐݒ�A��Ԗڂɗ��܂�Q�[�W�̏�ɂ���A�C�R����[1]�ɐݒ�...���Ă�������")]
    [SerializeField] ButtonIconDisplay[] buttonIcon;//�{�^���̃A�C�R��
    [SerializeField] TrickPoint trickPoint;
    [SerializeField] Critical critical;

    void Update()
    {
        for(int i=0; i<buttonIcon.Length ;i++)//�ŏ��ɗ��܂�Q�[�W����Ō�ɗ��܂�Q�[�W�܂ŏ��Ɍ��Ă���
        {
            bool display = (i < trickPoint.MaxCount);//�����Ă���Q�[�W�̏�ɂ���{�^���A�C�R����\�����邩

            if(display)
            {
                int criticalButtonNum = trickPoint.MaxCount-1-i;//���ԖڂɎw�肳��Ă���{�^����\�����邩�A�v�f�ԍ������Ȃ���΂Ȃ�Ȃ��̂ŗႦ��2�ԖڂɎw�肳��Ă���{�^����\������Ȃ�(2-1)=1������
                TrickButton buttonDisplayed = critical.CriticalButton[criticalButtonNum];//�\������{�^���AcriticalButtonNum+1�Ԗ�(�v�f�ԍ��ł�����criticalButtonNum)�Ɏw�肳��Ă���{�^����ݒ�
                buttonIcon[i].DisplayButton(buttonDisplayed);//�{�^���A�C�R����\��
            }
            else
            {
                buttonIcon[i].HideButton();//�{�^���A�C�R�����\��
            }
        }
    }
}
