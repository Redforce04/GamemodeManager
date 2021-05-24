using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamemodeManager.API
{
    public abstract class CustomGamemode
    {
        public abstract string Name { get; }
        public abstract string Author { get; }
        public abstract string CommandPrefix { get; }

        public virtual void OnLoaded()
        {

        }
    }
}
