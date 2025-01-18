using UnityEngine;
using UnityEngine.UI;

//�쐬�ҁF�K��

public class MenuEffectController : MonoBehaviour
{
    [Header("���W�v�Z�̂��Ƃɂ���I�u�W�F�N�g")]
    [SerializeField] RectTransform menuPanel;
    [Header("���G�t�F�N�g�֘A�̐ݒ�")]
    [Header("�I�����̃G�t�F�N�g")]
    [SerializeField] GameObject selectedEffectPrefab;
    [Header("���莞�̃G�t�F�N�g")]
    [SerializeField] GameObject clickedEffectPrefab;
    [Header("���莞�̃G�t�F�N�g�̐F")]
    [SerializeField] Color clickedEffectColor;

    private SelectedEffectManager selectedEffectManager;
    private ClickedEffectManager clickedEffectManager;
    private TriangleWaveLine triangleWaveLine;

    private RectTransform currentButtonRect;
    private Image currentButtonImage;//���ݑI�𒆂̃{�^���̉摜
    private Color originalButtonColor;//�{�^���̏����ݒ莞�̐F

    private bool clickedEffectGenerated = false;//���莞�̃G�t�F�N�g���������ꂽ��
    private bool effectColorChanged = false;//�G�t�F�N�g�̐F���ω�������

    public bool ClickedEffectGenerated { get { return clickedEffectGenerated; } }

    public bool EffectColorChanged { get { return effectColorChanged; } }

    private void Start()
    {
        selectedEffectManager = new SelectedEffectManager(menuPanel, selectedEffectPrefab);
        clickedEffectManager = new ClickedEffectManager(menuPanel, clickedEffectPrefab, clickedEffectColor);
    }

    void Update()
    {
        if (triangleWaveLine == null && clickedEffectManager.EffectPrefab != null)            
            triangleWaveLine = clickedEffectManager.EffectPrefab.GetComponent<TriangleWaveLine>();//���莞�̃G�t�F�N�g�̃R���|�[�l���g���擾

        if (clickedEffectManager.IsEffectGenerated)
        {
            if (triangleWaveLine.EffectCompleted)//����p�̃G�t�F�N�g�����ׂĕ\�����ꂽ��
            {
                if (currentButtonImage != null)
                {
                    currentButtonImage.color = clickedEffectColor;//�{�^���̐F�����莞�G�t�F�N�g�̐F�ɕύX����
                    effectColorChanged = true;
                }
            }
        }
    }

    public void ButtonSelectedProcess(RectTransform buttonRect)//�{�^���I�����̏���
    {
        currentButtonRect = buttonRect;
        currentButtonImage = buttonRect.GetComponent<Image>();
        originalButtonColor = currentButtonImage.color;
        selectedEffectManager.SetEffectColor(originalButtonColor);
        selectedEffectManager.GenerateEffects(buttonRect);//�I�����̃G�t�F�N�g�̐���
    }

    public void ButtonDeselectedProcess()//�I����؂�ւ����Ƃ��̏���
    {
        selectedEffectManager.DestroyEffects();//�I�����̃G�t�F�N�g�̔j��
        clickedEffectManager.DestroyEffects();//���莞�̃G�t�F�N�g�̔j��

        if (currentButtonImage != null)
            currentButtonImage.color = originalButtonColor;//�{�^���̐F�̏�����
    }

    public void ButtonClickedProcess(RectTransform buttonRect)//�{�^�����莞�̏���
    {
        if (!clickedEffectManager.IsEffectGenerated)
        {
            clickedEffectManager.GenerateEffects(buttonRect);//�{�^�����莞�̃G�t�F�N�g�̐���
            currentButtonImage = buttonRect.GetComponent<Image>();
        }
    }

    public void ResetButtonEffects()//�{�^���̃G�t�F�N�g�̏�����
    {
        clickedEffectManager.DestroyEffects();//���莞�̃G�t�F�N�g�̔j��
        selectedEffectManager.GenerateEffects(currentButtonRect);//�I�����̃G�t�F�N�g�̐���

        if (currentButtonImage != null)
        {
            currentButtonImage.color = originalButtonColor;//�{�^���̐F�̏�����
        }
    }
}
