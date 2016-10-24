using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using CountersClient.CountersServiceReference;
using CountersLibrary;

namespace CountersClient {
    public partial class CountersForm : Form {
        private const string NoAccount = "Лицивой счет отсуствует в системе";
        private const string NoCounter = "Счетчик отсуствует в системе";
        private const string NoCounterValues = "Отсуствуют значения счетчиков";
        private const string WrongFormat = "Неверный формат";
        private const string Result = "К лицевому счету {0} c счтечиком {1}, успешно добавлены показания - {2}";
        private const string ServerError = "Сервер недоступен. Повторите попытку позже.";
        private const string CounterView = "Cчетчик: {0} Значение: {1} Дата: {2}";
        private const string CounterViewWithAccount = "Счет: {0} Cчетчик: {1} Значение: {2} Дата: {3}";
        private const string Loading = "Загрузка";
        private const string Send = "Отправить";

        private readonly CountersServiceClient _countersServiceClient;

        public CountersForm() {
            InitializeComponent();

            _countersServiceClient = new CountersServiceClient();

            HideAllTextError();

            resultText.Visible = false;
            errorResultText.Visible = false;
            searchResultText.Visible = false;

            AppDomain.CurrentDomain.ProcessExit += OnProcessExit;
        }

        private void OnProcessExit(object sender, EventArgs e) {
            try {
                _countersServiceClient?.Close();
            }
            catch (Exception) {
                // ignored
            }
        }

        #region Buttons Clicks

        private async void saveCounterValueButton_Click(object sender, EventArgs e) {
            HideAllTextError();
            ChangeControlSate(saveCounterValueButton, false);

            var personalAccount = GetPersonalAccountOrNull(personalAccautTextBox, accountErrorText);
            var counterOptions = GetCounterOptionOrNull();
            var value = ParseNumberFromTextBox<float>(counterValueTextBox, countValueErrorText);

            try {
                await personalAccount;

                if (personalAccount?.Result == null) {
                    ShowTextError(accountErrorText, NoAccount);
                }
                else {
                    HideTextError(accountErrorText);
                }
            }
            catch (Exception) {
                // ignored
            }

            try {
                await counterOptions;

                if (counterOptions?.Result == null) {
                    ShowTextError(countErrorText, NoCounter);
                }
                else {
                    HideTextError(countErrorText);
                }
            }
            catch (Exception) {
                // ignored
            }

            try {
                if (personalAccount == null || counterOptions == null) {
                    ChangeControlSate(saveCounterValueButton, true);
                    return;
                }

                if (personalAccount.Result != null && counterOptions.Result != null && value >= 0) {
                    _countersServiceClient.SetCounterValue(personalAccount.Result.AccountID,
                        counterOptions.Result.CounterID, value);

                    HideAllTextError();

                    ShowResult(personalAccount.Result.AccountID, counterOptions.Result.CounterID, value);
                }
            }
            catch (Exception) {
                ShowResultError(ServerError);
            }

            ChangeControlSate(saveCounterValueButton, true);
        }

        private async void searchButton_Click(object sender, EventArgs e) {
            HideAllTextError();
            ChangeControlSate(searchButton, false);

            if (searchNumberRadioButton.Checked) {
                var personalAccount = GetPersonalAccountOrNull(searchAccountTextBox, searchNumberError);

                try {
                    await personalAccount;

                    if (personalAccount?.Result == null) {
                        ShowTextError(searchNumberError, NoAccount);
                    }
                    else {
                        searchListBox.Items.Clear();
                        searchNumberError.Visible = false;
                        Task<CounterValue[]> counterValues = null;

                        try {
                            counterValues =
                                _countersServiceClient.GetAllCounterValuesByAccountIdAsync(
                                    personalAccount.Result.AccountID);
                        }
                        catch (Exception) {
                            ShowResultError(ServerError);
                        }

                        try {
                            if (counterValues != null) {
                                await counterValues;

                                if (counterValues?.Result != null) {

                                    HideResultError();

                                    if (counterValues.Result.Length == 0) {
                                        searchListBox.Items.Add(NoCounterValues);
                                    }
                                    else {
                                        foreach (var counterValue in counterValues.Result) {
                                            searchListBox.Items.Add(string.Format(CounterView, counterValue.CounterID,
                                                counterValue.CounterValue1, counterValue.DateOfEnterValue));
                                        }
                                    }
                                }
                            }
                        }
                        catch (Exception) {
                            // ignored
                            ShowResultError(ServerError);
                        }
                    }
                }
                catch (Exception ex) {
                    // ignored
                }
            }
            else {
                var fromDate = searchFromDateTimePicker.Value.Date;
                var toDate = searchToDateTimePicker.Value.Date;
                searchListBox.Items.Clear();
                searchNumberError.Visible = false;

                Task<CounterValue[]> counterValues = null;

                try {
                    counterValues = _countersServiceClient.GetAllCounterValuesByTimeAsync(fromDate, toDate);
                }
                catch (Exception) {
                    // ignored
                }

                try {
                    if (counterValues != null) {
                        await counterValues;

                        if (counterValues?.Result != null) {

                            HideResultError();

                            if (counterValues.Result.Length == 0) {
                                searchListBox.Items.Add(NoCounterValues);
                            }
                            else {
                                foreach (var counterValue in counterValues.Result) {
                                    searchListBox.Items.Add(string.Format(CounterViewWithAccount, counterValue.AccountID,
                                        counterValue.CounterID,
                                        counterValue.CounterValue1, counterValue.DateOfEnterValue));
                                }
                            }
                        }
                    }
                }
                catch (Exception) {
                    // ignored
                    ShowResultError(ServerError);
                }
            }

            ChangeControlSate(searchButton, true);
        }

