using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StemaxGeoCode.ViewModels
{
    interface iNotifyService
    {
        public Action<string> OnNotifyInfo { get; }
        public Action<string> OnNotifyError { get; }
    }
}
