///////////////////////////////////////////////////////////////////
//
// Youbiquitous YBQ : app starter 
// Copyright (c) Youbiquitous srls 2017
//
// Author: Dino Esposito (http://youbiquitous.net)
//

using MfxDemo2.Common.Features.Geo;

namespace MfxDemo2.Models.Sample
{
    public class LargeFormInputModel : ViewModelBase
    {
        public string ContactName { get; set; }
        public Address Address { get; set; }
        public string[] Emails { get; set; }
        public string Password { get; set; }
    }
}