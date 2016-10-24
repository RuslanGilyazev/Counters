using System;
using System.Collections.Generic;
using System.Linq;

namespace CountersLibrary {
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class CountersService : ICountersService {
        public string GetData(int value) {
            return $"You entered: {value}";
        }

        public string GetHello() {
            return "Hello";
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite) {
            if (composite == null) {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue) {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public CounterOptions GetCounterOptions(int id) {
            using (var context = new CountersEntities()) {
                var productEntity = (from p
                    in context.CounterOptions
                    where p.CounterID == id
                    select p).FirstOrDefault();

                return productEntity;
            }
        }

        public List<CounterOptions> GetAllCounterOptionses() {
            using (var context = new CountersEntities()) {
                return context.CounterOptions.ToList();
            }
        }

        public PersonalAccount GetPersonalAccount(int id) {
            using (var context = new CountersEntities()) {
                var personalAccount = (from p
                    in context.PersonalAccount
                    where p.AccountID == id
                    select p).FirstOrDefault();

                return personalAccount;
            }
        }

        public List<PersonalAccount> GetAllPersonalAccounts() {
            using (var context = new CountersEntities()) {
                return context.PersonalAccount.ToList();
            }
        }

        public void SetCounterValue(int personalAccountId, int counterId, float value) {
            using (var context = new CountersEntities()) {
                var counterValue = new CounterValue {
                    CounterValudId = context.CounterValue.Count(),
                    Unit = "Test",
                    CounterID = counterId,
                    CounterValue1 = (int) value,
                    DateOfEnterValue = DateTime.UtcNow,
                    AccountID = personalAccountId
                };
                context.CounterValue.Add(counterValue);
                context.SaveChanges();
            }
        }

        public List<CounterValue> GetAllCounterValuesByAccounts() {
            using (var context = new CountersEntities()) {
                return context.CounterValue.ToList();
            }
        }

        public List<CounterValue> GetAllCounterValuesByAccountId(int personalAccountId) {
            using (var context = new CountersEntities()) {
                var counterValues = (from p
                    in context.CounterValue
                    where p.AccountID == personalAccountId
                    select p).ToList();

                return counterValues;
            }
        }

        public List<CounterValue> GetAllCounterValuesByTime(DateTime dateFrom, DateTime dateTo) {
            using (var context = new CountersEntities()) {

                List<CounterValue> counterValues = new List<CounterValue>();

                foreach (CounterValue counterValue in context.CounterValue.ToList()) {
                    if (counterValue.DateOfEnterValue >= dateFrom &&
                        counterValue.DateOfEnterValue <= dateTo) {
                        counterValues.Add(counterValue);
                    }
                }

                return counterValues;
            }
        }
    }
}
