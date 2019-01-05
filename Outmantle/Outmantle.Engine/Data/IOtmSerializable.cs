using System;
using System.Collections.Generic;
using System.Text;

namespace Outmantle.Engine.Data
{
    public interface IOtmSerializable
    {
        void Serialzie();
        void Deserialize();
    }
}
