using System.Collections.Generic;
using UnityEngine;

public class PathFollower_a : MonoBehaviour
{
    [Header("��s����I�u�W�F�N�g")]
    [SerializeField] Transform leadingObject;  //��s����I�u�W�F�N�g
    private int waitCount;
    private float startPoint;//��s����I�u�W�F�N�g�̃Q�[���J�n���̈ʒu(������ʉ߂����t���[������Ǐ]���n�߂�)
    private Queue<Vector3> pathPoints_P = new Queue<Vector3>();  // �ʒu��ۑ�����L���[
    private Queue<Quaternion> pathPoints_R = new Queue<Quaternion>();  // ��]��ۑ�����L���[
    [Header("�L���[�̍쐬�����t���[���x�������邩")]
    [SerializeField] int waitTime;
    [Header("��ԑ��x")]
    [SerializeField] float lerpSpeed = 5f;  // Lerp�̑��x
    JudgePauseNow judgePauseNow;

    void Awake()
    {
        startPoint = leadingObject.position.z;
        judgePauseNow=GameObject.FindWithTag("PauseManager").GetComponentInChildren<JudgePauseNow>();
    }

    void Update()
    {
        if (judgePauseNow.PauseNow) return;

        if (waitCount >= waitTime)
        {
            pathPoints_P.Enqueue(leadingObject.position);  // ��s����I�u�W�F�N�g�̈ʒu�Ɖ�]��ێ�
            pathPoints_R.Enqueue(leadingObject.rotation);
        }
        waitCount++;

        // �Q�[���J�n���̐�s�I�u�W�F�N�g�̈ʒu�ɓ��B������Ǐ]���J�n
        if (transform.position.z >= startPoint && pathPoints_P.Count > 0)
        {
            // �L���[�̍ł��Â��ʒu�Ɖ�]���擾���ăt�H�����[��Ǐ]������
            Vector3 target_P = pathPoints_P.Dequeue();  // �ʒu�Ɖ�]�𔽉f��������L���[�������
            Quaternion target_R = pathPoints_R.Dequeue();

            // Lerp���g�p���ăX���[�Y�Ɉړ�
            transform.position = Vector3.Lerp(transform.position, target_P, lerpSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, target_R, lerpSpeed * Time.deltaTime);
        }
    }
}
