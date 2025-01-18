using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class AnimatorController_Enemy : MonoBehaviour
{
    [SerializeField] Animator anim;

    public void AnimControl_Trigger(string animName)//trigger�^�C�v�̃A�j���[�V�����ύX
    {
        if(!(animName==""))
        {
            anim?.SetTrigger(animName);
        }
    }

    public void AnimControl_Bool(string animName,bool animBool)//bool�^�C�v�̃A�j���[�V�����ύX
    {
        if (!(animName == ""))
        {
            anim?.SetBool(animName, animBool);
        }
    }
}
