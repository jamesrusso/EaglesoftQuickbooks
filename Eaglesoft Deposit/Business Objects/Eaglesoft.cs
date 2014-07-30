using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using iAnywhere.Data.SQLAnywhere;
using System.Text.RegularExpressions;
namespace Eaglesoft_Deposit.Model
{
    public class Eaglesoft
    {

        private class EaglesoftPaymentDBResult
        {
            public Int32 TransactionNumber { get; set; }
            public Int32? BulkPaymentId { get; set; }
            public String Name { get; set; }
            public String Description { get; set; }
            public String PatientId { get; set; }
            public String PatientName { get; set; }
            public String ResponsiblePartyId { get; set; }
            public String ResponsiblePartyName { get; set; }
            public String InsuranceCompany { get; set; }
            public Int32 PayTypeId { get; set; }
            public Double paymentAmount { get; set; }
        }

        private class EaglesoftRefundDBResult
        {
            public Int32 TransactionNumber { get; set; }
            public String PatientId { get; set; }
            public String ResponsiblePartyId { get; set; }
            public String FirstName { get; set; }
            public String LastName { get; set; }
            public String Address1 { get; set; }
            public String Address2 { get; set; }
            public String City { get; set; }
            public String State { get; set; }
            public String Zip { get; set; }


            public String InsuranceCompanyName{ get; set; }
            public String InsuranceCompanyAddress1 { get; set; }
            public String InsuranceCompanyAddress2 { get; set; }
            public String InsuranceCompanyCity { get; set; }
            public String InsuranceCompanyState { get; set; }
            public String InsuranceCompanyZip { get; set; }

            
            public Double Amount { get; set; }
            public String Description { get; set; }
            public Int32 EaglesoftAdjustmentId { get; set; }
            public String userId { get; set; }
        }

        private IDbConnection _databaseConnection;
        public Configuration Configuration { get; set; }
        public Eaglesoft(String connectionString)
        {
            _databaseConnection = new SAConnection(connectionString);
            Configuration = UserSettings.getInstance().Configuration;
        }

        public Eaglesoft()
            : this(UserSettings.getInstance().Configuration.EaglesoftConnectionString)
        {

        }

        public void Connect()
        {
            _databaseConnection.Open();
        }

        public void Disconnect()
        {
            _databaseConnection.Close();
        }

        public List<EaglesoftAdjustmentType> getAdjustmentTypes()
        {
            return _databaseConnection.Query<EaglesoftAdjustmentType>("select adjustment_type_id as id, description from adjustment_type").ToList<EaglesoftAdjustmentType>();
        }

        public List<EaglesoftPaymentType> getPaytypes()
        {
            return _databaseConnection.Query<EaglesoftPaymentType>("select paytype_id as id, description, prompt from paytype").ToList<EaglesoftPaymentType>();
        }


        public String extractCheckNumber(String description)
        {
            Match match = Regex.Match(description, @"^(\d+(-\d+)*)");
            if (match.Success)
            {
                return description.Substring(match.Index, match.Length);
            }

            return null;
        }

