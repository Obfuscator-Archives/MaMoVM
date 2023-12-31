﻿#region

using dnlib.DotNet;
using MaMoVM.Confuser.Core.RT;

#endregion

namespace MaMoVM.Confuser.Core.AST.IL
{
    public class ILMethodTarget : IILOperand, IHasOffset
    {
        private ILBlock methodEntry;

        public ILMethodTarget(MethodDef target)
        {
            Target = target;
        }

        public MethodDef Target
        {
            get;
            set;
        }

        public uint Offset => methodEntry == null ? 0 : methodEntry.Content[0].Offset;

        public void Resolve(VMRuntime runtime)
        {
            runtime.LookupMethod(Target, out methodEntry);
        }

        public override string ToString()
        {
            return Target.ToString();
        }
    }
}