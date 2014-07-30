using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Eaglesoft_Deposit.Model;
using System.Collections.Generic;
using Eaglesoft_Deposit;

namespace EaglesoftTest
{
    [TestClass]
    public class DepositTest
    {
        Eaglesoft es;

        [TestInitialize]
        public void setupEaglesoft()
        {
            es = new Eaglesoft("UID=dba;PWD=sql;host=10.37.129.3");
            es.Connect();
            Configuration c = new Configuration();
            c.EaglesoftPaytypes.Add(new EaglesoftPaymentType() { Id = 9, Description = "Electronic Payment" });
            c.EaglesoftPaytypes.Add(new EaglesoftPaymentType() { Id = 2, Description = "Check" });
            c.EaglesoftPaytypes.Add(new EaglesoftPaymentType() { Id = 3, Description = "Insurance Check" });
            es.Configuration = c;

        }

        [TestMethod]
        public void TestLoadEOD()
        {
            DailyTransactionRange range = es.getTransactionRangeFor(new DateTime(2013, 9, 18));
            Assert.AreEqual(range.FromTxn, 290082);
            Assert.AreEqual(range.ToTxn, 290293);
        }

        [TestMethod]
        public void TestGetCounts()
        {
            DailyTransactionRange range = es.getTransactionRangeFor(new DateTime(2013, 9, 18));
            Int32 paymentCount = es.getPaymentCount(range);
            Assert.AreEqual(34, paymentCount);

            List<Int32> txnIds = es.getPaymentTransactionIds(range);
            Assert.AreEqual(34, txnIds.Count);
        }

        [TestMethod]
        public void getGetBulkPayment()
        {
            EaglesoftPayment payment = es.getPayment(290082);
            Assert.IsInstanceOfType(payment, typeof(EaglesoftBulkPayment));
            EaglesoftBulkPayment esb = payment as EaglesoftBulkPayment;
            Assert.AreEqual(743.40, payment.Amount);
            Assert.AreEqual("bulk payment from Delta Dental Of Illinois (4413/11041,14586,12644,13957)", payment.Description);
            Assert.AreEqual("222960", payment.CheckNumber);
            Assert.AreEqual(4413, esb.BulkPaymentId);
            Assert.AreEqual(new EaglesoftBulkPayment() { BulkPaymentId = 4413 }, esb);
        }

        [TestMethod]
        public void testCheckNumberExtraction()
        {
            Assert.AreEqual("1239-1234", es.extractCheckNumber("1239-1234 from claim xyz"));
            Assert.AreEqual("12391234", es.extractCheckNumber("12391234 from claim xyz"));
            Assert.IsNull(es.extractCheckNumber("from claim xyz"));
        }

        [TestMethod]
        public void testGetPayment()
        {
            EaglesoftPayment payment = es.getPayment(290097);
            Assert.IsInstanceOfType(payment, typeof(EaglesoftPayment));
            Assert.AreEqual(225.00, payment.Amount);
            Assert.AreEqual("payment from Holly Ellis (14829) for Alek Goss (16981)", payment.Description);
            Assert.AreEqual("1280", payment.CheckNumber);
        }

        [TestMethod]
        public void testGetPaymentTypes()
        {
            List<EaglesoftPaymentType> payTypes = es.getPaytypes();
            List<EaglesoftAdjustmentType> adjType = es.getAdjustmentTypes();

            Assert.AreEqual(12, payTypes.Count);
            Assert.AreEqual(37,adjType.Count);
        }
    }
}