        public EaglesoftPayment getBulkPayment(Int32 BulkPaymentId)
        {
            var result = _databaseConnection.Query<EaglesoftPaymentDBResult>(@"
                        SELECT  
                                BP.BULK_PAYMENT_NUM AS BulkPaymentId,
                                IC.NAME AS InsuranceCompany, 
                                BP.DESCRIPTION AS Description, 
                                BP.PAYTYPE_ID AS PayTypeId, 
                                BP.AMOUNT AS PaymentAmount
                        FROM 
                                BULK_PAYMENTS BP
                                JOIN INSURANCE_COMPANY IC ON IC.INSURANCE_COMPANY_ID = BP.INSURANCE_COMPANY
         
                        WHERE
                                BULK_PAYMENT_NUM = :BulkPaymentNumber", new { BulkPaymentNumber = BulkPaymentId }).First<EaglesoftPaymentDBResult>();


            var Patients = getPatientIdsForBulkPayment(BulkPaymentId);
           
            return new EaglesoftBulkPayment()
            {
                Amount = result.paymentAmount,
                BulkPaymentId = result.BulkPaymentId.Value,
                CheckNumber = result.Description,
                Description = String.Format("bulk payment from {1} ({0}/{2})", result.BulkPaymentId, result.InsuranceCompany, string.Join(",", Patients)),
                EaglesoftPayType = Configuration.EaglesoftPaytypes.First(a => a.Id == result.PayTypeId)
            };
        }

        public DailyTransactionRange getTransactionRangeFor(DateTime date)
        {
            var result = _databaseConnection.Query<DailyTransactionRange>(@"SELECT MIN(start_tran_num) as FromTxn, MAX(END_TRAN_NUM) as ToTxn from eod where date(time_ran)  = :selectedDate",
                new { selectedDate = date });

            return result.First<DailyTransactionRange>();
        }

        public Int32 getPaymentCount(DailyTransactionRange range)
        {
            var result = _databaseConnection.Query<Int32>(@"SELECT count(*) FROM TRANSACTIONS T WHERE T.TYPE NOT IN ('S','C','D') and amount <> 0 and t.status <> 'D' and TRAN_NUM >= :startTran and TRAN_NUM <= :EndTran",
                new { StartTran = range.FromTxn, EndTran = range.ToTxn });

            return result.First<Int32>();
        }

        public List<Int32> getPaymentTransactionIds(DailyTransactionRange range)
        {
            var result = _databaseConnection.Query<Int32>(@"
                    SELECT T.TRAN_NUM FROM TRANSACTIONS T WHERE T.TYPE NOT IN ('S','C','D') and amount <> 0 and t.status <> 'D' and tran_num >= :StartTran and tran_num <= :EndTran
            ", new { StartTran = range.FromTxn, EndTran = range.ToTxn });

            return result.ToList<Int32>();
        }


        #region Refund Support

        public Int32 getRefundCount(DailyTransactionRange range)
        {
            var result = _databaseConnection.Query<Int32>(@"
                    SELECT count(*) FROM TRANSACTIONS T WHERE T.TYPE = 'D' and T.adjustment_type is not null and T.impacts = 'C' and amount <> 0 and t.status <> 'D' and TRAN_NUM >= :startTran and TRAN_NUM <= :EndTran
                ", new { StartTran = range.FromTxn, EndTran = range.ToTxn });

            return result.First<Int32>();
        }

        public List<Int32> getRefundTransactionIds(DailyTransactionRange range)
        {
            var result = _databaseConnection.Query<Int32>(@"
                    SELECT T.TRAN_NUM FROM TRANSACTIONS T WHERE T.TYPE = 'D' and T.adjustment_type is not null and T.impacts = 'C' and amount <> 0 and t.status <> 'D' and TRAN_NUM >= :startTran and TRAN_NUM <= :EndTran
            ", new { StartTran = range.FromTxn, EndTran = range.ToTxn });

            return result.ToList<Int32>();
        }


        public EaglesoftRefund getRefund(Int32 txnId)
        {
            var result = _databaseConnection.Query<EaglesoftRefundDBResult>(@"
                     SELECT
                                    T.TRAN_NUM AS transactionnumber,
                                    rp.patient_id as responsiblepartyid,
                                    t.adjustment_type as eaglesoftAdjustmentId,
                                    t.description as description,
                                    p.patient_id as patientId,
                                    rp.first_name as firstName,
                                    rp.last_name as lastName,
                                    rp.address_1 as address1,
                                    rp.address_2 as address2,
                                    rp.City as city,
                                    rp.State as state,
                                    rp.Zipcode as zip,

                                    ic.name as InsuranceCompanyName,
                                    ic.address_1 as InsuranceCompanyAddress1,
                                    ic.address_2 as InsuranceCompanyAddress2,
                                    ic.city as InsuranceCompanyCity,
                                    ic.state as InsuranceCompanyState,
                                    ic.zipcode as InsuranceCompanyZip,

                                    t.amount as amount,
                                    t.user_id as userId
                        FROM
                                    TRANSACTIONS T
                                    JOIN PATIENT P ON P.PATIENT_ID = T.PATIENT_ID
                                    JOIN PATIENT RP ON RP.PATIENT_ID = T.RESP_PARTY_ID
                                    LEFT OUTER JOIN EMPLOYER E ON P.PRIM_EMPLOYER_ID = E.EMPLOYER_ID
                                    LEFT OUTER JOIN INSURANCE_COMPANY IC ON E.INSURANCE_COMPANY_ID = IC.INSURANCE_COMPANY_ID
                        WHERE
                                    T.TRAN_NUM = :Id", new { Id = txnId }).First<EaglesoftRefundDBResult>();

            return new EaglesoftRefund()
            {
                FirstName = result.FirstName,
                LastName = result.LastName,
                Address1 = result.Address1,
                Address2 = result.Address2,
                City = result.City,
                State = result.State,
                Zip = result.Zip,
                InsuranceCompany_Name = result.InsuranceCompanyName,
                InsuranceCompany_Address1 = result.InsuranceCompanyAddress1,
                InsuranceCompany_Address2 = result.InsuranceCompanyAddress2,
                InsuranceCompany_City = result.InsuranceCompanyCity,
                InsuranceCompany_State = result.InsuranceCompanyState,
                InsuranceCompany_Zip = result.InsuranceCompanyZip,
                Amount = result.Amount,
                AdjustmentType = Configuration.EaglesoftAdjustments.First(a => a.Id == result.EaglesoftAdjustmentId),
                Description = String.Format("{0} ({1}/{2}/{3})", result.Description, result.userId, result.ResponsiblePartyId, result.TransactionNumber),
                PatientId = result.PatientId
            };
        }
        #endregion


        public List<Int32> getPatientIdsForBulkPayment(Int32 bulkPaymentId)
        {
            var result = _databaseConnection.Query<Int32>(@"
                        SELECT
                                    T.PATIENT_ID
                        FROM
                                    TRANSACTIONS T
                        WHERE
                                    BULK_PAYMENT_NUM = :Id", new { Id = bulkPaymentId });

            return result.ToList<Int32>();
        }


        public EaglesoftPayment getPayment(Int32 txnId)
        {
            var result = _databaseConnection.Query<EaglesoftPaymentDBResult>(@"
                        SELECT
                                    T.TRAN_NUM AS TransactionNumber,
                                    RP.PATIENT_ID as ResponsiblePartyId,
                                    RP.FIRST_NAME+' '+RP.LAST_NAME as ResponsiblePartyName,
                                    P.PATIENT_ID as PatientId,
                                    P.FIRST_NAME+' '+P.LAST_NAME as PatientName,
                                    T.DESCRIPTION AS Description, 
                                    T.PAYTYPE_ID AS PayTypeId,
                                    -T.AMOUNT AS PaymentAmount,
                                    T.BULK_PAYMENT_NUM as BulkPaymentId,
                                    IC.NAME as InsuranceCompany
                        FROM
                                    TRANSACTIONS T
                                    JOIN PATIENT P ON P.PATIENT_ID = T.PATIENT_ID
                                    JOIN PATIENT RP ON RP.PATIENT_ID = T.RESP_PARTY_ID
                                    LEFT OUTER JOIN INSURANCE_CLAIM C on T.CLAIM_ID = C.CLAIM_ID
                                    LEFT OUTER JOIN INSURANCE_COMPANY IC on C.PRIM_INSURANCE_COMPANY_ID = IC.INSURANCE_COMPANY_ID
                        WHERE
                                    T.TRAN_NUM = :Id", new { Id = txnId }).First<EaglesoftPaymentDBResult>();

            if (result.BulkPaymentId != null)
                return getBulkPayment(result.BulkPaymentId.Value);
            else
            {
                String Description = result.InsuranceCompany == null ?
                        String.Format("payment from {0} ({1}) for {2} ({3})", result.ResponsiblePartyName, result.ResponsiblePartyId, result.PatientName, result.PatientId)
                        :
                        String.Format("payment from {0} for {1} ({2})", result.InsuranceCompany, result.PatientName, result.PatientId);
                return new EaglesoftPayment()
            {
                Amount = result.paymentAmount,
                Description = Description,
                CheckNumber = result.Description,
                EaglesoftPayType = Configuration.EaglesoftPaytypes.First(a => a.Id == result.PayTypeId)
            };
            }
        }
    }
}