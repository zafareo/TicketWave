﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commons.Interfaces;

public interface ICurrentUserService
{
    string Username { get; }
}
