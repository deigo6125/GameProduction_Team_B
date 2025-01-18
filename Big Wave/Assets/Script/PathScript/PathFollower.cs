using System.Collections.Generic;
using UnityEngine;

public class PathFollower: MonoBehaviour
{
    public Transform leadingObject; // ��s�I�u�W�F�N�g�i���j
    public float waitTime;
    private float countTime;
    // �I�u�W�F�N�g�̈ʒu�iX���j��Y���̉�]��ۑ�����L���[
    private Queue<Vector3> pathPoints_P = new Queue<Vector3>();
    private Queue<Quaternion> pathPoints_R= new Queue<Quaternion>();
    private void Awake()
    {
        Application.targetFrameRate = 60;
    }
    void Update()
    {
        // ��s�I�u�W�F�N�g��X���̈ʒu��Y���̉�]���L���[�ɕۑ�
        pathPoints_P.Enqueue(leadingObject.position);
        pathPoints_R.Enqueue(leadingObject.rotation);
        countTime += Time.deltaTime;

        if (pathPoints_R.Count > 0)
        {
            // �L���[�̍ł��Â��ʒu�Ɖ�]���擾
           

            if (waitTime<=countTime) {

               
                // �㑱�I�u�W�F�N�g�̐V�����ʒu�Ɖ�]��ݒ�
               Vector3 target_P = pathPoints_P.Dequeue();
               Quaternion target_R = pathPoints_R.Dequeue();
                transform.position = target_P;
                transform.rotation = target_R;
             
            }
           
        }
    }
}
