using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�v���C���[�ɓ����������̏���
public class AttackOfBullet : MonoBehaviour
{
    [Header("�e�j��ݒ�")]
    [SerializeField] DestroyBullet destroyBullet;//�e�j��ݒ�
    [Header("���ʉ��ݒ�")]
    [SerializeField] PlayHitAudio playHitAudio;//���ʉ��ݒ�
    [Header("�_���[�W�ݒ�")]
    [SerializeField] DamageToPlayer damageToPlayer;//�_���[�W�ݒ�
    [Header("�v���C���[��e���̃_���[�W���[�V�����̐ݒ�")]
    [SerializeField] HitAnim_Player hitAnim_Player;//�v���C���[��e���̃_���[�W���[�V�����̐ݒ�
    [Header("�ڐG����̃R���|�[�l���g")]
    [SerializeField] OnTriggerActionEvent onTriggerEvent;//�ڐG����̃R���|�[�l���g
    [Header("��e���ɔ���������G�t�F�N�g")]
    [SerializeField] GameObject damageEffect;
    [Header("�_���[�W�񐔂��J�E���g����R���|�[�l���g")]
    private ScoreGameScene_HP scoreGameScene_HP;
    bool hit = false;//����������

    void Start()
    {
        onTriggerEvent.EnterAction += HitTrigger;//�����������̏�����o�^
    }

    public void HitTrigger(Collider t)//�����������̏���
    {
        if (t.gameObject.CompareTag("Player")&&!hit)
        {
            hit = true;

            scoreGameScene_HP = GameObject.FindWithTag("ScoreManager_HP").GetComponent<ScoreGameScene_HP>();
            scoreGameScene_HP.DamageCount++;//�_���[�W���󂯂��񐔂𑝂₷

            damageToPlayer.Damage(t);//�v���C���[�Ƀ_���[�W��^����

            hitAnim_Player.DamageMotionTrigger(t);//�v���C���[�ɔ�e���[�V������������

            playHitAudio.Play();//���ʉ��𗬂�
            
            destroyBullet.Destroy();//�e��j�󂷂�

            Instantiate(damageEffect,t.transform.position,t.transform.rotation, t.transform);
        }
    }
}
