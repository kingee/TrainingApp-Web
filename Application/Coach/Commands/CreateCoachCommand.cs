﻿using PlainCQRS.Core.Commands;

namespace Application.Coach.Commands
{
    public class CreateCoachCommand: ICommand
    {
        public CreateCoachCommand(string login, 
            string password, string firstName, 
            string lastName, string email, string preSharedKey)
        {
            Login = login;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PreSharedKey = preSharedKey;
        }

        public string Login { get; private set; }
        public string Password { get; private set; }
        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string Email { get; private set; }
        public string PreSharedKey { get; private set; }
    }
}

