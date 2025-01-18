using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//�쐬��:���R
//�Q�[���V�[���ւ̃��[�h����
public class LoadMainScene : MonoBehaviour
{
    [SerializeField] Slider _slider;
    [SerializeField] CurrentStageData _currentStageData;

    void Start()
    {
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()//�Q�[���V�[���ւ̃��[�h
    {
        //�O�̃V�[���Ō��݃v���C���Ă���X�e�[�W�f�[�^���X�V����Ă���͂��Ȃ̂ł��̃V�[������ǂݍ���
        AsyncOperation async = SceneManager.LoadSceneAsync(_currentStageData.StageSceneName);

        while (!async.isDone)
        {
            _slider.value = async.progress;
            yield return null;
        }
    }
}
