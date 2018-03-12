///////////////////////////////////////////////////////////////////
//
// NEXT-GEN demos
// Copyright (c) Youbiquitous srls 2018
//
// Author: Dino Esposito (http://youbiquitous.net)
//  

using Microsoft.Owin;
using Owin;
using TaskZero.Server;

[assembly: OwinStartup(typeof(Startup))]
namespace TaskZero.Server
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}