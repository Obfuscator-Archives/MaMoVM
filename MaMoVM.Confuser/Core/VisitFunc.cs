﻿namespace MaMoVM.Confuser.Core
{
    public delegate void VisitFunc<TList, TInstr, TState>(TList list, TInstr instr, ref int index, TState state);
}