using System.Collections.Generic;
using Elements.Core;
using FrooxEngine;

namespace ResoniteSpatialLists.Data.Spatial.Samplers.Lists;

[Category("Data/Spatial/Samplers/Lists")]
class ValueSpatialVariableCollector<T> : 
	Component
{
	public readonly DriveRef<SyncFieldList<T>> ValueList;
	public readonly Sync<string> VariableName;
	public readonly Sync<T> DefaultTarget;
	protected override void OnCommonUpdate()
	{
		base.OnCommonUpdate();
		if (!ValueList.IsLinkValid)
			return;
		List<SpatialVariableResult<T>> list = Pool.BorrowList<SpatialVariableResult<T>>();
		World.SampleSpatialVariables((string)VariableName, Slot.GlobalPosition, list);
		SyncFieldList<T> target = ValueList.Target;
		for (int index = 0; index < list.Count; ++index)
		{
			if (target.Count == index)
				target.Add(list[index].value);
			else
				target[index] = list[index].value;
		}
		while (target.Count > list.Count)
			target.RemoveAt(target.Count - 1);
		Pool.Return(ref list);
	}
}