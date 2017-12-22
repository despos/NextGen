// /////////////////////////////////////////////////////////////////
// 
// MfxDemo1
// Copyright (c) Youbiquitous srls 2017
// 
// Author: Dino Esposito (http://youbiquitous.net)
//  

using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(MfxDemo1.Startup))]
namespace MfxDemo1
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}