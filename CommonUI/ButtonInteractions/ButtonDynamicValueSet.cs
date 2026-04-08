using FrooxEngine;

namespace ResoniteSpatialLists.CommonUI.ButtonInteractions;

[Category("Common UI/Button Interactions")]
public class ButtonDynamicValueSet<T> :
    Component,
    IButtonPressReceiver
{
    public readonly SyncRef<Slot> TargetSlot;
    public readonly SyncBag<ButtonDynamicValueSet<T>.DynamicVariable> _dynamicVariables;

    public class DynamicVariable: SyncObject
    {
        public readonly Sync<string> Name;
        public readonly Sync<T> ValueSet;
        protected override void InitializeSyncMembers()
        {
            base.InitializeSyncMembers();
            this.Name = new Sync<string>();
            this.ValueSet = new Sync<T>();
        }
    }
}