using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Eaglesoft_Deposit.Model;
using System.Collections.Generic;
using Eaglesoft_Deposit;

namespace EaglesoftTest
{
    [TestClass]
    public class RefundTest
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
            c.EaglesoftAdjustments.Add(new EaglesoftAdjustmentType() { Id = 3, Description = "Patient Refund" });
            es.Configuration = c;

        }

        [TestMethod]
        public void TestLoadEOD()
        {
            DailyTransactionRange range = es.getTransactionRangeFor(new DateTime(2012, 10, 15));
            Assert.AreEqual(247486, range.FromTxn);
            Assert.AreEqual(247733, range.ToTxn);
        }

        [TestMethod]
        public void TestRefunds()
        {
            DailyTransactionRange range = es.getTransactionRangeFor(new DateTime(2012, 10, 15));
            Int32 refundCount = es.getRefundCount(range);
            Assert.AreEqual(1,refundCount);

            List<Int32> txnIds = es.getRefundTransactionIds(range);
            Assert.AreEqual(1, txnIds.Count);

            EaglesoftRefund refund = es.getRefund(txnIds[0]);
            Assert.AreEqual(112.00,refund.Amount);
            Assert.AreEqual("Johnny",refund.FirstName);
            Assert.AreEqual("Grieshaber",refund.LastName);
            Assert.AreEqual("13008 Brown Bark Trail",refund.Address1);
            Assert.IsNull(refund.Address2);
            Assert.AreEqual("Clermont",refund.City);
            Assert.AreEqual("FL",refund.State);
            Assert.AreEqual("34711",refund.Zip);
            Assert.AreEqual("ins check came here (CMN/14124/247649)", refund.Description);
            Assert.AreEqual(new EaglesoftAdjustmentType() { Id = 3 }, refund.AdjustmentType);

        }

    }
}
