using UnityEngine;

//�쐬�ҁF�K��

[System.Serializable]
public class InertialMover : MonoBehaviour
{
    [Header("�v���C���[����������I�u�W�F�N�g")]
    [SerializeField] Transform pullObject;
    [Header("pullObject��x���W�ֈ����񂹂���͂������邩")]
    [SerializeField] bool isTargetPositionPullEnabled;
    [Header("��������ꂽ�Ƃ��Ƀv���C���[�̊p�x��ω������邩")]
    [SerializeField] bool isTargetRotationPullEnabled;
    [Header("���K�v�ȃR���|�[�l���g")]
    [SerializeField] InertialMoveParameter moveParameter;
    [SerializeField] InertialRotateParameter rotateParameter;

    Vector3 velocity = Vector3.zero;
    float lerpSmoothness = 0.1f;

    public void InertialMovement(Vector3 move, Transform target)//��������̈ړ�
    {
        if (isTargetPositionPullEnabled)
        {
            ApplyTargetPositionPull(target);//���������鋓��

            if (isTargetRotationPullEnabled)
                ApplyRotationBasedOnDistance(target);//����������I�u�W�F�N�g�̊p�x��ς���
        }

        if (move.x == 0 && Mathf.Approximately(velocity.x, 0f))//�ړ��\�͈͂Ŋ����̃��Z�b�g
            velocity.x = 0f;

        if (move.x != 0)
            velocity.x = Mathf.MoveTowards(velocity.x, move.x * moveParameter.TargetSpeed, moveParameter.Acceleration * Time.deltaTime);//����

        else
            velocity.x = Mathf.MoveTowards(velocity.x, 0f, moveParameter.Deceleration * Time.deltaTime); //����

        float nextPosition = target.localPosition.x + velocity.x * Time.deltaTime;//���̈ʒu���v�Z

        //�[�ł̐����Ɣ���
        if (nextPosition > moveParameter.MaxLocalPosition_X)
        {
            nextPosition = moveParameter.MaxLocalPosition_X;//�E�[�ɓ��B

            if (move.x <= 0)
                velocity.x = 0f;
        }

        else if (nextPosition < -moveParameter.MaxLocalPosition_X)
        {            
            nextPosition = -moveParameter.MaxLocalPosition_X;//���[�ɓ��B

            if (move.x >= 0)
                velocity.x = 0f;
        }

        //�ʒu���X�V
        target.localPosition = new Vector3(nextPosition, target.localPosition.y, target.localPosition.z);
    }

    void ApplyTargetPositionPull(Transform target)//�v���C���[��Ώۂ̃I�u�W�F�N�g��x���W�ʒu�Ɉ����񂹂�
    {
        float distanceFromPullPosition = target.localPosition.x - pullObject.localPosition.x;//�v���C���[�ƑΏۃI�u�W�F�N�g�Ƃ�x���W�̍����v�Z

        if (!Mathf.Approximately(distanceFromPullPosition, 0f)) //��������I�u�W�F�N�g�ƈ���������I�u�W�F�N�g��x���W�̍����ق�0�Ȃ�
        {
            float pullForce = Mathf.Clamp(Mathf.Abs(distanceFromPullPosition) * moveParameter.TargetPullStrength, 0f, moveParameter.MaxPullStrength);//��������͂��v�Z

            target.localPosition = Vector3.Lerp(
                target.localPosition,
                new Vector3(target.localPosition.x - Mathf.Sign(distanceFromPullPosition) * pullForce * Time.deltaTime, target.localPosition.y, target.localPosition.z),
                lerpSmoothness);
        }
    }

    void ApplyRotationBasedOnDistance(Transform target)//����������I�u�W�F�N�g�̊p�x��ς���
    {
        float distanceFromPullPosition = target.localPosition.x - pullObject.localPosition.x;//�v���C���[�ƑΏۃI�u�W�F�N�g�Ƃ�x���W�̍����v�Z

        float rotationAmount = Mathf.Clamp(distanceFromPullPosition * rotateParameter.RotationStrength, -rotateParameter.MaxRotationAngle, rotateParameter.MaxRotationAngle);//��]�ʂ̌v�Z�A����

        Quaternion targetRotation = Quaternion.Euler(0f, -rotationAmount, 0f);

        target.localRotation = Quaternion.Slerp(target.localRotation, targetRotation, Time.deltaTime * rotateParameter.RotationReturnSpeed);//�ړI�̉�]�ʂ܂łȂ߂炩�ɉ�]������
    }
    public void SetTargetPositionPull()
    {
        isTargetPositionPullEnabled = true;
    }
}