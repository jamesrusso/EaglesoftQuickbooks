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
using System.IO;
using System.Xml.Serialization;
using System.Threading;
using System.Collections.Generic;
using System.Windows.Forms;
using Eaglesoft_Deposit.Forms;
using Eaglesoft_Deposit.Model;


namespace Eaglesoft_Deposit
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
            Application.Run(new frmMain());
            Properties.Settings.Default.Save();
        }

        static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            if (e.Exception is Quickbooks.QuickbooksConnectionException)
            {
                MessageBox.Show("It appears that QuickBooks is not running?", "Quickbooks running", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show(String.Format("An exception has occured. {0}\n\n{1}", e.Exception.Message, e.Exception.StackTrace));
            }
        }
    }
}