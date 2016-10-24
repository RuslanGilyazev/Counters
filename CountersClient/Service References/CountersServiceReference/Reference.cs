﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CountersClient.CountersServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="CountersServiceReference.ICountersService")]
    public interface ICountersService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICountersService/GetData", ReplyAction="http://tempuri.org/ICountersService/GetDataResponse")]
        string GetData(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICountersService/GetData", ReplyAction="http://tempuri.org/ICountersService/GetDataResponse")]
        System.Threading.Tasks.Task<string> GetDataAsync(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICountersService/GetHello", ReplyAction="http://tempuri.org/ICountersService/GetHelloResponse")]
        string GetHello();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICountersService/GetHello", ReplyAction="http://tempuri.org/ICountersService/GetHelloResponse")]
        System.Threading.Tasks.Task<string> GetHelloAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICountersService/GetDataUsingDataContract", ReplyAction="http://tempuri.org/ICountersService/GetDataUsingDataContractResponse")]
        CountersLibrary.CompositeType GetDataUsingDataContract(CountersLibrary.CompositeType composite);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICountersService/GetDataUsingDataContract", ReplyAction="http://tempuri.org/ICountersService/GetDataUsingDataContractResponse")]
        System.Threading.Tasks.Task<CountersLibrary.CompositeType> GetDataUsingDataContractAsync(CountersLibrary.CompositeType composite);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICountersService/GetCounterOptions", ReplyAction="http://tempuri.org/ICountersService/GetCounterOptionsResponse")]
        CountersLibrary.CounterOptions GetCounterOptions(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICountersService/GetCounterOptions", ReplyAction="http://tempuri.org/ICountersService/GetCounterOptionsResponse")]
        System.Threading.Tasks.Task<CountersLibrary.CounterOptions> GetCounterOptionsAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICountersService/GetAllCounterOptionses", ReplyAction="http://tempuri.org/ICountersService/GetAllCounterOptionsesResponse")]
        CountersLibrary.CounterOptions[] GetAllCounterOptionses();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICountersService/GetAllCounterOptionses", ReplyAction="http://tempuri.org/ICountersService/GetAllCounterOptionsesResponse")]
        System.Threading.Tasks.Task<CountersLibrary.CounterOptions[]> GetAllCounterOptionsesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICountersService/GetPersonalAccount", ReplyAction="http://tempuri.org/ICountersService/GetPersonalAccountResponse")]
        CountersLibrary.PersonalAccount GetPersonalAccount(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICountersService/GetPersonalAccount", ReplyAction="http://tempuri.org/ICountersService/GetPersonalAccountResponse")]
        System.Threading.Tasks.Task<CountersLibrary.PersonalAccount> GetPersonalAccountAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICountersService/GetAllPersonalAccounts", ReplyAction="http://tempuri.org/ICountersService/GetAllPersonalAccountsResponse")]
        CountersLibrary.PersonalAccount[] GetAllPersonalAccounts();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICountersService/GetAllPersonalAccounts", ReplyAction="http://tempuri.org/ICountersService/GetAllPersonalAccountsResponse")]
        System.Threading.Tasks.Task<CountersLibrary.PersonalAccount[]> GetAllPersonalAccountsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICountersService/SetCounterValue", ReplyAction="http://tempuri.org/ICountersService/SetCounterValueResponse")]
        void SetCounterValue(int personalAccountId, int counterId, float value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICountersService/SetCounterValue", ReplyAction="http://tempuri.org/ICountersService/SetCounterValueResponse")]
        System.Threading.Tasks.Task SetCounterValueAsync(int personalAccountId, int counterId, float value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICountersService/GetAllCounterValuesByAccounts", ReplyAction="http://tempuri.org/ICountersService/GetAllCounterValuesByAccountsResponse")]
        CountersLibrary.CounterValue[] GetAllCounterValuesByAccounts();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICountersService/GetAllCounterValuesByAccounts", ReplyAction="http://tempuri.org/ICountersService/GetAllCounterValuesByAccountsResponse")]
        System.Threading.Tasks.Task<CountersLibrary.CounterValue[]> GetAllCounterValuesByAccountsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICountersService/GetAllCounterValuesByAccountId", ReplyAction="http://tempuri.org/ICountersService/GetAllCounterValuesByAccountIdResponse")]
        CountersLibrary.CounterValue[] GetAllCounterValuesByAccountId(int personalAccountId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICountersService/GetAllCounterValuesByAccountId", ReplyAction="http://tempuri.org/ICountersService/GetAllCounterValuesByAccountIdResponse")]
        System.Threading.Tasks.Task<CountersLibrary.CounterValue[]> GetAllCounterValuesByAccountIdAsync(int personalAccountId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICountersService/GetAllCounterValuesByTime", ReplyAction="http://tempuri.org/ICountersService/GetAllCounterValuesByTimeResponse")]
        CountersLibrary.CounterValue[] GetAllCounterValuesByTime(System.DateTime dateFrom, System.DateTime dateTo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICountersService/GetAllCounterValuesByTime", ReplyAction="http://tempuri.org/ICountersService/GetAllCounterValuesByTimeResponse")]
        System.Threading.Tasks.Task<CountersLibrary.CounterValue[]> GetAllCounterValuesByTimeAsync(System.DateTime dateFrom, System.DateTime dateTo);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ICountersServiceChannel : CountersClient.CountersServiceReference.ICountersService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CountersServiceClient : System.ServiceModel.ClientBase<CountersClient.CountersServiceReference.ICountersService>, CountersClient.CountersServiceReference.ICountersService {
        
        public CountersServiceClient() {
        }
        
        public CountersServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public CountersServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CountersServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CountersServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string GetData(int value) {
            return base.Channel.GetData(value);
        }
        
        public System.Threading.Tasks.Task<string> GetDataAsync(int value) {
            return base.Channel.GetDataAsync(value);
        }
        
        public string GetHello() {
            return base.Channel.GetHello();
        }
        
        public System.Threading.Tasks.Task<string> GetHelloAsync() {
            return base.Channel.GetHelloAsync();
        }
        
        public CountersLibrary.CompositeType GetDataUsingDataContract(CountersLibrary.CompositeType composite) {
            return base.Channel.GetDataUsingDataContract(composite);
        }
        
        public System.Threading.Tasks.Task<CountersLibrary.CompositeType> GetDataUsingDataContractAsync(CountersLibrary.CompositeType composite) {
            return base.Channel.GetDataUsingDataContractAsync(composite);
        }
        
        public CountersLibrary.CounterOptions GetCounterOptions(int id) {
            return base.Channel.GetCounterOptions(id);
        }
        
        public System.Threading.Tasks.Task<CountersLibrary.CounterOptions> GetCounterOptionsAsync(int id) {
            return base.Channel.GetCounterOptionsAsync(id);
        }
        
        public CountersLibrary.CounterOptions[] GetAllCounterOptionses() {
            return base.Channel.GetAllCounterOptionses();
        }
        
        public System.Threading.Tasks.Task<CountersLibrary.CounterOptions[]> GetAllCounterOptionsesAsync() {
            return base.Channel.GetAllCounterOptionsesAsync();
        }
        
        public CountersLibrary.PersonalAccount GetPersonalAccount(int id) {
            return base.Channel.GetPersonalAccount(id);
        }
        
        public System.Threading.Tasks.Task<CountersLibrary.PersonalAccount> GetPersonalAccountAsync(int id) {
            return base.Channel.GetPersonalAccountAsync(id);
        }
        
        public CountersLibrary.PersonalAccount[] GetAllPersonalAccounts() {
            return base.Channel.GetAllPersonalAccounts();
        }
        
        public System.Threading.Tasks.Task<CountersLibrary.PersonalAccount[]> GetAllPersonalAccountsAsync() {
            return base.Channel.GetAllPersonalAccountsAsync();
        }
        
        public void SetCounterValue(int personalAccountId, int counterId, float value) {
            base.Channel.SetCounterValue(personalAccountId, counterId, value);
        }
        
        public System.Threading.Tasks.Task SetCounterValueAsync(int personalAccountId, int counterId, float value) {
            return base.Channel.SetCounterValueAsync(personalAccountId, counterId, value);
        }
        
        public CountersLibrary.CounterValue[] GetAllCounterValuesByAccounts() {
            return base.Channel.GetAllCounterValuesByAccounts();
        }
        
        public System.Threading.Tasks.Task<CountersLibrary.CounterValue[]> GetAllCounterValuesByAccountsAsync() {
            return base.Channel.GetAllCounterValuesByAccountsAsync();
        }
        
        public CountersLibrary.CounterValue[] GetAllCounterValuesByAccountId(int personalAccountId) {
            return base.Channel.GetAllCounterValuesByAccountId(personalAccountId);
        }
        
        public System.Threading.Tasks.Task<CountersLibrary.CounterValue[]> GetAllCounterValuesByAccountIdAsync(int personalAccountId) {
            return base.Channel.GetAllCounterValuesByAccountIdAsync(personalAccountId);
        }
        
        public CountersLibrary.CounterValue[] GetAllCounterValuesByTime(System.DateTime dateFrom, System.DateTime dateTo) {
            return base.Channel.GetAllCounterValuesByTime(dateFrom, dateTo);
        }
        
        public System.Threading.Tasks.Task<CountersLibrary.CounterValue[]> GetAllCounterValuesByTimeAsync(System.DateTime dateFrom, System.DateTime dateTo) {
            return base.Channel.GetAllCounterValuesByTimeAsync(dateFrom, dateTo);
        }
    }
}