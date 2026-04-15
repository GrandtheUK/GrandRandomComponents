using System.Collections.Generic;
using Elements.Core;
using FrooxEngine;

namespace GrandRandomComponents.CommonUI.ButtonInteractions;

[Category("Common UI/Button Interactions")]
[GenericTypes(GenericTypesAttribute.Group.EnginePrimitives)]
public class ButtonDynamicValueSet<T> :
    Component,
    IButtonPressReceiver
{
    public readonly SyncRef<Slot> TargetSlot;
    public readonly SyncBag<ButtonDynamicValueSet<T>.DynamicVariable> _pressedDynamicVariables;
    public readonly SyncBag<ButtonDynamicValueSet<T>.DynamicVariable> _pressingDynamicVariables;
    public readonly SyncBag<ButtonDynamicValueSet<T>.DynamicVariable> _releasedDynamicVariables;

    public class DynamicVariable : SyncObject
    {
        public readonly SyncRef<Slot> SlotOverride;
        public readonly Sync<string> Name = new();
        public readonly Sync<T> ValueSet = new();
        public readonly Sync<bool> CreateIfNotExist = new();
        public readonly Sync<bool> CreateNonPersistant = new();
    }

    public void Pressed(IButton button, ButtonEventData eventData)
    {
        Slot slot = TargetSlot.Target ?? this.Slot;
        foreach (KeyValuePair<RefID,DynamicVariable> DynVar in _pressedDynamicVariables)
        {
            string name = DynVar.Value.Name.Value;
            T value = DynVar.Value.ValueSet.Value;
            bool create = DynVar.Value.CreateIfNotExist.Value;
            bool persist = DynVar.Value.CreateNonPersistant.Value;
            Slot overrideSlot = DynVar.Value.SlotOverride.Target;
            Slot target = overrideSlot ?? slot;
            if (target == null)
                continue;
            DynamicVariableHelper.ParsePath(name,out string spaceName, out string variableName);
            DynamicVariableSpace space = DynamicVariableHelper.FindSpace(slot, spaceName);
            if (space == null)
                continue;
            space.GetManager<T>(variableName,create).SetValue(value);
        } 
    }

    public void Pressing(IButton button, ButtonEventData eventData)
    {
        Slot slot = TargetSlot.Target ?? this.Slot;
        foreach (KeyValuePair<RefID,DynamicVariable> DynVar in _pressingDynamicVariables)
        {
            string name = DynVar.Value.Name.Value;
            T value = DynVar.Value.ValueSet.Value;
            bool create = DynVar.Value.CreateIfNotExist.Value;
            bool persist = DynVar.Value.CreateNonPersistant.Value;
            Slot overrideSlot = DynVar.Value.SlotOverride.Target;
            Slot target = overrideSlot ?? slot;
            if (target == null)
                continue;
            DynamicVariableHelper.ParsePath(name,out string spaceName, out string variableName);
            DynamicVariableSpace space = DynamicVariableHelper.FindSpace(slot, spaceName);
            if (space == null)
                continue;
            space.GetManager<T>(variableName,create).SetValue(value);
        } 
    }

    public void Released(IButton button, ButtonEventData eventData)
    {
        Slot slot = TargetSlot.Target ?? this.Slot;
        foreach (KeyValuePair<RefID,DynamicVariable> DynVar in _releasedDynamicVariables)
        {
            string name = DynVar.Value.Name.Value;
            T value = DynVar.Value.ValueSet.Value;
            bool create = DynVar.Value.CreateIfNotExist.Value;
            bool persist = DynVar.Value.CreateNonPersistant.Value;
            Slot overrideSlot = DynVar.Value.SlotOverride.Target;
            Slot target = overrideSlot ?? slot;
            if (target == null)
                continue;
            DynamicVariableHelper.ParsePath(name,out string spaceName, out string variableName);
            DynamicVariableSpace space = DynamicVariableHelper.FindSpace(slot, spaceName);
            if (space == null)
                continue;
            space.GetManager<T>(variableName,create).SetValue(value);
        } 
    }
}