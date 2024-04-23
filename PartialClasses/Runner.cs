using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarathonWPF
{
    public partial class Runner
    {
        public string InfoString => $"{User.LastName} {User.FirstName} - {RunnerId} ({Country.CountryName})";
    }
}
