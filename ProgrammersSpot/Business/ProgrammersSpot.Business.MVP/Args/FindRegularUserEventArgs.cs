using System;

namespace ProgrammersSpot.Business.MVP.Args
{
    public class FindRegularUserEventArgs : EventArgs
    {
        public FindRegularUserEventArgs(string id)
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
