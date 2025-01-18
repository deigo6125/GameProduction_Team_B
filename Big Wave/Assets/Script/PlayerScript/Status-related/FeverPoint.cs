using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�t�B�[�o�[�|�C���g
public class FeverPoint : MonoBehaviour
{
    [Header("�ő�t�B�[�o�[�|�C���g")]
    [SerializeField] float feverPointMax = 500f;//�ő�t�B�[�o�[�|�C���g
    private float feverPoint = 0f;//���݂̃t�B�[�o�[�|�C���g

    public float FeverPoint_
    {
        get { return feverPoint; }
        set
        {
            feverPoint = value;
            feverPoint = Mathf.Clamp(feverPoint, 0f, feverPointMax);//�t�B�[�o�[�|�C���g�����E�˔j���Ȃ��悤��
        }
    }

    public float FeverPointMax
    {
        get { return feverPointMax; }
    }
    // Start is called before the first frame update
    void Start()
    {
        feverPoint = 0f;
    }
}
