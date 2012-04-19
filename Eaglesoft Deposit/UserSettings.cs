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
            [UserScopedSetting]
        public Configuration.RefundConfiguration RefundConfiguration
        {
            get
            {
                if ((Configuration.RefundConfiguration)this["RefundConfiguration"] == null)
                    this["RefundConfiguration"] = new Configuration.RefundConfiguration();

                return (Configuration.RefundConfiguration)this["RefundConfiguration"];
            }
            set
            {
                this["RefundConfiguration"] = value;
            }
        }
    }
    
}
