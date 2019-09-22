using MicroS_Common.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace weerp.Services.Settings.Domain
{
    public class Setting : BaseEntity
    {
        public Setting(Guid id) : base(id)
        {

        }

        public string Numero { get; private set; }

        public string Nom { get; private set; }
    }
}
