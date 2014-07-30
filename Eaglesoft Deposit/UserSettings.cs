/*
 * Copyright 2007-2012 Halo3 Consulting, LLC
 * 
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *     
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
*/

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Configuration;

namespace Eaglesoft_Deposit
{
    public class UserSettings : ApplicationSettingsBase
    {
        private static UserSettings _instance;
        public static UserSettings getInstance()
        {
            if (_instance == null)
            {
                _instance = new UserSettings();
                if (_instance.NeedUpgrade)
                {
                    _instance.Upgrade();
                    _instance.NeedUpgrade = false;
                    _instance.Save();
                }
            }
            return _instance;
        }


        [UserScopedSetting]  // varies by user
        [DefaultSettingValue("true")]
        public bool NeedUpgrade
        {
            get
            {
                return (bool)this["NeedUpgrade"];
            }
            set
            {
                this["NeedUpgrade"] = value;
            }
        }

        [UserScopedSetting]
        public Configuration Configuration
        {
            get
            {
                if ((Configuration)this["Configuration"] == null)
                    this["Configuration"] = new Configuration();

                return (Configuration)this["Configuration"];
            }
            set
            {
                this["Configuration"] = value;
            }
        }
    }
}
