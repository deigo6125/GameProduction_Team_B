using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬�ҁF�K��

public partial class PlayGuideInputHandler
{
    public void EnableSpecificUIActions()//�ꕔ���͂�L����
    {
        leftRightAction.Enable();
        cancelAction.Enable();
    }

    public void DisableSpecificUIActions()//�ꕔ���͂𖳌���
    {
        leftRightAction.Disable();
        cancelAction.Disable();
    }

    public void EnableAllUIActions()//�S�Ă̓��͂�L����
    {
        if (actionHandler == null) return;

        actionHandler.point.action.Enable();
        actionHandler.move.action.Enable();
        actionHandler.submit.action.Enable();
        actionHandler.cancel.action.Enable();
    }

    public void DisableAllUIActions()//�S�Ă̓��͂𖳌���
    {
        if (actionHandler == null) return;

        actionHandler.point.action.Disable();
        actionHandler.move.action.Disable();
        actionHandler.submit.action.Disable();
        actionHandler.cancel.action.Disable();
    }
}
