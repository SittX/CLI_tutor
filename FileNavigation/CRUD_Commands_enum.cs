using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileNavigation
{
    internal class CRUD_Commands_enum
    {
        enum ReadCommands
        {
            ls,
            cat
        }

        enum CreateCommands
        {
            touch,
            mkdir
        }

        enum DeleteCommands
        {
            rm,
            rmdir
        }
    }
}
