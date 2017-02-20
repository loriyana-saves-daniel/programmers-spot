namespace ProgrammersSpot.Business.MVP.Args
{
    public class RegistrationEventArgs : OwinCtxEventArgs
    {
        public string Email { get; set; }

        public string FirmName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string Address { get; set; }

        public string Password { get; set; }

        public string ConfirmedPassword { get; set; }

        public string UserType { get; set; }
    }
}

