﻿namespace MaMoVM.Confuser.Core.VMIL
{
    public interface ITransform
    {
        void Initialize(ILTransformer tr);
        void Transform(ILTransformer tr);
    }
}