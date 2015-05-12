package com.chihank.sample;

import com.chihank.iso8583server.*;
import com.chihank.iso8583server.Requests.DealRequest;
import com.chihank.iso8583server.Requests.RollbackRequest;

import java.io.IOException;

class App {
    public static void main(String[] args) throws IOException {
        Iso8583Server server = new Iso8583Server(new MockDealService());
        server.setPort(3130);
        server.start();
        System.in.read();
        server.stop();
    }
}
class MockDealService implements DealService {
    public Terminal getTerminal(String terminalId, String tenantId) {
        System.out.println(String.format("get terminal"));
        System.out.println(String.format("tenantId: %s", tenantId));
        System.out.println(String.format("terminalId: %s", terminalId));

        Terminal terminal = new Terminal();
        terminal.setTenantId(tenantId);
        terminal.setTerminalId(terminalId);
        terminal.setEncryptKey("1234567890123456");
        return terminal;
    }

    public Tenant getTenant(String tenantId) {
        System.out.println(String.format("get tenant"));
        System.out.println(String.format("tenantId: %s", tenantId));

        Tenant tenant = new Tenant();
        tenant.setTenantId(tenantId);
        return tenant;
    }

    public TransportationResponse amountPayment(DealRequest request) {
        System.out.println(String.format("amountPayment"));
        System.out.println(String.format("account name: %s", request.getAccountName()));
        System.out.println(String.format("account token: %s", request.getAccountToken()));
        System.out.println(String.format("account amount: %s", request.getAmount()));
        System.out.println(String.format("account batch no: %s", request.getBatchNo()));
        System.out.println(String.format("password: %s", request.getPassword()));
        System.out.println(String.format("serial no: %s", request.getSerialNo()));
        System.out.println(String.format("tenantId: %s", request.getTenantId()));
        System.out.println(String.format("terminalId: %s", request.getTerminalId()));

        TransportationResponse rsp = new TransportationResponse();
        rsp.setResponseCode(ResponseCode.BadAccount);
        rsp.setReferenceNo("000000000001");
        rsp.setAmount(1);
        return rsp;
    }

    public TransportationResponse pointPayment(DealRequest request) {
        System.out.println(String.format("pointPayment"));
        System.out.println(String.format("account name: %s", request.getAccountName()));
        System.out.println(String.format("account token: %s", request.getAccountToken()));
        System.out.println(String.format("account amount: %s", request.getAmount()));
        System.out.println(String.format("account batch no: %s", request.getBatchNo()));
        System.out.println(String.format("password: %s", request.getPassword()));
        System.out.println(String.format("serial no: %s", request.getSerialNo()));
        System.out.println(String.format("tenantId: %s", request.getTenantId()));
        System.out.println(String.format("terminalId: %s", request.getTerminalId()));

        TransportationResponse rsp = new TransportationResponse();
        rsp.setResponseCode(ResponseCode.Success);
        rsp.setReferenceNo("000000000005");
        rsp.setAmount(5);
        return rsp;
    }

    public TransportationResponse amountQuery(DealRequest request) {
        System.out.println(String.format("amount query"));
        System.out.println(String.format("account name: %s", request.getAccountName()));
        TransportationResponse rsp = new TransportationResponse();
        rsp.setResponseCode(ResponseCode.Success);
        rsp.setReferenceNo("000000000002");
        rsp.setAmount(2);
        return rsp;
    }


    public TransportationResponse pointQuery(DealRequest request) {
        System.out.println(String.format("point query"));
        System.out.println(String.format("account name: %s", request.getAccountName()));
        TransportationResponse rsp = new TransportationResponse();
        rsp.setResponseCode(ResponseCode.Success);
        rsp.setReferenceNo("000000000007");
        rsp.setAmount(7);
        return rsp;
    }

    public TransportationResponse cancelPayment(DealRequest request) {
        System.out.println(String.format("cancelPayment"));
        System.out.println(String.format("account name: %s", request.getAccountName()));
        System.out.println(String.format("account token: %s", request.getAccountToken()));
        System.out.println(String.format("account amount: %s", request.getAmount()));
        System.out.println(String.format("account batch no: %s", request.getBatchNo()));
        System.out.println(String.format("original serial no: %s", request.getOriginalSerialNo()));
        System.out.println(String.format("password: %s", request.getPassword()));
        System.out.println(String.format("serial no: %s", request.getSerialNo()));
        System.out.println(String.format("tenantId: %s", request.getTenantId()));
        System.out.println(String.format("terminalId: %s", request.getTerminalId()));
        TransportationResponse rsp = new TransportationResponse();
        rsp.setResponseCode(ResponseCode.Success);
        rsp.setReferenceNo("000000000003");
        rsp.setAmount(3);
        return rsp;
    }

    public TransportationResponse rollback(RollbackRequest request) {
        System.out.println(String.format("rollback"));
        System.out.println(String.format("account batch no: %s", request.getBatchNo()));
        System.out.println(String.format("serial no: %s", request.getSerialNo()));
        System.out.println(String.format("tenantId: %s", request.getTenantId()));
        System.out.println(String.format("terminalId: %s", request.getTerminalId()));
        TransportationResponse rsp = new TransportationResponse();
        rsp.setResponseCode(ResponseCode.Success);
        rsp.setReferenceNo("000000000004");
        rsp.setAmount(4);
        return rsp;
    }
}