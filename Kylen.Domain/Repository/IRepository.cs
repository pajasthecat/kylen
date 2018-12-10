using Kylen.Domain.Models;
using System.Collections.Generic;

namespace Kylen.Domain.Repository
{
    public interface IRepository
    {
        IEnumerable<DrinkStatus> GetDrinkStatus();
    }
}
