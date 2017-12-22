///////////////////////////////////////////////////////////////////
//
// Youbiquitous YBQ : app starter 
// Copyright (c) Youbiquitous srls 2017
//
// Author: Dino Esposito (http://youbiquitous.net)
//

namespace MfxDemo3.Models.Account
{
    public class LoginInputModel
    {
        public LoginInputModel()
        {
            RememberMe = true;
        }

        public string Username { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
        public string ReturnUrl { get; set; }
    }
}