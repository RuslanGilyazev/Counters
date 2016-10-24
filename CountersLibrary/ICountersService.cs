using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CountersLibrary {

    [ServiceContract]
    public interface ICountersService {
        [OperationContract]
        string GetData(int value);

        [OperationContract]
        string GetHello();

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);


        [OperationContract]
        CounterOptions GetCounterOptions(int id);

        [OperationContract]
        List<CounterOptions> GetAllCounterOptionses();

        [OperationContract]
        PersonalAccount GetPersonalAccount(int id);

        [OperationContract]
        List<PersonalAccount> GetAllPersonalAccounts();

        [OperationContract]
        void SetCounterValue(int personalAccountId, int counterId, float value);

        [OperationContract]
        List<CounterValue> GetAllCounterValuesByAccounts();

        [OperationContract]
        List<CounterValue> GetAllCounterValuesByAccountId(int personalAccountId);

        [OperationContract]
        List<CounterValue> GetAllCounterValuesByTime(DateTime dateFrom, DateTime dateTo);
    }

    [DataContract]
    public class CompositeType {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
