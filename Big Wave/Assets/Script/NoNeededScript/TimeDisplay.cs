using UnityEngine;
using TMPro;

public class TimeDisplay : MonoBehaviour
{
    //���쐬��:�K��
    [Header("���\��������e�L�X�g")]
    [SerializeField] TMP_Text Time_UI;//�\��������e�L�X�g
    //public static float seconds;//�b
    //public static int minute;//��
    [Header("���������ԁi���j")]
    [SerializeField] int initialMinutes = 2;
    private static int minutes;
    [Header("���������ԁi�b�j")]
    [SerializeField] float initialSeconds = 0f;
    private static float seconds;
    
    private float oldSeconds;//�ߋ��̕b�Bseconds�Ɣ�r����
    //public static  bool sceneSwitch;//���C���̃V�[������n�܂��Ă��鎖�����m
    private static bool sceneSwitch;//���C���̃V�[������n�܂��Ă��鎖�����m

    public static float Seconds
    {
        get { return seconds; }

        private set { seconds = value; }            
    }

    public static int Minutes
    {
        get { return minutes; }

        private set { minutes = value; }
    }

    public static bool SceneSwitch
    {
        get { return sceneSwitch; }

        private set { sceneSwitch = value; }
    }
   

    void Start()
    {
        sceneSwitch = true;
        minutes = initialMinutes;
        seconds = initialSeconds;
        oldSeconds = 0f;
    }

    void Update()
    {
        seconds -= Time.deltaTime;
        if (seconds <0f)//�b��0����������番�����炵��59�b�ɂ���
        {
            minutes--;
            seconds += 60;
        }
        if (seconds != oldSeconds)
        {
            Time_UI.text = "TIME:" + minutes.ToString("00") + ":" + Mathf.Floor(seconds).ToString("00");
        }
        oldSeconds = seconds;
    }
}
