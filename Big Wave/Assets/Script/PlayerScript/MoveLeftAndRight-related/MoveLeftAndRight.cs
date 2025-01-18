using UnityEngine;

// �쐬��: ���R�A�K�����ꕔ�C��
// ���ړ�(Rigidbody�Ȃ��j

public class MoveLeftAndRight : MonoBehaviour
{
    [Header("�������Ώ�")]
    [SerializeField] Transform target;
    [Header("�ړ��X�s�[�h")]
    [SerializeField] float speed = 11.5f;//�ړ��X�s�[�h
    [Header("�ړ��Ɋ��������邩�ǂ���")]
    [SerializeField] bool isInertiaEnabled;
    [SerializeField] InertialMover inertialMover;

    private Vector3 move;

    private void Update()
    {
        Move();
    }

    void Move()//�v���C���[�̈ړ�
    {
        if (!isInertiaEnabled)
            target.Translate(move * Time.deltaTime * speed);//�����Ȃ��̈ړ�

        else
        {
            inertialMover.InertialMovement(move, target);//��������̈ړ�
        }
    }

    public void GetMoveVector(Vector2 getVec)//�����������󂯎��
    {
        //x�����̓��͂����󂯎��
        move = new Vector3(getVec.x, 0f, 0f);
    }
}
