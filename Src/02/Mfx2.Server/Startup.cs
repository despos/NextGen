// /////////////////////////////////////////////////////////////////
// 
// MfxDemo1
// Copyright (c) Youbiquitous srls 2017
// 
// Author: Dino Esposito (http://youbiquitous.net)
//  

using MfxDemo2;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Startup))]
namespace MfxDemo2
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}