        #endregion

        private void ChangeControlSate(Control button, bool enable) {
            if (enable) {
                button.Enabled = true;
                button.Text = Send;
            }
            else {
                button.Enabled = false;
                button.Text = Loading;
            }
        }

        private void ShowResult(int accountId, int counterId, float value) {
            resultText.Visible = true;
            errorResultText.Visible = false;
            resultText.Text = string.Format(Result, accountId, counterId, value);

            counterTextBox.Text = "";
            personalAccautTextBox.Text = "";
            counterValueTextBox.Text = "";
        }

        private void HideResultError() {
            errorResultText.Visible = false;
            resultText.Visible = false;
            searchResultText.Visible = false;
        }

        private void ShowResultError(string errorText) {
            errorResultText.Visible = true;
            resultText.Visible = false;
            searchResultText.Visible = true;
            errorResultText.Text = errorText;
            searchResultText.Text = errorText;
        }

        private Task<PersonalAccount> GetPersonalAccountOrNull(Control textBox, Label errorLabel) {
            var accountNumber = ParseNumberFromTextBox<int>(textBox, errorLabel);
            Task<PersonalAccount> personalAccount = null;

            if (accountNumber >= 0) {
                try {
                    personalAccount = _countersServiceClient.GetPersonalAccountAsync(accountNumber);
                }
                catch (Exception) {
                    ShowResultError(ServerError);
                    return null;
                }
            }
            else {
                return null;
            }

            return personalAccount;
        }

        private Task<CounterOptions> GetCounterOptionOrNull() {
            var counterNumber = ParseNumberFromTextBox<int>(counterTextBox, countErrorText);
            Task<CounterOptions> counterOptions = null;

            if (counterNumber >= 0) {
                try {
                    counterOptions = _countersServiceClient.GetCounterOptionsAsync(counterNumber);
                }
                catch (Exception) {
                    ShowResultError(ServerError);
                    return null;
                }
            }
            else {
                return null;
            }

            return counterOptions;
        }

        private T ParseNumberFromTextBox<T>(Control textBox, Label errorTextLabel) where T : IConvertible {
            try {
                if (typeof(T) == typeof(int)) {
                    var number = int.Parse(textBox.Text);

                    if (number < 0) {
                        throw new FormatException();
                    }

                    return (T) (object) number;
                }
                if (typeof(T) == typeof(float)) {
                    var number = float.Parse(textBox.Text);

                    if (number < 0) {
                        throw new FormatException();
                    }

                    return (T) (object) number;
                }
            }
            catch (FormatException) {
                ShowTextError(errorTextLabel, WrongFormat);
            }

            if (typeof(T) == typeof(float)) {
                return (T) (object) -1f;
            }

            return (T) (object) -1;
        }

        private void ShowTextError(Label textLabel, string errorText) {
            resultText.Visible = false;
            textLabel.Visible = true;
            textLabel.Text = errorText;
        }

        private void HideTextError(Label textLabel) {
            textLabel.Visible = false;
        }

        private void HideAllTextError() {
            countErrorText.Visible = false;
            accountErrorText.Visible = false;
            countValueErrorText.Visible = false;
            searchNumberError.Visible = false;
        }
    }
}
