///////////////////////////////////////////////////////////////////
//
// NEXT-GEN demos
// Copyright (c) Youbiquitous srls 2018
//
// Author: Dino Esposito (http://youbiquitous.net)
//


using TaskZero.Server.Common;
using TaskZero.Server.Models.Account;
using TaskZero.Server.Resources;
using TaskZero.Shared;

namespace TaskZero.Server.Application
{
    public class AccountService
    {
        public CommandResponse TryAuthenticate(LoginInputModel input)
        {
            if (string.IsNullOrWhiteSpace(input.Username) ||
               string.IsNullOrWhiteSpace(input.Password))
                return new CommandResponse().AddMessage(Strings_UI.Account_IncompleteCredentials);

            return ValidateCredentials(input.Username, input.Password);
        }


        private static CommandResponse ValidateCredentials(string name, string password)
        {
            return name == password
                ? new CommandResponse(true).AddKey(name)
                : new CommandResponse().AddMessage(Strings_UI.Account_InvalidCredentials);
        }
    }
}