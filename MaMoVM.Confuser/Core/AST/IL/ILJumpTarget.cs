﻿#region

using MaMoVM.Confuser.Core.CFG;

#endregion

namespace MaMoVM.Confuser.Core.AST.IL
{
    public class ILBlockTarget : IILOperand, IHasOffset
    {
        public ILBlockTarget(IBasicBlock target)
        {
            Target = target;
        }

        public IBasicBlock Target
        {
            get;
            set;
        }

        public uint Offset => ((ILBlock) Target).Content[0].Offset;

        public override string ToString()
        {
            return string.Format("Block_{0:x2}", Target.Id);
        }
    }
}