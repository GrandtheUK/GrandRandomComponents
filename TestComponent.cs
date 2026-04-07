using Elements.Core;
using FrooxEngine;

namespace TestPlugin;

[Category("TestPlugin")]
class MyCoolComponent : Component
{
	public readonly Sync<float3> TestThing;

	protected override void OnAttach()
	{
		TestThing.Value = float3.One * 0.47f;
	}
}