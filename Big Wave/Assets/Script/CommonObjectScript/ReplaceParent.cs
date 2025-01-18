using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�X�^�[�g���Ă��班�����Ԃ�������e�I�u�W�F�N�g��ς���
//���[�v�̃o�O�C���Ɏg���Ă܂�
public class ReplaceParent : MonoBehaviour
{
    [SerializeField] float time;
    [SerializeField] Transform parentObject;
    float currentTime = 0;
    bool done=false;

    void Update()
    {
       UpdateTime();
    }

    void UpdateTime()
    {
        currentTime += Time.deltaTime;

        if(currentTime>=time&&!done) Replace();
    }

    void Replace()
    {
        transform.parent = parentObject;
        done = true;
    }
}
