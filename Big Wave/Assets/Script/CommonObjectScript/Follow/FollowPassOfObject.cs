using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�I�u�W�F�N�g��ǐՂ���(fps�ɍ��E����Ȃ�)
public class FollowPassOfObject : MonoBehaviour
{
    [Header("�ǐՂ���^�[�Q�b�g")]
    [SerializeField] Transform _target;
    [Header("�ǐՂ�����I�u�W�F�N�g")]
    [SerializeField] Transform _followObject;
    //[Header("��ԑ��x")]
    //[Range(0f, 1f)]
    //[SerializeField] float lerpSpeed;  // �⊮���x
    Queue<Vector3> _targetPosQueue=new Queue<Vector3>();//�ǐՂ���^�[�Q�b�g�̈ʒu��ۑ�����L���[
    Queue<Quaternion> _targetRotQueue=new Queue<Quaternion>();//�ǐՂ���^�[�Q�b�g�̉�]��ۑ�����L���[
    JudgePauseNow _judgePauseNow;
    bool _isFollow = false;//�ǐՂ��邩

    public bool IsFollow
    {
        get { return _isFollow; }
        set { _isFollow = value; }
    }

    void Awake()
    {
        _judgePauseNow = GameObject.FindWithTag("PauseManager").GetComponentInChildren<JudgePauseNow>();
    }

    private void FixedUpdate()
    {
        if (_judgePauseNow.PauseNow) return;

        EnQueueTargetPos();

        Follow();
    }

    void EnQueueTargetPos()//�ǐՂ���^�[�Q�b�g�̈ʒu�Ɖ�]���L���[�ɓo�^
    {
        _targetPosQueue.Enqueue(_target.position);
        _targetRotQueue.Enqueue(_target.rotation);
    }

    void Follow()//�ǐՂ�����
    {
        if(!_isFollow) return;

        //�ʒu�Ɖ�]�����o���Ă����ǐՂ�����I�u�W�F�N�g�ɓK�p
        Vector3 targetPos= _targetPosQueue.Dequeue();
        Quaternion targetRot = _targetRotQueue.Dequeue();

        _followObject.position = targetPos;
        _followObject.rotation = targetRot;
    }
}
