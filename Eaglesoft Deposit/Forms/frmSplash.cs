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
using System.Threading;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Eaglesoft_Deposit
{
    public partial class frmSplashScreen : Form
    {
        private static Thread _thread; 
        private static frmSplashScreen _instance = null;
        private bool _loaded = false;

        public frmSplashScreen()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Show the SplashForm
        /// </summary>
        public new static void Show()
        {
            if (_instance != null)
                return;

            _thread = new Thread(new ThreadStart(delegate()
            {
                _instance = new frmSplashScreen();
                _instance.HandleCreated += new EventHandler(delegate(Object o, EventArgs e) { _instance._loaded = true; });
                Application.Run(_instance);
            }));

            _thread.IsBackground = true;
            _thread.SetApartmentState(ApartmentState.STA);
            _thread.Start();
        }

        public static void setText(string p)
        {
            while (_instance == null)
            {
                Console.WriteLine("waiting on _instance");
                Thread.SpinWait(1);
            }

            while (_instance._loaded == false)
            {
                Console.WriteLine("waiting on _loaded");
                Thread.SpinWait(1);
            }


            _instance.Invoke(new MethodInvoker(delegate() { _instance.lblStatus.Text = p; }));
        }

        /// <summary>
        /// Colse the SplashForm
        /// </summary>
        public static void Finished()
        {
            if (_instance == null || _thread == null)
                return;

            try
            {
                _instance.Invoke(new MethodInvoker(_instance.Close));
            }
            catch (Exception)
            {
            }
            _instance = null;
            _thread = null;
        }

        private void lblStatus_Click(object sender, EventArgs e)
        {

        }

    }
}