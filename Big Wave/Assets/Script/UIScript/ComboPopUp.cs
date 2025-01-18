using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static UnityEngine.GraphicsBuffer;
using Unity.VisualScripting;
using System.Runtime.CompilerServices;

public class ComboPopUp : MonoBehaviour
{
    public TMP_Text text_countPrefab;
    [SerializeField] string[] PopUpTexts;
    [SerializeField] RectTransform target;
    [SerializeField] Transform parent;
    [SerializeField] Count_Trick_Critical countTrickCombo;
    [SerializeField] JudgeJumpNow judgeJumpNow;
    [SerializeField] float ScaleText;
    [SerializeField] float StartSize;
    private float DefaultSize;
    private int comboCount = 0;
    public int ComboCount
    {
        get { return comboCount; }
        set { comboCount = value; }
    }
   

    public void Start()
    {
        DefaultSize = StartSize;
        text_countPrefab.fontSize = DefaultSize;
        judgeJumpNow.StartJumpAction+=ResetCombo;
    }
    public void PopUp()
    {
        if (countTrickCombo.ContinueCritical)
        {

            if (comboCount > PopUpTexts.Length)
            {
                comboCount = PopUpTexts.Length;
            }
            
                text_countPrefab.fontSize += ScaleText;
            

            text_countPrefab.text = PopUpTexts[comboCount];
            Instantiate(text_countPrefab, target.position, target.rotation, parent);// Canvas �̎q�v�f�Ƃ���target�̈ʒu�ɃC���X�^���X�𐶐�
            comboCount++;
        }
        else
        {

            ResetCombo();
        }
    }
  public  void ResetCombo()
    {
        text_countPrefab.fontSize = DefaultSize;
        ComboCount = 0;
    }
}
