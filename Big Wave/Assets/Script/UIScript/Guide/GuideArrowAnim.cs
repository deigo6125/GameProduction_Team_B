using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�K�C�h�̖��̃A�j���[�V�����̓���
public class GuideArrowAnim : MonoBehaviour
{
    [Header("�A�j���[�V�����̐��������bool��")]
    [SerializeField] string _successBoolName;
    [Header("�A�j���[�V�����̎��s��trigger��")]
    [SerializeField] string _failTriggerName;

    [Header("�K�C�h�̖��")]
    [SerializeField] GetTrickButton<Animator> _guideAnim;

    [Header("�K�v�ȃR���|�[�l���g")]
    [SerializeField] Trick _trick;
    [SerializeField] Critical _critical;

    const int currentCriticalButtonIndex = 0;//���݂̃N���e�B�J���̃{�^���������v�f�ԍ�

    void Awake()
    {
        _trick.TrickAction += RunAnim;
    }

    void RunAnim()
    {
        bool criticalNow = _critical.CriticalNow;//�N���e�B�J����������
        TrickButton currentButton = _critical.CriticalButton[currentCriticalButtonIndex];//���݂�(�N���e�B�J����)�{�^��
        Animator guideAnimator = _guideAnim.Get(currentButton);

        //�N���e�B�J�����s�̎��̂�trigger���o��
        guideAnimator.SetBool(_successBoolName,criticalNow);
        if (!criticalNow) guideAnimator.SetTrigger(_failTriggerName);
    }
}
