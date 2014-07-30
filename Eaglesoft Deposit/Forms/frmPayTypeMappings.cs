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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Eaglesoft_Deposit.Model;
namespace Eaglesoft_Deposit
{
    public partial class frmPayTypeMappings : Form 
    {

        public frmPayTypeMappings(List<PaytypeMappingDTO> paytypeMappingDTOs)
        {
            Configuration configuration = UserSettings.getInstance().Configuration;
            InitializeComponent();

            // The order of these is important. If we setup the paytypeMappingDTOBindingSource first, the others will not correctly select the valuemember.
            comboQbAccount.DataSource = configuration.QuickbooksIncomeAccounts;
            comboQbFrom.DataSource = configuration.QuickbooksCustomers;
            comboQbPayType.DataSource = configuration.QuickbooksPaytypes;
            paytypeMappingDTOBindingSource.DataSource = paytypeMappingDTOs;
        }
    }
}