using System;
using FrooxEngine;

namespace GrandRandomComponents.CommonUI.ButtonInteractions;

[Category("Common UI/Button Interactions")]
public class ButtonActionListTrigger : 
    Component,
    IButtonPressReceiver
{
    public readonly SyncDelegateList<Action> OnPressed;
    public readonly SyncDelegateList<Action> OnPressing;
    public readonly SyncDelegateList<Action> OnReleased;

    public void Pressed(IButton button, ButtonEventData eventData)
    {
        foreach (Action action in OnPressed)
        {
            if (action == null)
                continue;
            action();
        }
    }
    public void Pressing(IButton button, ButtonEventData eventData)
    {
        foreach (Action action in OnPressing)
        {
            if (action == null)
                continue;
            action();
        }
    }

    public void Released(IButton button, ButtonEventData eventData)
    {
        foreach (Action action in OnReleased)
        {
            if (action == null)
                continue;
            action();
        }
    }
}