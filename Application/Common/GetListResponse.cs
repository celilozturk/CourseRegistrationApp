using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common;
public class GetListResponse<T>
{
    public IList<T> Items { get; set; }
}
