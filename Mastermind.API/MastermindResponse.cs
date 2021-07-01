using System.Collections.Generic;
using Mastermind.Core;

namespace Mastermind.API
{
    public class MastermindResponse
    {
        public bool Win { get; set; }
        public List<Row> Rows { get; set; }
    }
}