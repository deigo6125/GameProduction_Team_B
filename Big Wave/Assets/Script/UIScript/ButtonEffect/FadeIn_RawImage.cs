using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

//�쐬��:���R
//�t�F�[�h�C��(RawImage�Ŏg����)
public class FadeIn_RawImage : MonoBehaviour
{
    [Header("�����S�ɉ�ʂ��t�F�[�h�C������܂łɂ����鎞��")]
    [SerializeField] float fadeDuration = 1.0f;
    [Header("���t�F�[�h�C���Ɏg���摜")]
    [SerializeField] RawImage fadeImage;
    private float fadeTimer = 0f;//�t�F�[�h�C�����Ԃ̊Ǘ��p
    const float _maxAlpha = 1;
    State_Fade _state = State_Fade.off;//�t�F�[�h�A�E�g�̏�

    public State_Fade State { get { return _state; } }

    public void ReturnDefault()//�t�F�[�h���I�������K���Ă΂Ȃ���΂����Ȃ�����(��������Ȃ��Ƃ��̃R���|�[�l���g�̍ė��p���ł��Ȃ�)
    {
        _state = State_Fade.off;
    }

    public void StartTrigger()//�t�F�[�h�A�E�g���ŏ�����J�n���������ɌĂ�
    {
        if (_state == State_Fade.completed) return;//���Ɋ������Ă��鎞�͌ĂׂȂ�

        fadeTimer = 0f;
        _state = State_Fade.fading;
    }

    public void CancelTrigger()//�t�F�[�h�A�E�g���~�߂������ɌĂ�
    {
        if (_state != State_Fade.fading) return;//�t�F�[�h���łȂ���Ζ���

        _state = State_Fade.cancel;
    }

    public void ResumeTrigger()//�t�F�[�h�A�E�g��r������ĊJ���������ɌĂ�
    {
        if (_state != State_Fade.cancel) return;//�L�����Z����ԂłȂ���Ζ���

        _state = State_Fade.fading;
    }

    void Update()
    {
        FadeInDisplay();
    }

    private void FadeInDisplay()//�t�F�[�h�C���̏���
    {
        //�t�F�[�h�A�E�g���łȂ��Ȃ珈�������Ȃ�
        if (_state != State_Fade.fading) return;

        //�o�ߎ��Ԃ����Ƃɓ����x���v�Z
        fadeTimer += Time.deltaTime;
        float normalizedTime = fadeTimer / fadeDuration;
        float newAlpha = _maxAlpha - Mathf.Clamp01(normalizedTime);

        //�t�F�[�h�C���p�̉摜�̓����x���X�V
        Color currentColor = fadeImage.color;
        currentColor.a = newAlpha;
        fadeImage.color = currentColor;

        if (fadeTimer >= fadeDuration)
        {
            //���S�ɉ�ʂ����]�����犮����Ԃ�
            _state = State_Fade.completed;
        }
    }
}
