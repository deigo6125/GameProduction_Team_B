using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//�쐬��:���R
//�t�F�[�h�A�E�g����
public class FadeOut : MonoBehaviour
{
    [Header("�����S�ɉ�ʂ��t�F�[�h�A�E�g����܂łɂ����鎞��")]
    [SerializeField] float fadeDuration = 1.0f;
    [Header("���t�F�[�h�A�E�g�Ɏg���摜")]
    [SerializeField] Image fadeImage;
    private float fadeTimer = 0f;//�t�F�[�h�A�E�g���Ԃ̊Ǘ��p
    State_Fade _fadeState = State_Fade.off;//�t�F�[�h�A�E�g�̏�

    public State_Fade FadeState { get { return _fadeState; } }  

    public void ReturnDefault()//�t�F�[�h���I�������K���Ă΂Ȃ���΂����Ȃ�����(��������Ȃ��Ƃ��̃R���|�[�l���g�̍ė��p���ł��Ȃ�)
    {
        _fadeState = State_Fade.off;
    }

    public void StartTrigger()//�t�F�[�h�A�E�g���ŏ�����J�n���������ɌĂ�
    {
        if (_fadeState == State_Fade.completed) return;//���Ɋ������Ă��鎞�͌ĂׂȂ�

        fadeTimer = 0f;
        _fadeState = State_Fade.fading;
    }

    public void CancelTrigger()//�t�F�[�h�A�E�g���~�߂������ɌĂ�
    {
        if (_fadeState != State_Fade.fading) return;//�t�F�[�h���łȂ���Ζ���

        _fadeState = State_Fade.cancel;
    }

    public void ResumeTrigger()//�t�F�[�h�A�E�g��r������ĊJ���������ɌĂ�
    {
        if (_fadeState != State_Fade.cancel) return;//�L�����Z����ԂłȂ���Ζ���

        _fadeState = State_Fade.fading;
    }

    void Update()
    {
        FadeOutDisplay();
    }

    private void FadeOutDisplay()//�t�F�[�h�A�E�g�̏���
    {
        //�t�F�[�h�A�E�g���łȂ��Ȃ珈�������Ȃ�
        if (_fadeState!=State_Fade.fading) return;

        //�o�ߎ��Ԃ����Ƃɓ����x���v�Z
        fadeTimer += Time.deltaTime;
        float normalizedTime = fadeTimer / fadeDuration;
        float newAlpha = Mathf.Clamp01(normalizedTime);

        //�t�F�[�h�A�E�g�p�̉摜�̓����x���X�V
        Color currentColor= fadeImage.color;
        currentColor.a = newAlpha;
        fadeImage.color = currentColor;

        if (fadeTimer >= fadeDuration)
        {
            //���S�ɉ�ʂ��Ó]�����瓮���Ă��Ȃ���Ԃ�
            _fadeState=State_Fade.completed;
        }
    }
}
