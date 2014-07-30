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
using System.Reflection;
using System.ComponentModel;
using System.Data;
using System.Xml.Serialization;
using System.Xml;
using System.IO;
using System.Xml.XPath;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using Eaglesoft_Deposit.Model;

namespace Eaglesoft_Deposit
{
    [Serializable]
    public class Configuration
    {
        public List<DateTime> DatesRun { get; set; }
        public Boolean InitialConfigurationComplete { get; set; }
        public DateTime LastTimeRun { get; set; }
        public List<PaytypeMapping> PayTypeMappings { get; set; }
        public List<RefundTypeMapping> RefundTypeMappings { get; set; }
        public List<DepositConfiguration> Deposits { get; set; }
        public String EaglesoftConnectionString { get; set; }

        public List<EaglesoftPaymentType> EaglesoftPaytypes { get; set; }
        public List<EaglesoftAdjustmentType> EaglesoftAdjustments { get; set; }
        public List<QuickbooksPaytype> QuickbooksPaytypes { get; set; }
        public List<QuickbooksCustomer> QuickbooksCustomers { get; set; }
        public List<QuickbooksAccount> QuickbooksIncomeAccounts { get; set; }
        public List<QuickbooksAccount> QuickbooksBankAccounts { get; set; }

        /** The time the above lists were last refreshed from QB and Eaglesoft */
        public DateTime LastRefreshTime { get; set; }

        public Configuration()
        {
            Deposits = new List<DepositConfiguration>();
            DatesRun = new List<DateTime>();
            PayTypeMappings = new List<PaytypeMapping>();
            RefundTypeMappings = new List<RefundTypeMapping>();
            EaglesoftPaytypes = new List<EaglesoftPaymentType>();
            EaglesoftAdjustments = new List<EaglesoftAdjustmentType>();
            QuickbooksPaytypes = new List<QuickbooksPaytype>();
            QuickbooksBankAccounts = new List<QuickbooksAccount>();
            QuickbooksIncomeAccounts = new List<QuickbooksAccount>();
            InitialConfigurationComplete = false;
        }


        public List<RefundTypeMappingDTO> ToRefundMappingDTOs()
        {
            List<RefundTypeMappingDTO> refundMappingTypeDTOs = new List<RefundTypeMappingDTO>();

            foreach (RefundTypeMapping refundTypeMapping in RefundTypeMappings)
            {
                refundMappingTypeDTOs.Add(new RefundTypeMappingDTO()
                {
                    EaglesoftAdjustment = refundTypeMapping.EaglesoftAdjustment.Description,
                    EaglesoftAdjustmentId = refundTypeMapping.EaglesoftAdjustment.Id,
                    QuickbooksIncomeAccount = refundTypeMapping.IncomeAccount == null ? null : refundTypeMapping.IncomeAccount.Name,
                    QuickbooksCustomer = refundTypeMapping.Customer == null ? null : refundTypeMapping.Customer.Name,
                    QuickbooksPaytype = refundTypeMapping.QuickbooksPaytype == null ? null : refundTypeMapping.QuickbooksPaytype.Name,
                    QuickbooksRefundCheckBankAccount = refundTypeMapping.RefundCheckBankAccount == null ? null : refundTypeMapping.RefundCheckBankAccount.Name,
                    IssueCheck = refundTypeMapping.IssueCheck,
                    RefundCheckRecipient = refundTypeMapping.RefundCheckRecipient,
                    Enabled = refundTypeMapping.Enabled
                });
            }


            return refundMappingTypeDTOs;
        }

        public void FromRefundMappingDTOs(IList<RefundTypeMappingDTO> refundMappingDTOs)
        {
            RefundTypeMappings.Clear();
            foreach (RefundTypeMappingDTO refundTypeMappingDTO in refundMappingDTOs)
            {
                RefundTypeMappings.Add(new RefundTypeMapping()
                {
                    Customer = QuickbooksCustomers.FirstOrDefault(p => p.Name.Equals(refundTypeMappingDTO.QuickbooksCustomer)),
                    EaglesoftAdjustment = EaglesoftAdjustments.Single(p => p.Id.Equals(refundTypeMappingDTO.EaglesoftAdjustmentId)),
                    Enabled = refundTypeMappingDTO.Enabled,
                    IncomeAccount = QuickbooksIncomeAccounts.FirstOrDefault(p => p.Name.Equals(refundTypeMappingDTO.QuickbooksIncomeAccount)),
                    RefundCheckBankAccount = QuickbooksBankAccounts.FirstOrDefault(p => p.Name.Equals(refundTypeMappingDTO.QuickbooksRefundCheckBankAccount)),
                    IssueCheck = refundTypeMappingDTO.IssueCheck,
                    QuickbooksPaytype = QuickbooksPaytypes.FirstOrDefault(p => p.Name.Equals(refundTypeMappingDTO.QuickbooksPaytype)),
                    RefundCheckRecipient = refundTypeMappingDTO.RefundCheckRecipient
                });
            }
        }



