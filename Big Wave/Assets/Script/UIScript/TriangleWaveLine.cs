using UnityEngine;
using UnityEngine.UI;

public class TriangleWaveLine : MonoBehaviour
{
    [Header("�d���G�t�F�N�g�̉摜")]
    [SerializeField] Image electricImage;
    [Header("�G�t�F�N�g�̍Đ����x")]
    [SerializeField] float speed = 1.0f;
    [Header("�Đ��������A�Đ��������~�߂邩")]
    [SerializeField] bool isStop = true;

    private bool effectCompleted;

    public bool EffectCompleted
    {
        get { return effectCompleted; }
    }

    void Start()
    {
        electricImage.fillAmount = 0.0f;
        effectCompleted = false;
    }

    void Update()
    {
        electricImage.fillAmount += speed * Time.deltaTime;//FillAmount�����Ԃɉ����Ē���

        if (electricImage.fillAmount >= 1.0f)//FillAmount��1�ɂȂ�����0�ɖ߂�
        {
            if (isStop)
            {
                electricImage.fillAmount = 1.0f;//�G�t�F�N�g�̕\�����Œ�
                effectCompleted = true;
            }

            else
                electricImage.fillAmount = 0.0f;//�G�t�F�N�g�̍Đ����J��Ԃ�
        }
    }
}
