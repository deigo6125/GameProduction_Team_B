using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayGuideButtonEvent : MonoBehaviour
{
    [SerializeField] MenuEffectController menuEffectController;
    [SerializeField] PlayGuideInputModule playGuideInputModule;
    [SerializeField] RectTransform playGuideGroup;
    [SerializeField] List<Image> playGuideImages;
    [SerializeField] Image displayImage;
    [SerializeField] float slideSpeed = 5f;

    private Vector2 offScreenPosition;
    private Vector2 onScreenPosition;

    private int currentIndex = 0;
    private float currentSpeed;

    private bool isSliding = false;//�X���C�h���Ă��邩
    private bool isSlidingIn = false;//�X���C�h�C�����Ă��邩
    private bool isSlidingOut = false;//�X���C�h�A�E�g���Ă��邩
    private bool isImageDisplayed = false;//�摜���\������Ă��邩
    private bool isPlayGuideButtonClicked = false;//�{�^���������ꂽ��

    private void Start()
    {
        playGuideInputModule.enabled = false;

        playGuideGroup.gameObject.SetActive(true);
        offScreenPosition = new Vector2(0, Screen.height);//�摜���[���̍��W��ݒ�
        onScreenPosition = playGuideGroup.anchoredPosition;//�摜�\�����̍��W��ݒ�
        playGuideGroup.anchoredPosition = offScreenPosition;//�����ʒu����ʊO�ɐݒ�
    }

    private void Update()
    {
        //�{�^�����N���b�N����Ă��Ȃ��Ȃ�
        if (!isPlayGuideButtonClicked) return;

        if (menuEffectController.EffectColorChanged)//���莞�̃G�t�F�N�g����������I������
        {
            if (isSlidingIn || isSlidingOut)//�摜���X���C�h�ړ����Ȃ�
            {
                isSliding = true;
                playGuideInputModule.DisableAllUIActions();//�S�Ă̓��͂𖳌���
                SlidingPlayGuide();//�摜�̃X���C�h����
            }

            if (isImageDisplayed)//�摜���\������Ă���Ȃ�
            {
                playGuideInputModule.EnableSpecificUIActions();//�ꕔ�̓��͂�L����
            }
        }
    }

    private void ShowImage(int index)//�摜�̕\��
    {
        playGuideImages[index].gameObject.SetActive(true);
        isSlidingIn = true;
        currentSpeed = slideSpeed;
    }

    public void ShowNextImage()//���̉摜��\��
    {
        if (!isSliding)
        {
            playGuideImages[currentIndex].gameObject.SetActive(false);
            currentIndex = (currentIndex + 1) % playGuideImages.Count;
            ShowImage(currentIndex);
        }
    }

    public void ShowPreviousImage()//�O�̉摜��\��
    {
        if (!isSliding)
        {
            playGuideImages[currentIndex].gameObject.SetActive(false);
            currentIndex = (currentIndex - 1 + playGuideImages.Count) % playGuideImages.Count;
            ShowImage(currentIndex);
        }
    }

    public void CloseImage()//�摜�����[
    {
        if (!isSliding)
        {
            isSlidingOut = true;
            currentSpeed = slideSpeed;
        }
    }

    public void PlayGuideButtonClicked()//playGuideButton�������ꂽ�Ƃ��̏���
    {
        if (!isSliding)
        {
            ShowImage(currentIndex);
            isPlayGuideButtonClicked = true;
        }
    }

    private void SlidingPlayGuide()//�摜�̃X���C�h�ړ�����
    {
        playGuideInputModule.enabled = false;

        //�摜�̈ړ�����
        playGuideGroup.anchoredPosition = Vector2.Lerp(playGuideGroup.anchoredPosition,
            isSlidingIn ? onScreenPosition : offScreenPosition, currentSpeed * Time.deltaTime);

        //���݂̉摜�̍��W�Ɛݒ���W�Ƃ̋��������ȉ��ɂȂ�����
        if (Vector2.Distance(playGuideGroup.anchoredPosition,
            isSlidingIn ? onScreenPosition : offScreenPosition) < 0.1f)
        {
            isSliding = false;
            playGuideGroup.anchoredPosition = isSlidingIn ? onScreenPosition : offScreenPosition;

            if (isSlidingIn)//�X���C�h�C���������̏���
            {
                CompleteSlideIn();
            }
            else if (isSlidingOut)//�X���C�h�A�E�g�������̏���
            {
                CompleteSlideOut();
            }
        }
    }

    private void CompleteSlideIn()//�X���C�h�C���������̏���
    {
        isSlidingIn = false;
        isImageDisplayed = true;
        playGuideInputModule.enabled = true;
        playGuideInputModule.EnableSpecificUIActions();//�ꕔ���͂�L����
    }

    private void CompleteSlideOut()//�X���C�h�A�E�g�������̏���
    {
        playGuideImages[currentIndex].gameObject.SetActive(false);
        isPlayGuideButtonClicked = false;
        isSlidingOut = false;
        isImageDisplayed = false;
        menuEffectController.ResetButtonEffects();//�{�^���G�t�F�N�g�̍Đݒ�
        playGuideInputModule.enabled = true;
        playGuideInputModule.EnableAllUIActions();//�ꕔ���͂�L����
        playGuideInputModule.enabled = false;
    }
}