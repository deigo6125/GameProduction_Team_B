using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpAnim : MonoBehaviour
{
    [Header("�K�v�ȃR���|�[�l���g")]
    [SerializeField] JudgeJumpNow judgeJumpNow;
    [SerializeField] Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        JumpBool();
    }

    void JumpBool()
    {
        animator?.SetBool("Onground", !judgeJumpNow.JumpNow());
    }
}
