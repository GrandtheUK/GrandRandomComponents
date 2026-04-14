using FrooxEngine;

namespace GrandRandomComponents.Transform.Drivers;

[Category(new string[] {"LocalUser"})]
public class LocalUserDriver : Component
{
    public readonly RefDrive<User> Target;

    protected override void OnChanges()
    {
        if (!Target.IsLinkValid)
            return;
        Target.Target.Value = World.LocalUser.ReferenceID;
    }

    protected override void OnAwake()
    {
        base.OnAwake();
        Target.SetupReferenceHook((HookRefSetter<User>) ((reference, target) =>
        {
            Target.Target.Value = World.LocalUser.ReferenceID;
        }));
    }
}