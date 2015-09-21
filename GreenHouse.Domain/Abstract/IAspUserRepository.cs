using System;
using System.Collections.Generic;
using GreenHouse.Domain.Entities;

namespace GreenHouse.Domain.Abstract
{
    public interface IAspUserRepository
    {
        AspNetUser GetAspNetUserByEmail(string email);
    }
}
