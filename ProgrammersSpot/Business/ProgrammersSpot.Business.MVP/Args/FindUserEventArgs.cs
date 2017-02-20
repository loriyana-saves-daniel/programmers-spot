using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersSpot.Business.MVP.Args
{
    public class FindUserEventArgs : EventArgs
    {
        public FindUserEventArgs(string id)
        {
            this.Id = id;
        }

        //public FindRegularUserEventArgs(int id, string name)
        //{
        //    Guard.WhenArgument(name, "Name is null!").IsNullOrEmpty().Throw();

        //    this.Id = id;
        //    this.Name = name;
        //}

        public string Id { get; private set; }
        //public string Name { get; set; }
    }
}
