﻿using System;
using System.Reflection;
using MaMoVM.Runtime.Dynamic;
using MaMoVM.Runtime.Execution;
using MaMoVM.Runtime.Execution.Internal;

namespace MaMoVM.Runtime.VCalls
{
    internal class Stfld : IVCall
    {
        public byte Code => Constants.VCALL_STFLD;

        [VMProtect.BeginMutation]
        public unsafe void Run(VMContext ctx, out ExecutionState state)
        {
            var sp = ctx.Registers[Constants.REG_SP].U4;
            var fieldSlot = ctx.Stack[sp--];
            var valSlot = ctx.Stack[sp--];
            var objSlot = ctx.Stack[sp--];

            var field = (FieldInfo) ctx.Instance.Data.LookupReference(fieldSlot.U4);
            if(!field.IsStatic && objSlot.O == null)
                throw new NullReferenceException();

            object value;
            if(Type.GetTypeCode(field.FieldType) == TypeCode.String && valSlot.O == null)
                value = ctx.Instance.Data.LookupString(valSlot.U4);
            else
                value = valSlot.ToObject(field.FieldType);

            if(field.DeclaringType.IsValueType && objSlot.O is IReference)
            {
                TypedReference typedRef;
                ((IReference) objSlot.O).ToTypedReference(ctx, &typedRef, field.DeclaringType);
                TypedReferenceHelpers.CastTypedRef(&typedRef, field.DeclaringType);
                field.SetValueDirect(typedRef, value);
            }
            else
            {
                field.SetValue(objSlot.ToObject(field.DeclaringType), value);
            }

            ctx.Stack.SetTopPosition(sp);
            ctx.Registers[Constants.REG_SP].U4 = sp;
            state = ExecutionState.Next;
        }
    }
}