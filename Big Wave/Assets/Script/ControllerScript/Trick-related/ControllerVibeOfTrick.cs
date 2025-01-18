using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//�쐬��:���R
//�g���b�N�̑��쎞�̃o�C�u
public class ControllerVibeOfTrick : MonoBehaviour
{
    [Header("�g���b�N�����߂����̃o�C�u�̑���")]
    [Range(0, 1)]
    [SerializeField] float vibrationSpeed = 1f;//�g���b�N�����߂����̃o�C�u�̑���
    [Header("�g���b�N�����߂����̐U���̎���")]
    [SerializeField] float vibeTime = 0.2f;//�g���b�N�����߂����̐U���̎���
    private float remainingVibeTime = 0f;//�g���b�N�̐U���̎c�莞��(�����p)
    JudgePauseNow judgePauseNow;
    private Gamepad gamepad = Gamepad.current;

    // Start is called before the first frame update
    void Start()
    {
        judgePauseNow = GameObject.FindWithTag("PauseManager").GetComponentInChildren<JudgePauseNow>();
    }

    // Update is called once per frame
    void Update()
    {
        VibrateController();
    }

    void VibrateController()//�g���b�N���R���g���[���[���o�C�u����
    {
        remainingVibeTime -= Time.deltaTime;

        if (gamepad != null)
        {
            if (remainingVibeTime > 0&&!judgePauseNow.PauseNow)
            {
                gamepad.SetMotorSpeeds(vibrationSpeed, vibrationSpeed);//�o�C�u������
            }
            else
            {
                gamepad.SetMotorSpeeds(0f, 0f);//�o�C�u���~�߂�
            }
        }
    }

    public void Vibe()//�g���b�N���Ƀo�C�u���Ăق����Ƃ�������Ă�
    {
        remainingVibeTime = vibeTime;
    }
}
