using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
public class TrickSoundEffect : MonoBehaviour
{
    [Header("�N���e�B�J�����̌��ʉ�")]
    [SerializeField] AudioClip criticalSE;//�N���e�B�J�����̌��ʉ�
    [Header("�ʏ��Ԃ̌��ʉ�")]
    [SerializeField] AudioClip normalSE;//�ʏ��Ԃ̌��ʉ�
    [Header("�g���b�N���A���Ő������閈�ɖ炷���ʉ�")]
    [SerializeField] AudioClip[] trickSE;
    [Header("�ő�s�b�`")]
    [SerializeField] float pitchMax;
    [Header("�㏸�s�b�`��")]
    [SerializeField] float pitchUp;
    [SerializeField] UnityEvent trickEvent_F;
    [SerializeField] UnityEvent trickEvent_N;
    [SerializeField] UnityEvent trickEvent_Fever;
    [Header("�K�v�ȃR���|�[�l���g")]
    [SerializeField] AudioSource audioSource;
    [SerializeField]AudioSource audioSource2;
    [SerializeField] Critical critical;
    [SerializeField]FeverMode feverMode;
    [SerializeField] CountTrickWhileJump count;
    private float startPitch;
    private int trickCount;
    private void Start()
    {
       startPitch= audioSource.pitch;
    }
    public void PlayTrickSE()//�N���e�B�J���󋵂ɂ���Ė炷����ς���
    {
        AudioClip se=critical.CriticalNow ? criticalSE: normalSE;
        if (critical.CriticalNow&&audioSource.pitch<pitchMax)
        {
            audioSource.pitch += pitchUp;
        }
        else if(!critical.CriticalNow)
        {
          audioSource.pitch =startPitch ;
        }
        audioSource.PlayOneShot(se);
        trickCount = count.TrickCount - 1;
        if (trickCount < 0)//�z��̊O���Q�Ƃ��Ȃ��悤�ɂ���
        {
            trickCount= 0;
        }
        else if(trickCount > 5)
        {
            trickCount= 5;
        }
        audioSource2.PlayOneShot(trickSE[trickCount]);//�A���Ő��������񐔂ɂ���Ė炷����ς���
    }
    public void PlayTrickEffect()//�g���b�N�̐��ۂ��Ԃɍ��킹�ĕ\��������G�t�F�N�g��ς���
    {
        if(critical.CriticalNow)
        {
            if (feverMode.FeverNow)
            {
                trickEvent_Fever.Invoke();
            }
            else
            {
                trickEvent_N.Invoke();
            }

        }
        else
        {
            trickEvent_F.Invoke();
        }
    }
}
