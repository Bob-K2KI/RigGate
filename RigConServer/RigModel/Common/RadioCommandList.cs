﻿#region -- Copyright
/*
   Copyright {2014} {Darryl Wagoner DE WA1GON}

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
*/
#endregion

using System.Collections.Generic;
using Wa1gon.Models.Common;

namespace Wa1gon.Models
{
    public class RadioPropComandList
    {
        public RadioPropComandList()
        {
            Properties = new List<RadioProperty>();
        }
        public List<RadioProperty> Properties { get; set; }
        public string Status { get; set; }
        public int Success { get; set; }
        public int Failed { get; set; }
    }
}
