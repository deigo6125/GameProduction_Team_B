using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//�쐬��:���R
//�V�[���J�ڂ̃��\�b�h���Ă�(�V�[�������ς�������̕ύX�̃R�X�g�����炷����)
public class SceneController : MonoBehaviour
{
    [Header("�ȉ��̓Q�[���V�[���Ɉڍs���Ȃ��Ȃ�K�v�Ȃ�")]
    [Header("�Q�[���V�[���Ɉڍs����̂ɕK�v�ȃX�e�[�W�f�[�^")]
    [SerializeField] CurrentStageData _currentStageData;
    [Header("�X�e�[�W�f�[�^���X�g")]
    [SerializeField] StageDataList _stageDataList;

    public void MenuScene()//���j���[��ʂɈڍs
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void StageSelectScene()//�X�e�[�W�I����ʂɈڍs
    {
        SceneManager.LoadScene("StageSelectScene");
    }

    public void ClearScene()//�N���A�V�[���Ɉڍs
    {
        SceneManager.LoadScene("ClearScene");
    }

    public void GameOverScene()//�Q�[���I�[�o�[�V�[���Ɉڍs
    {
        SceneManager.LoadScene("GameoverScene");
    }

    public void RetryGameScene()//��قǃv���C�����ԍ��̃Q�[���V�[�������g���C����
    {
        //�s��������Ζ�������
        if (!CheckError(_currentStageData.StageID)) return;

        SceneManager.LoadScene("ToMainLoadScene");//��x���[�h���(ToMainLoadScene)���o�R������
    }

    public void GameScene(int stageID)//�w��̔ԍ��̃Q�[���V�[���ֈړ�
    {
        //�s��������Ζ�������
        if (!CheckError(stageID)) return;

        _currentStageData.Rewrite(stageID);//���݃v���C���Ă���X�e�[�W�f�[�^�̍X�V

        SceneManager.LoadScene("ToMainLoadScene");//��x���[�h���(ToMainLoadScene)���o�R������
    }

    public void EndGame()//�Q�[�����I������
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    bool CheckError(int stageID)//�Q�[���V�[���ړ����̕s���`�F�b�N
    {
        //�K�v�ȃf�[�^���A�^�b�`����Ă��Ȃ���Όx������
        if (_currentStageData == null || _stageDataList == null)
        {
            Debug.Log("�K�v�ȃf�[�^��������Ă��܂���I");
            return false;
        }

        //�w�肳�ꂽID�̃X�e�[�W�f�[�^�����݂��Ȃ���Όx������
        if (!_stageDataList.ExistStageData(stageID))
        {
            Debug.Log(stageID + "�Ƃ���ID�̃X�e�[�W�f�[�^�͑��݂��܂���");
            return false;
        }

        return true;
    }
}
