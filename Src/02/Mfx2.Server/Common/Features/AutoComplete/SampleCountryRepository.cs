///////////////////////////////////////////////////////////////////
//
// Youbiquitous YBQ : app starter 
// Copyright (c) Youbiquitous srls 2017
//
// Author: Dino Esposito (http://youbiquitous.net)
//

using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Expoware.Youbiquitous.Extensions;

namespace MfxDemo2.Common.Features.AutoComplete
{
    public class SampleCountryRepository
    {
        public static IList<CultureInfo> AllBy(string filter)
        {
            var cultures = CultureInfo.GetCultures(CultureTypes.AllCultures);
            return (from c in cultures
                    where c.DisplayName.ContainsAny(filter)
                    select c).ToList();
        }
    }
}