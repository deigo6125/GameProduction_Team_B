using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//�쐬��:���R
//bool�^���؂�ւ��u�Ԃɓo�^�����C�x���g(���\�b�h)�̏���������
[System.Serializable]
public class MomentEvent 
{
    [Header("�o�^�C�x���g")]
    [SerializeField] UnityEvent events;//�o�^�C�x���g

    //bool�^���؂�ւ�����u�Ԃɓo�^�����C�x���g�𔭓�������
    public void ActivateMomentEvent(bool current,bool before,bool currentBool)//current��currentBool�ƈ�v���Abefore��currentBool�̋t�ƈ�v����΃C�x���g�𔭓�
    {
        if(current==currentBool&&before!=currentBool)
        {
            events.Invoke();
        }
    }
}
