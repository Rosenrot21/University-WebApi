using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.Application.Common;

public class PageResponse<T> where T : class
{
    public int Count { get; init; }

    public T Data { get; init; }
}


