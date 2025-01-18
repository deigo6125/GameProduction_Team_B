using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//��ʏ�ɃK�C�h�{�^���A�C�R����\������
public partial class GuideButtonIconFullScreen : MonoBehaviour
{
    [Header("�{�^���\���ݒ�")]
    [SerializeField] ButtonDisplays[] buttonDisplays;
    [Header("�\���̒x������")]
    [SerializeField] float delay;//�\���̒x������
    [SerializeField] JudgeJumpNow judgeJumpNow;
    [SerializeField] TrickPoint player_TrickPoint;
    [SerializeField] Critical critical;
    private float elapsedTime = 0f;//�o�ߎ���(�x�����ԂƔ�r)

    void Update()
    {
        UpdateElapsedTime();
        DisplayAndHideButton();
    }

    void DisplayAndHideButton()//�{�^���\���E��\��
    {
        for (int i = 0; i < buttonDisplays.Length; i++)
        {
            //�W�����v���Ă��鎞���A���^���̃g���b�N�Q�[�W�̐����\���������{�^���̗v�f�ԍ���葽������Ƃ����A�w�莞�Ԓx���������\��
            bool display = (judgeJumpNow.JumpNow() && player_TrickPoint.MaxCount > buttonDisplays[i].buttonNum && elapsedTime > delay * i);

            if (display)//�\�����鎞
            {
                buttonDisplays[i].criticalButtonDisplay.DisplayButton(critical.CriticalButton[buttonDisplays[i].buttonNum]);
            }
            else//��\�����鎞
            {
                buttonDisplays[i].criticalButtonDisplay.HideButton();
            }
        }
    }

    void UpdateElapsedTime()
    {
        if(!judgeJumpNow.JumpNow())//�W�����v���Ă��Ȃ�������0�b�ɂ���
        {
            elapsedTime = 0;
            return;
        }

        elapsedTime += Time.deltaTime;
    }
}
