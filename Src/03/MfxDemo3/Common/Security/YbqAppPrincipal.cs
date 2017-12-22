///////////////////////////////////////////////////////////////////
//
// STARTER-KIT : demo app 
// Copyright (c) D.E. 2017
//
// Author: Dino Esposito
//

using System.Security.Principal;

namespace MfxDemo3.Common.Security
{
    public class YbqAppPrincipal : IPrincipal
    {
        //private readonly User _theUser;
        //private readonly UserRepository _userRepository = new UserRepository();

        public YbqAppPrincipal(IPrincipal user)
        {
            // If you have custom data attached to the user name, this is where you fix it


            Identity = new GenericIdentity(user.Identity.Name);
            //_theUser = _userRepository.FindUserByName(Identity.Name);
        }

        #region IPrincipal
        public IIdentity Identity { get; private set; }
        public bool IsInRole(string role)
        {
            if (!Identity.IsAuthenticated)
                return false;
            if (string.IsNullOrWhiteSpace(role))
                return false;

            // Check against actual roles supported by the app
            // ...

            return true;
        }
        #endregion

        //public User LoggedUser
        //{
        //    get { return _theUser; }
        //}
    }
}