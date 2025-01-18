using UnityEngine;
using UnityEngine.UI;

public class BlinkObject : MonoBehaviour
{
    [SerializeField] private Image targetObject; // �Ώۂ̃Q�[���I�u�W�F�N�g
    [SerializeField] private float cycleDuration = 1f; // �_�ŃT�C�N������
    [SerializeField] private float speed = 1f; // �_�ő��x
    private float elapsedTime = 0f; // �o�ߎ���
    private bool change=true;
    private float isVisible ; // ���݂̕\�����

   

    private void Update()
    {
        BlinkObjectLogic();
    }

    private void BlinkObjectLogic()
    {
        // �o�ߎ��Ԃ��X�V
        elapsedTime += speed * Time.deltaTime;
        // �T�C�N�����Ԃ𒴂����ꍇ�ɐ؂�ւ�
        if (elapsedTime > cycleDuration)
        {
            change = !change;
            elapsedTime = 0f; // �o�ߎ��Ԃ����Z�b�g
            isVisible = (change ? 0 : 255);
            targetObject.color = new(targetObject.color.r, targetObject.color.g, targetObject.color.b,isVisible ); // �\����Ԃ�K�p
        }
    }
}
