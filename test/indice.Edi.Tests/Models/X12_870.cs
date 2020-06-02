using System;
using System.Collections.Generic;
using System.Text;
using indice.Edi.Serialization;

namespace indice.Edi.Tests.Models
{
    public class X12_870
    {
        #region ISA and IEA
        [EdiValue("9(2)", Path = "ISA/0", Description = "ISA01 - Authorization Information Qualifier")]
        public int AuthorizationInformationQualifier { get; set; }

        [EdiValue("X(10)", Path = "ISA/1", Description = "ISA02 - Authorization Information")]
        public string AuthorizationInformation { get; set; }

        [EdiValue("9(2)", Path = "ISA/2", Description = "ISA03 - Security Information Qualifier")]
        public string Security_Information_Qualifier { get; set; }

        [EdiValue("X(10)", Path = "ISA/3", Description = "ISA04 - Security Information")]
        public string Security_Information { get; set; }

        [EdiValue("9(2)", Path = "ISA/4", Description = "ISA05 - Interchange ID Qualifier")]
        public string ID_Qualifier { get; set; }

        [EdiValue("X(15)", Path = "ISA/5", Description = "ISA06 - Interchange Sender ID")]
        public string Sender_ID { get; set; }

        [EdiValue("9(2)", Path = "ISA/6", Description = "ISA07 - Interchange ID Qualifier")]
        public string ID_Qualifier2 { get; set; }

        [EdiValue("X(15)", Path = "ISA/7", Description = "ISA08 - Interchange Receiver ID")]
        public string Receiver_ID { get; set; }

        [EdiValue("9(6)", Path = "ISA/8", Format = "yyMMdd", Description = "I09 - Interchange Date")]
        [EdiValue("9(4)", Path = "ISA/9", Format = "HHmm", Description = "I10 - Interchange Time")]
        public DateTime Date { get; set; }

        [EdiValue("X(1)", Path = "ISA/10", Description = "ISA11 - Interchange Control Standards ID")]
        public string Control_Standards_ID { get; set; }

        [EdiValue("9(5)", Path = "ISA/11", Description = "ISA12 - Interchange Control Version Num")]
        public int ControlVersion { get; set; }

        [EdiValue("9(9)", Path = "ISA/12", Description = "ISA13 - Interchange Control Number")]
        public int ControlNumber { get; set; }

        [EdiValue("9(1)", Path = "ISA/13", Description = "ISA14 - Acknowledgement Requested")]
        public bool? AcknowledgementRequested { get; set; }

        [EdiValue("X(1)", Path = "ISA/14", Description = "ISA15 - Usage Indicator")]
        public string Usage_Indicator { get; set; }

        [EdiValue("X(1)", Path = "ISA/15", Description = "ISA16 - Component Element Separator")]
        public char? Component_Element_Separator { get; set; }

        [EdiValue("9(1)", Path = "IEA/0", Description = "IEA01 - Num of Included Functional Grps")]
        public int GroupsCount { get; set; }

        [EdiValue("9(9)", Path = "IEA/1", Description = "IEA02 - Interchange Control Number")]
        public int TrailerControlNumber { get; set; }

        #endregion

        public List<CreditDecisions> CreditDecisionsList { get; set; }
        #region Credit Decision class
        [EdiSegment, EdiSegmentGroup("ST", SequenceEnd = "SE", Description = "ST - Transaction Set")]
        public class CreditDecisions
        {
            [EdiValue("X(3)", Path = "ST/0", Description = "ST01 - Transaction set ID code")]
            public string TransactionSetCode { get; set; }

            [EdiValue("X(9)", Path = "ST/1", Description = "ST02 - Transaction set control number")]
            public string TransactionSetControlNumber { get; set; }

            public BSR BSRElement { get; set; }
            #region BSR Class
            [EdiSegment, EdiSegmentGroup("BSR", "N1", Description = "BSR")]
            public class BSR
            {
                [EdiValue("X(1)", Path = "BSR/0", Description = "BSR01 - Status Report Code")]
                public string StatusReportCode { get; set; }

                [EdiValue("X(2)", Path = "BSR/1", Description = "BSR02 - Order Code")]
                public string OrderCode { get; set; }

                [EdiValue("X(8)", Path = "BSR/2", Description = "BSR03 - Reference Number")]
                public string ReferenceNumber { get; set; }

                [EdiValue("9(8)", Path = "BSR/3", Format = "yyyyMMdd", Description = "BSR04 - Date (Ship Date)")]
                public string PurchaseOrderDate { get; set; }

                [EdiValue("X(8)", Path = "BSR/7", Description = "BSR08 - Reference Number")]
                public string ReferenceNumber2 { get; set; }




            }

            #endregion
            public List<REF> REFElement { get; set; }
            #region REF Class
            [EdiSegment, EdiPath("REF")]
            public class REF
            {
                [EdiValue("X(2)", Path = "REF/0", Description = "REF - Qualifier (ZZ)")]
                public string Qualifier { get; set; }

                [EdiValue("X(1)", Path = "REF/1", Description = "REF - Decision Code")]
                public string DecisionCode { get; set; }
            }
            #endregion

            public N1 N1Element { get; set; }
            #region N1 Class
            [EdiSegment, EdiPath("N1")]
            public class N1
            {
                [EdiValue("X(2)", Path = "N1/0", Description = "N1 -'BY' ")]
                public string ID { get; set; }

                [EdiValue("X(15)", Path = "N1/1", Description = "N1 -Customer's name ")]
                public string Name { get; set; }

                [EdiValue("9(2)", Path = "N1/2", Description = "N1 - 93")]
                public int Qualifier { get; set; }

                [EdiValue("X(5)", Path = "N1/3", Description = "N1 -Customer's number ")]
                public string IDCode { get; set; }

            }
            #endregion
        }
        #endregion
        [EdiValue("9(1)", Path = "GE/0", Description = "97 Number of Transaction Sets Included")]
        public int TransactionsCount { get; set; }

        [EdiValue("9(9)", Path = "GE/1", Description = "28 Group Control Number")]
        public int GroupTrailerControlNumber { get; set; }

    }
}
