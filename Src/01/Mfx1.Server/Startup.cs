// /////////////////////////////////////////////////////////////////
// 
// MfxDemo1
// Copyright (c) Youbiquitous srls 2017
// 
// Author: Dino Esposito (http://youbiquitous.net)
//  

using Mfx1.Server;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Startup))]
namespace Mfx1.Server
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}