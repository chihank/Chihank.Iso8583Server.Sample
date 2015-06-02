using System;
using Chihank.Iso8583Server.Requests;

namespace Chihank.Iso8583Server.Sample
{
    public class MockDealService : IDealService
    {
        public Terminal GetTerminal(String terminalId, String tenantId)
        {
            Console.WriteLine(String.Format("get terminal"));
            Console.WriteLine(String.Format("tenantId: {0}", tenantId));
            Console.WriteLine(String.Format("terminalId: {0}", terminalId));

            Terminal terminal = new Terminal
            {
                TenantId = tenantId,
                TerminalId = terminalId,
                EncryptKey = "1234567890123456"
            };
            return terminal;
        }

        public Tenant GetTenant(String tenantId)
        {
            Console.WriteLine(String.Format("get tenant"));
            Console.WriteLine(String.Format("tenantId: {0}", tenantId));

            Tenant tenant = new Tenant();
            tenant.TenantId = tenantId;
            return tenant;
        }

        public TransportationResponse AmountPayment(IDealRequest request)
        {
            Console.WriteLine(String.Format("amountPayment"));
            Console.WriteLine(String.Format("account name: {0}", request.AccountName));
            Console.WriteLine(String.Format("account token: {0}", request.AccountToken));
            Console.WriteLine(String.Format("account amount: {0}", request.Amount));
            Console.WriteLine(String.Format("account batch no: {0}", request.BatchNo));
            Console.WriteLine(String.Format("password: {0}", request.Password));
            Console.WriteLine(String.Format("serial no: {0}", request.SerialNo));
            Console.WriteLine(String.Format("tenantId: {0}", request.TenantId));
            Console.WriteLine(String.Format("terminalId: {0}", request.TerminalId));

            TransportationResponse rsp = new TransportationResponse();
            rsp.ResponseCode = ResponseCode.Success;
            rsp.ReferenceNo = "000000000001";
            rsp.AccountAmount = 1;
            rsp.RewardAmount = 20;
            rsp.TradeAmount= 30;
            return rsp;
        }

        public TransportationResponse PointPayment(IDealRequest request)
        {
            Console.WriteLine(String.Format("pointPayment"));
            Console.WriteLine(String.Format("account name: {0}", request.AccountName));
            Console.WriteLine(String.Format("account token: {0}", request.AccountToken));
            Console.WriteLine(String.Format("account amount: {0}", request.Amount));
            Console.WriteLine(String.Format("account batch no: {0}", request.BatchNo));
            Console.WriteLine(String.Format("password: {0}", request.Password));
            Console.WriteLine(String.Format("serial no: {0}", request.SerialNo));
            Console.WriteLine(String.Format("tenantId: {0}", request.TenantId));
            Console.WriteLine(String.Format("terminalId: {0}", request.TerminalId));

            TransportationResponse rsp = new TransportationResponse();
            rsp.ResponseCode = ResponseCode.Success;
            rsp.ReferenceNo = "000000000005";
            rsp.AccountAmount = 5;
            return rsp;
        }

        public TransportationResponse AmountQuery(IDealRequest request)
        {
            Console.WriteLine(String.Format("amount query"));
            Console.WriteLine(String.Format("account name: {0}", request.AccountName));
            TransportationResponse rsp = new TransportationResponse();
            rsp.ResponseCode = ResponseCode.Success;
            rsp.ReferenceNo = "000000000002";
            rsp.AccountAmount = 2;
            return rsp;
        }


        public TransportationResponse PointQuery(IDealRequest request)
        {
            Console.WriteLine(String.Format("point query"));
            Console.WriteLine(String.Format("account name: {0}", request.AccountName));
            TransportationResponse rsp = new TransportationResponse();
            rsp.ResponseCode = ResponseCode.Success;
            rsp.ReferenceNo = "000000000007";
            rsp.AccountAmount = 7;
            return rsp;
        }
        public TransportationResponse CancelPayment(IDealRequest request)
        {
            Console.WriteLine(String.Format("cancelPayment"));
            Console.WriteLine(String.Format("account name: {0}", request.AccountName));
            Console.WriteLine(String.Format("account token: {0}", request.AccountToken));
            Console.WriteLine(String.Format("account amount: {0}", request.Amount));
            Console.WriteLine(String.Format("account batch no: {0}", request.BatchNo));
            Console.WriteLine(String.Format("original serial no: {0}", request.OriginalSerialNo));
            Console.WriteLine(String.Format("password: {0}", request.Password));
            Console.WriteLine(String.Format("serial no: {0}", request.SerialNo));
            Console.WriteLine(String.Format("tenantId: {0}", request.TenantId));
            Console.WriteLine(String.Format("terminalId: {0}", request.TerminalId));
            TransportationResponse rsp = new TransportationResponse();
            rsp.ResponseCode = ResponseCode.Success;
            rsp.ReferenceNo = "000000000003";
            rsp.AccountAmount = 3;
            return rsp;
        }

        public TransportationResponse Rollback(IRollbackRequest request)
        {
            Console.WriteLine(String.Format("rollback"));
            Console.WriteLine(String.Format("account batch no: {0}", request.BatchNo));
            Console.WriteLine(String.Format("serial no: {0}", request.SerialNo));
            Console.WriteLine(String.Format("tenantId: {0}", request.TenantId));
            Console.WriteLine(String.Format("terminalId: {0}", request.TerminalId));
            TransportationResponse rsp = new TransportationResponse();
            rsp.ResponseCode = ResponseCode.Success;
            rsp.ReferenceNo = "000000000004";
            rsp.AccountAmount = 4;
            return rsp;
        }
    }
}
