using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

//�쐬�ҁF�K��

public class PlayGuideController : MonoBehaviour
{
    [Header("�v���C�K�C�h���o���{�^��")]
    [SerializeField] GameObject _playGuidebutton;
    [Header("�K�v�ȃR���|�[�l���g")]
    [SerializeField] EventSystem _eventSystem;
    [SerializeField] PlayGuideInputHandler playGuideInputHandlerObject;
    [SerializeField] TransitionPages transitionPagesObject;
    [SerializeField] PlayGuideSlider playGuideSlider;
    [Header("���삵�����摜")]
    [SerializeField] List<Image> playGuideImages;

    private PlayGuideInputHandler playGuideInputHandler;
    private TransitionPages transitionPages;
    private int currentIndex = 0;
    private bool isOpenGuide = false;

    private void Start()
    {
        playGuideInputHandler = playGuideInputHandlerObject.GetComponent<PlayGuideInputHandler>();
        transitionPages = transitionPagesObject.GetComponent<TransitionPages>();

        transitionPages.SetImages(playGuideImages, currentIndex);
    }

    private void Update()
    {
        //��ʂ��X���C�h���Ă��Ȃ��A�\������Ă��Ȃ��Ȃ�
        if (!playGuideSlider.IsSliding && !playGuideSlider.IsDisplay)
            playGuideInputHandler.EnableAllUIActions();//�S�Ă̑����L����

        if (isOpenGuide)
        {
            playGuideInputHandler.DisableAllUIActions();//�S�Ă̑���𖳌���

            OpenGuide();

            if (!playGuideSlider.IsSliding && playGuideSlider.IsDisplay)//�����L���ɂ���A�X���C�h�A�E�g������҂��Ă���
            {
                playGuideInputHandler.EnableSpecificUIActions();
            }
        }

        else
        {
            playGuideInputHandler.DisableSpecificUIActions();//�ꕔ�̑���𖳌���
            if (playGuideSlider.CompletedSlideOut)//�摜�̃X���C�h���������Ă�����
            {
                transitionPages.HideImage(currentIndex);
                _eventSystem.SetSelectedGameObject(_playGuidebutton);//�v���C�K�C�h�̃{�^����I����Ԃɂ���
                playGuideSlider.CompletedSlideOut = false;
            }
        }
    }

    public void OpenGuide()//�K�C�h�̕\������
    {
        if (!playGuideSlider.IsDisplay)
        {
            transitionPages.ShowImage(currentIndex);
            playGuideSlider.SlideIn();
        }
    }

    public void CloseGuide()//�K�C�h�̊i�[����
    {
        if (playGuideSlider.IsDisplay)
        {
            playGuideSlider.SlideOut();
            isOpenGuide = false;
        }
    }

    public void PlayGuideButtonClicked()//playGuideButton�{�^�����������Ƃ��̏���
    {
        if (!playGuideSlider.IsSliding && !playGuideSlider.IsDisplay)
        {
            isOpenGuide = true;
        }
    }
}
