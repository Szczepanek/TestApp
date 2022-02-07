using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Services
{
    public interface ITransferService
    {
        int[] Initialize(int arrayLength);
        int[] Transfer(int[] generatedNumbers);
    }
}
