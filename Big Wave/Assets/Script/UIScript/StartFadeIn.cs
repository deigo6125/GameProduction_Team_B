using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//�쐬��:���R
//��ʑJ�ڒ���ɏ����҂��Ă���t�F�[�h�C������
public class StartFadeIn : MonoBehaviour
{
    [SerializeField] FadeIn _fadeIn;
    [Header("�t�F�[�h�C����҂���")]
    [SerializeField] float _fadeWaitTime;
    [Header("�t�F�[�h�C���Ɏg���摜")]
    [SerializeField] Image _fadeInImage;
    private void Start()
    {
        //�t�F�[�h�C���Ɏg���摜��\��
        _fadeInImage.enabled = true;

        StartCoroutine(WaitFadeIn());
    }

    IEnumerator WaitFadeIn()
    {
        //���b�҂��Ă���t�F�[�h�C�����J�n����
        yield return new WaitForSeconds(_fadeWaitTime);

        _fadeIn.StartTrigger();
    }
}
