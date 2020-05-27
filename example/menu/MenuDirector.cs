using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace example.menu
{
    internal interface IMenuDirector
    {
        public void ConstructMenu(IMenuBuilder builder);
    }

    internal class MenuDirector : IMenuDirector
    {
        public void ConstructMenu(IMenuBuilder builder)
        {
            builder.BuildShowCompanyMenuOption();
            builder.BuildAddCompanyMenuOption();
            builder.BuildRemoveCompanyMenuOption();
            builder.BuildAddEmployeeMenuOption();
            builder.BuildRemoveEmployeeMenuOption();
            builder.BuildGetManagerByEmployeeId();
            builder.BuildGetStaffByEmployeeId();
            builder.BuildExitMenuOption();
        }
    }
}
