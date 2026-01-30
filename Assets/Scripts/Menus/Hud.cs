using UnityEngine;

public class Hud : MenusBaseState
{
    public override void BeginState(UIManager uiManager)
    {
        base.BeginState(uiManager);
        GameManager.Instance.PauseGame(false);
    }

    public override void UpdateState()
    {
        base.UpdateState();
    }

    public override void ExitState()
    {
        base.ExitState();
        uiManager.ShowPanelEnum(UIManager.menusState.PAUSEMENU);
    }
}
