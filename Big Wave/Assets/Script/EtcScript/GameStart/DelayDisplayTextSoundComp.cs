using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

//�쐬��:���R
//�x�����ĉ��ƕ������o���R���|�[�l���g
public class DelayDisplayTextSoundComp : MonoBehaviour
{
    [Header("���ʉ��̐ݒ�")]
    [SerializeField] DelayPlaySound[] _sound;
    [Header("�����̐ݒ�")]
    [SerializeField] DelayDisplayText[] _text;
    bool displayStart = false;//

    void Update()
    {
        UpdateDisplay();
    }

    public void DisplayTrigger()//�Q�[���J�n�����u�ԂɈ�x�����Ă΂�鏈��
    {
        displayStart = true;//�t���O��ON�ɂ���
    }

    void UpdateDisplay()//�Q�[�����J�n���Ă��炵�΂炭�Q�[���X�^�[�g�̕�������ʂɕ\������
    {
        if (!displayStart) return;//�X�^�[�g�̕�����\�����Ȃ��Ԃ͖���

        for(int i=0;i<_sound.Length;i++)
        {
            _sound[i].Update();
        }

        for(int i=0;i<_text.Length;i++)
        {
            _text[i].Update();
        }
        
    }
}
