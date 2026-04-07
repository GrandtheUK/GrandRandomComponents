using FrooxEngine.ProtoFlux;
using ProtoFlux.Core;
using ProtoFlux.Runtimes.Execution; // this is needed by the bindings generator

namespace ProtoFlux.Runtimes.Execution.Nodes.TestPlugin
{
	[NodeCategory("TestPlugin")]
	public class TestNode : ValueFunctionNode<FrooxEngineContext, int>
	{
		public ValueInput<int> Input;

		protected override int Compute(FrooxEngineContext context)
		{
			var num = Input.Evaluate(context);
			return num * 2;
		}
	}
}