        public List<PaytypeMappingDTO> ToPaytypeMappingDTOs()
        {
            List<PaytypeMappingDTO> paytypeMappingDTOs = new List<PaytypeMappingDTO>();
            foreach (PaytypeMapping payTypeMapping in PayTypeMappings)
            {
                paytypeMappingDTOs.Add(new PaytypeMappingDTO()
                {
                    EaglesoftPaytype = payTypeMapping.EaglesoftPaytype.Description,
                    EaglesoftPaytypeId = payTypeMapping.EaglesoftPaytype == null ? -1 : payTypeMapping.EaglesoftPaytype.Id,
                    QuickbooksAccount = payTypeMapping.IncomeAccount == null ? null : payTypeMapping.IncomeAccount.Name,
                    QuickbooksCustomer = payTypeMapping.Customer == null ? null : payTypeMapping.Customer.Name,
                    QuickbooksPaytype = payTypeMapping.QuickbooksPayType == null ? null : payTypeMapping.QuickbooksPayType.Name
                });
            }
            return paytypeMappingDTOs;
        }

        public void FromPaytypeMappingDTOs(List<PaytypeMappingDTO> paytypeMappingDTOs)
        {
            PayTypeMappings.Clear();
            foreach (PaytypeMappingDTO paytypeMappingDTO in paytypeMappingDTOs)
            {
                PayTypeMappings.Add(new PaytypeMapping()
                {
                    Customer = QuickbooksCustomers.FirstOrDefault(p => p.Name.Equals(paytypeMappingDTO.QuickbooksCustomer)),
                    IncomeAccount = QuickbooksIncomeAccounts.FirstOrDefault(p => p.Name.Equals(paytypeMappingDTO.QuickbooksAccount)),
                    QuickbooksPayType = QuickbooksPaytypes.FirstOrDefault(p => p.Name.Equals(paytypeMappingDTO.QuickbooksPaytype)),
                    EaglesoftPaytype = EaglesoftPaytypes.FirstOrDefault(p => p.Id.Equals(paytypeMappingDTO.EaglesoftPaytypeId))
                });
            }

        }

        public DepositConfiguration getDepositConfig(QuickbooksPaytype qbPayType)
        {
            foreach (DepositConfiguration config in Deposits)
            {
                foreach (DepositConfigPayType payType in config.QuickBooksPaymentTypes)
                {
                    if (payType.QuickbooksPaytype.Equals(qbPayType))
                        return config;
                }
            }

            return null;
        }


        public void normalizeConfiguration()
        {
            Boolean found = false;

            foreach (EaglesoftAdjustmentType eaglesoftAdjustment in EaglesoftAdjustments)
            {
                found = false;
                foreach (RefundTypeMapping r in RefundTypeMappings)
                {
                    if (eaglesoftAdjustment.Equals(r.EaglesoftAdjustment))
                    {
                        found = true;
                        break;
                    }
                }

                if (found == false)
                {
                    RefundTypeMapping refundMapping = new RefundTypeMapping();
                    refundMapping.EaglesoftAdjustment = eaglesoftAdjustment;
                    RefundTypeMappings.Add(refundMapping);
                }
            }


            foreach (EaglesoftPaymentType eaglesoftPaytype in EaglesoftPaytypes)
            {
                found = false;
                foreach (PaytypeMapping p in PayTypeMappings)
                {
                    if (eaglesoftPaytype.Equals(p.EaglesoftPaytype))
                    {
                        found = true;
                        break;
                    }
                }

                if (found == false)
                {
                    PaytypeMapping t = new PaytypeMapping();
                    t.EaglesoftPaytype = eaglesoftPaytype;
                    PayTypeMappings.Add(t);
                }
            }
        }

        /**
         * Return all PayTypes which belong to no deposit configurations. This is something which is on the quickbooks
         * side of the PayType, but that Paytype is contained in no deposit.
         * 
         */
        public List<QuickbooksPaytype> getUnconfiguredQuickbookPayTypes()
        {
            List<QuickbooksPaytype> unConfiguredPayTypes = new List<QuickbooksPaytype>();

            foreach (PaytypeMapping payType in PayTypeMappings)
            {
                Boolean found = false;
                foreach (DepositConfiguration depositConfig in Deposits)
                {
                    foreach (DepositConfigPayType depositPayType in depositConfig.QuickBooksPaymentTypes)
                    {
                        if (payType.QuickbooksPayType.Equals(depositPayType.QuickbooksPaytype))
                        {
                            found = true;
                            break;
                        }
                    }

                    if (found == true)
                        break;
                }

                if (found == false && unConfiguredPayTypes.Contains(payType.QuickbooksPayType) == false)
                    unConfiguredPayTypes.Add(payType.QuickbooksPayType);
            }

            return unConfiguredPayTypes;
        }


        internal RefundTypeMapping getRefundTypeByEaglesoftAdjustmentType(EaglesoftAdjustmentType eaglesoftAdjustment)
        {
            foreach (RefundTypeMapping r in RefundTypeMappings)
            {
                if (r.EaglesoftAdjustment.Equals(eaglesoftAdjustment))
                    return r;
            }

            return null;
        }

        internal PaytypeMapping getPayTypeByEaglesoftPayType(EaglesoftPaymentType eaglesoftPaytype)
        {
            foreach (PaytypeMapping p in PayTypeMappings)
            {
                if (p.EaglesoftPaytype.Equals(eaglesoftPaytype))
                    return p;
            }

            return null;
        }
    }
}
