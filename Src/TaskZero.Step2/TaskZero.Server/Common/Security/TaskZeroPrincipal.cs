///////////////////////////////////////////////////////////////////
//
// NEXT-GEN demos
// Copyright (c) Youbiquitous srls 2018
//
// Author: Dino Esposito (http://youbiquitous.net)
//

using System.Security.Principal;

namespace TaskZero.Server.Common.Security
{
    public class TaskZeroPrincipal : IPrincipal
    {
        //private readonly User _theUser;
        //private readonly UserRepository _userRepository = new UserRepository();

        public TaskZeroPrincipal(IPrincipal user)
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