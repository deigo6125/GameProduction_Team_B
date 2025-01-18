using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;

//�쐬�ҁF�K��

public class PlayGuideInputModule : MonoBehaviour
{
    [SerializeField] InputSystemUIInputModule inputModule;
    [Header("�����E���͂�Ή�������A�N�V����")]
    [SerializeField] InputActionReference leftRightActionReference;
    [Header("���L�����Z�����͂�Ή�������A�N�V����")]
    [SerializeField] InputActionReference cancelActionReference;
    [Header("�������͎��ɌĂяo������")]
    [SerializeField] UnityEvent leftEvent;
    [Header("���E���͎��ɌĂяo������")]
    [SerializeField] UnityEvent rightEvent;
    [Header("���L�����Z�����͎��ɌĂяo������")]
    [SerializeField] UnityEvent cancelEvent;

    private InputSystemUIInputModule actionHandler;
    private InputAction leftRightAction;
    private InputAction cancelAction;

    private bool isLeftRightInputActive = false;//���E���͂��s���Ă��邩
    private float inputThreshould = 0.2f;

    private void Awake()
    {
        actionHandler = inputModule.GetComponent<InputSystemUIInputModule>();

        leftRightAction = leftRightActionReference.action;
        cancelAction = cancelActionReference.action;

        EnableAllUIActions();//�S���͂�L����
    }

    private void OnEnable()
    {
        leftRightAction.Enable();//���E���͂�L����
        cancelAction.Enable();//�L�����Z�����͂�L����

        leftRightAction.performed += OnleftRightInput;
        cancelAction.performed += OnCancelInput;
    }

    private void OnDisable()
    {
        leftRightAction.Disable();//���E���͂𖳌���
        cancelAction.Disable();//�L�����Z�����͂𖳌���

        leftRightAction.performed -= OnleftRightInput;
        cancelAction.performed -= OnCancelInput;
    }

    public void OnleftRightInput(InputAction.CallbackContext context)//���E���͂̏���
    {
        float xValue = context.ReadValue<Vector2>().x;

        if (Mathf.Abs(xValue) > inputThreshould)
        {
            if (!isLeftRightInputActive)
            {
                isLeftRightInputActive = true;

                if (context.ReadValue<Vector2>().x < 0)
                {
                    leftEvent.Invoke();//�����͎��̏���
                }

                else if (context.ReadValue<Vector2>().x > 0)
                {
                    rightEvent.Invoke();//�E���͎��̏���
                }
            }
        }

        else
        {
            isLeftRightInputActive = false;
        }
    }

    public void OnCancelInput(InputAction.CallbackContext context)//�L�����Z�����͎��̏���
    {
        cancelEvent.Invoke();
    }

    public void EnableAllUIActions()//�S�Ă̓��͂�L����
    {
        actionHandler.point.action.Enable();
        actionHandler.move.action.Enable();
        actionHandler.submit.action.Enable();
        actionHandler.cancel.action.Enable();
    }

    public void DisableAllUIActions()//�S�Ă̓��͂𖳌���
    {
        actionHandler.point.action.Disable();
        actionHandler.move.action.Disable();
        actionHandler.submit.action.Disable();
        actionHandler.cancel.action.Disable();
    }

    public void EnableSpecificUIActions()//�ꕔ���͂�L����
    {
        leftRightAction.Enable();
        cancelAction.Enable();
    }

    public void DisableSpecificUIActions()//�ꕔ���͂𖳌���
    {
        leftRightAction.Disable();
        cancelAction.Disable();
    }
}
