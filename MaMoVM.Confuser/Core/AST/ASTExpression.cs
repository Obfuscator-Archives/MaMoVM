﻿namespace MaMoVM.Confuser.Core.AST
{
    public abstract class ASTExpression : ASTNode
    {
        public ASTType? Type
        {
            get;
            set;
        }
    }
}