using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;

//�쐬�ҁF�K��

public partial class PlayGuideInputHandler : MonoBehaviour
{
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
    [SerializeField] InputSystemUIInputModule inputModule;

    private InputSystemUIInputModule actionHandler;
    private InputAction leftRightAction;
    private InputAction cancelAction;
    private float inputThreshould = 0.2f;
    private bool isHolding = false;

    private void Awake()
    {
        if (leftRightActionReference != null)
            leftRightAction = leftRightActionReference.action;

        if (cancelActionReference != null)
            cancelAction = cancelActionReference.action;

        actionHandler = inputModule.GetComponent<InputSystemUIInputModule>();
    }

    private void OnEnable()
    {
        leftRightAction.Enable();
        cancelAction.Enable();
        leftRightAction.performed += OnleftRightInput;
        cancelAction.performed += OnCancelInput;
    }

    private void OnDisable()
    {
        leftRightAction.Disable();
        cancelAction.Disable();
        leftRightAction.performed -= OnleftRightInput;
        cancelAction.performed -= OnCancelInput;
    }

    public void OnleftRightInput(InputAction.CallbackContext context)//���E���͎��̏���
    {
        float xValue = context.ReadValue<Vector2>().x;

        if (Mathf.Abs(xValue) > inputThreshould)
        {
            if (isHolding)
                return;

            isHolding = true;

            if (xValue < 0)
                leftEvent.Invoke();

            else if (xValue > 0)
                rightEvent.Invoke();
        }

        else
            isHolding = false;
    }

    public void OnCancelInput(InputAction.CallbackContext context)//�L�����Z�����͎��̏���
    {
        cancelEvent.Invoke();
    }
}
