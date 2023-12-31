﻿#region

using System;
using System.Collections.Generic;
using MaMoVM.Confuser.Core.AST.IR;
using MaMoVM.Confuser.Core.CFG;
using MaMoVM.Confuser.Core.RT;
using MaMoVM.Confuser.Core.VM;
using MaMoVM.Confuser.Core.VMIR.Transforms;

#endregion

namespace MaMoVM.Confuser.Core.VMIR
{
    public class IRTransformer
    {
        private ITransform[] pipeline;

        public IRTransformer(ScopeBlock rootScope, IRContext ctx, VMRuntime runtime)
        {
            RootScope = rootScope;
            Context = ctx;
            Runtime = runtime;

            Annotations = new Dictionary<object, object>();
            InitPipeline();
        }

        public IRContext Context
        {
            get;
        }

        public VMRuntime Runtime
        {
            get;
        }

        public VMDescriptor VM => Runtime.Descriptor;

        public ScopeBlock RootScope
        {
            get;
        }

        internal Dictionary<object, object> Annotations
        {
            get;
        }

        internal BasicBlock<IRInstrList> Block
        {
            get;
            private set;
        }

        internal IRInstrList Instructions => Block.Content;

        private void InitPipeline()
        {
            pipeline = new ITransform[]
            {
                // new SMCIRTransform(),
                Context.IsRuntime ? null : new GuardBlockTransform(),
                Context.IsRuntime ? null : new EHTransform(),
                new InitLocalTransform(),
                new ConstantTypePromotionTransform(),
                new GetSetFlagTransform(),
                new LogicTransform(),
                new InvokeTransform(),
                new MetadataTransform(),
                Context.IsRuntime ? null : new RegisterAllocationTransform(),
                Context.IsRuntime ? null : new StackFrameTransform(),
                new LeaTransform(),
                Context.IsRuntime ? null : new MarkReturnRegTransform()
            };
        }

        public void Transform()
        {
            if(pipeline == null)
                throw new InvalidOperationException("Transformer already used.");

            foreach(var handler in pipeline)
            {
                if(handler == null)
                    continue;
                handler.Initialize(this);

                RootScope.ProcessBasicBlocks<IRInstrList>(block =>
                {
                    Block = block;
                    handler.Transform(this);
                });
            }

            pipeline = null;
        }
    }
}