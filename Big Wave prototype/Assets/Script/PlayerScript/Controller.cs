using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Controller : MonoBehaviour
{
    [SerializeField] float chargeTrick_VibrationSpeed=0.35f;//�g���b�N�`���[�W���̃o�C�u�̑���
    MoveControl moveControl;
    JumpControl jumpControl;
    ChargeTrickControl chargeTrickControl;
    AttackControl attackControl;
    private Gamepad gamepad = Gamepad.current;
    // Start is called before the first frame update
    void Start()
    {
        moveControl = gameObject.GetComponent<MoveControl>();
        jumpControl = gameObject.GetComponent<JumpControl>();
        chargeTrickControl = gameObject.GetComponent<ChargeTrickControl>();
        attackControl= gameObject.GetComponent<AttackControl>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();//�v���C���[�̓���

        Jump();//�W�����v

        Attack();//�U��
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("InsideWave") || other.CompareTag("OutsideWave"))
        {
            ChargeTrick(other);//�g�ɐG��Ă���ԏ���ăg���b�N���`���[�W
        }
    }

    //�ړ��֘A
    void Move()//�v���C���[�̓���
    {
        //���E�L�[���E�X�e�B�b�N(���E�ɓ�����)�ŃL���������E�ɓ���
        moveControl.Move();
    }

    //�W�����v�֘A
    void Jump()//�W�����v
    {
        //�X�y�[�X�L�[��LB�{�^����RB�{�^���ŃW�����v
        if (Input.GetKeyUp(KeyCode.JoystickButton5) || Input.GetKeyUp(KeyCode.JoystickButton4) || Input.GetKeyUp("space"))
        {
            jumpControl.Jump();
        }
    }


    //�U���֘A
    void Attack()//�U��
    {
        if(Input.GetButtonDown("Fire1") || Input.GetKeyDown("j"))//J�L�[��X�{�^���������������U��
        {
            attackControl.Attack_Strong();
        }

        if(Input.GetButtonDown("Fire2") || Input.GetKeyDown("k"))//K�L�[��B�{�^���������������U��
        {
            attackControl.Attack_Medium();
        }

        if(Input.GetButtonDown("Fire3") || Input.GetKeyDown("l"))//L�L�[��A�{�^��������������U��
        {
            attackControl.Attack_Weak();
        }
    }

    void VibrateController_Attack()//�U�����R���g���[���[���o�C�u����
    {

    }


    //�g���b�N�̃`���[�W�֘A
    void ChargeTrick(Collider wavePrefab)//�g�ɏ���ăg���b�N���`���[�W
    {
        //�X�y�[�X�L�[��{�^���������Ă���ԃ`���[�W
        if (Input.GetKey(KeyCode.JoystickButton5) || Input.GetKey(KeyCode.JoystickButton4) || Input.GetKey("space"))
        {
            chargeTrickControl.ChargeTrick(wavePrefab);
        }

        VibrateController_Charge();//�`���[�W���Ă���ԃR���g���[���[���o�C�u����
    }

    void VibrateController_Charge()//�`���[�W���Ă���ԃR���g���[���[���o�C�u����
    {
        if(chargeTrickControl.chargeNow)
        {
            if (gamepad != null)//�Q�[���p�b�h���ڑ�����Ă���ΐU���𔭐�������(��̈����͂��ꂼ�ꍶ�E�̃��[�^�[�̐U���̋���)
            {
                gamepad.SetMotorSpeeds(chargeTrick_VibrationSpeed, chargeTrick_VibrationSpeed);
            }
        }
        else
        {
            StopVibration();
        }
    }

    //�o�C�u���~�߂�
    void StopVibration()
    {
        if (gamepad != null)
        {
            gamepad.SetMotorSpeeds(0f, 0f);
        }
    }
}