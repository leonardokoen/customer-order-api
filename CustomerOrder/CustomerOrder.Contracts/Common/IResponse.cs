﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrder.Contracts.Common
{
    public interface IResponse
    {
        string Message {  get; }
    }
}
