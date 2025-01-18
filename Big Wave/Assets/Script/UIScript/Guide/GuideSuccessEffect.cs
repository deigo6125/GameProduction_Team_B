using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�g���b�N�������̃K�C�h�̖��̃G�t�F�N�g
public class GuideSuccessEffect : MonoBehaviour
{
    [Header("�K�C�h�̖��̈ʒu")]
    [SerializeField] GetTrickButton<Transform> _guideAnim;

    [Header("�������Ƃ̐�������G�t�F�N�g")]
    [SerializeField] GetTrickButton<GameObject> _guideEffect;

    [Header("�K�v�ȃR���|�[�l���g")]
    [SerializeField] Trick _trick;
    [SerializeField] PushedButton_CurrentTrickPattern _pushedButton;
    [SerializeField] Critical _critical;

    void Awake()
    {
        _trick.TrickAction += GenerateEffect;
    }

    //�N���e�B�J�����̂݁A�����������̃K�C�h�t�߂ɃG�t�F�N�g�𐶐�
    void GenerateEffect()
    {
        if (!_critical.CriticalNow) return;

        TrickButton pushedButton = _pushedButton.PushedButton;//�������{�^���̐F

        Transform geneTrans = _guideAnim.Get(pushedButton);//�����ʒu���(�����e�I�u�W�F�N�g�Ƃ��Đ���)
        GameObject effect = _guideEffect.Get(pushedButton);//��������G�t�F�N�g

        //����
        Instantiate(effect, geneTrans.position, geneTrans.rotation, geneTrans);
    }
}
