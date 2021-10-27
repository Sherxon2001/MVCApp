using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pension.Api.Event
{
    public enum ResponseType
    {
        Error,
        Successfully,
        NotFound,
        Exist,
        Delete
    }
}
