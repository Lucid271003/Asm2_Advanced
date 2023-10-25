using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asm2_Advanced
{
    internal interface IMenu
    {
        int MainMenu();
        int AdminMenu();
        int UserMenu();
    }
}
