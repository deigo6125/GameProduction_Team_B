using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:�K��(�R���[�`������)
//�ꕔ���R������
//�g���b�N���̃z�o�[�W�����v
public class HoverJump : MonoBehaviour
{
    //[Header("�g���b�N�g�p���̑؋󎞊�")]
    //[SerializeField] float hoverTime = 0.2f;//�g���b�N�g�p���̑؋󎞊�
    [Header("�W�����v�̋���")]
    [SerializeField] float jumpStrength = 5f;//�W�����v�̋���
    [Header("�K�v�ȃR���|�[�l���g")]
    [SerializeField] Rigidbody rb;
    //private Coroutine coroutine;

    public void HoverJumpTrigger()//�z�o�[�W�����v�̔���
    {
        if(rb.velocity.y<=0) rb.velocity = Vector3.zero;//�����Ă��鎞�͈�U�����鑬�x��0�ɂ���

        rb.AddForce(Vector3.up*jumpStrength,ForceMode.Impulse);
        //rb.velocity += accelerationVector*Time.deltaTime;//����
    }

    //IEnumerator HoverJumpCoroutine()//�x��ăz�o�[�W�����v����
    //{
    //    rb.useGravity = false;
    //    rb.velocity = Vector3.zero;//�d�͂ƃW�����v�̉^�����ꎞ�I�Ɏ~�߂�

    //    yield return new WaitForSeconds(hoverTime);

    //    rb.useGravity = true;
    //    rb.velocity = new(0, hoverJumpStrength, 0);
    //}
}
