///////////////////////////////////////////////////////////////////
//
// Youbiquitous YBQ : app starter 
// Copyright (c) Youbiquitous srls 2017
//
// Author: Dino Esposito (http://youbiquitous.net)
//

using MfxDemo1.Common;
using MfxDemo1.Models.Account;
using MfxDemo1.Resources;

namespace MfxDemo1.Application
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