using UnityEngine;
using UnityEngine.UI;

//�쐬�ҁF�K��

public class SelectedEffectManager : CalculateButtonEffectScale
{
    private RectTransform menuPanel;
    private GameObject effectPrefab;
    private GameObject leftEffect;
    private GameObject rightEffect;

    private const float sizeOffset = 5f;

    private Color effectColor;

    public SelectedEffectManager(RectTransform menuPanel, GameObject effectPrefab)
    {
        this.menuPanel = menuPanel;
        this.effectPrefab = effectPrefab;
    }

    public void SetEffectColor(Color color)// �G�t�F�N�g�̐F��ݒ�
    {
        effectColor = color;
    }

    public void GenerateEffects(RectTransform buttonRect)//�G�t�F�N�g�̐���
    {
        DestroyEffects();
        leftEffect = CreateEffect(buttonRect, true);
        rightEffect = CreateEffect(buttonRect, false);

        SetEffectColor();
    }

    public void DestroyEffects()//�G�t�F�N�g�̔j��
    {
        if (leftEffect != null) Object.DestroyImmediate(leftEffect);
        if (rightEffect != null) Object.DestroyImmediate(rightEffect);
    }

    private GameObject CreateEffect(RectTransform buttonRect, bool isLeft)//�G�t�F�N�g�̐����E����
    {
        GameObject effect = Object.Instantiate(effectPrefab, menuPanel);
        RectTransform effectRect = effect.GetComponent<RectTransform>();

        float panelHalfWidth = CalculateScaledWidth(menuPanel) * 0.5f;

        float buttonHalfWidth = CalculateScaledWidth(buttonRect) * 0.5f;

        float buttonLeft = buttonRect.anchoredPosition.x - buttonHalfWidth;
        float buttonRight = buttonRect.anchoredPosition.x + buttonHalfWidth;

        float effectRectWidth = isLeft
            ? ((panelHalfWidth + buttonLeft) + sizeOffset) / menuPanel.localScale.x
            : ((panelHalfWidth - buttonRight) + sizeOffset) / menuPanel.localScale.x;//�G�t�F�N�g�̉������p�l���[����{�^���[�܂ł̕��ɐݒ�

        float effectRectHeight = CalculateScaledHeight(buttonRect);//�G�t�F�N�g�̏c����ݒ�

        effectRect.sizeDelta = new Vector2(effectRectWidth, effectRectHeight);//�p�l���̃X�P�[�����l�����ĕ���ݒ�

        float effectWidth = effectRect.rect.width * 0.5f * menuPanel.localScale.x;//�X�P�[�����l�����ăG�t�F�N�g�̔����̕����擾
        
        effectRect.anchoredPosition = new Vector2(
            isLeft ? (-panelHalfWidth + effectWidth) / menuPanel.localScale.x : (panelHalfWidth - effectWidth) / menuPanel.localScale.x, buttonRect.anchoredPosition.y);

        if (!isLeft) effectRect.localRotation = Quaternion.Euler(0, 180, 0);//���E���]����

        return effect;
    }

    private void SetEffectColor()//�G�t�F�N�g�̐F�̐ݒ�
    {
        if (leftEffect != null)
        {
            Image effectImage = leftEffect.GetComponent<Image>();
            if (effectImage != null) effectImage.color = effectColor;
        }

        if (rightEffect != null)
        {
            Image effectImage = rightEffect.GetComponent<Image>();
            if (effectImage != null) effectImage.color = effectColor;
        }
    }
}