///////////////////////////////////////////////////////////////////
//
// Youbiquitous YBQ : app starter 
// Copyright (c) Youbiquitous srls 2017
//
// Author: Dino Esposito (http://youbiquitous.net)
//

namespace Mfx1.Server.Common.Features.Geo
{
    public struct Country
    {
        public string Code3 { get; set; }
        public string Code2 { get; set; }
        public string Name { get; set; }
        public Continent Continent { get; set; }
    }
}