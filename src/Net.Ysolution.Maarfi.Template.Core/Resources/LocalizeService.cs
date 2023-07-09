using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Net.Ysolution.Maarfi.Template.Core.Resources;

   public class LocalizeService
    {
       private readonly IStringLocalizer _localizer;
        
        public LocalizeService(IStringLocalizerFactory factory)
        {
            var type = typeof(Resource);
            var assemblyName = new AssemblyName(type.GetTypeInfo().Assembly.FullName);
            _localizer = factory.Create("Resource", assemblyName.Name);
        }
       
        public LocalizedString GetLocalizedString(string key)
        {
            return _localizer[key];
        }
    }
