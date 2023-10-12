using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MauiApp2.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        string textCm;

        [ObservableProperty]
        string textKg;

        [ObservableProperty]
        decimal bmi;

        [ObservableProperty]
        string textResult;

        [RelayCommand]
        async Task Click(string text)
        {
            await Shell.Current.GoToAsync($"{nameof(HistoryPage)}?Text={text}");
        }

        [RelayCommand]
        void Calc()
        {
            //
            if (string.IsNullOrWhiteSpace(TextCm) || string.IsNullOrWhiteSpace(TextKg))
            {
                TextResult = "Niepoprawne dane";
                Bmi = 0m;
                return;
            }

            decimal m, kg;
            if (decimal.TryParse(TextCm, out m) &&
                decimal.TryParse(TextKg, out kg))
            {
                if (m <= 0)
                {
                    TextResult = "Niepoprawne dane";
                    Bmi = 0m;
                    return;
                }
                m /= 100m;
                Bmi = kg / (m * m);


                TextResult = BmiText(Bmi);
                
            }
            else Bmi = 0m;
        }

        static string BmiText(decimal bmi)
        {
            if (bmi < 0m) return "Niepoprawne dane";
            else if (bmi < 16m) return "Wygłodzenie";
            else if (bmi < 17m) return "Wychudzenie";
            else if (bmi < 18.5m) return "Niedowaga";
            else if (bmi < 25m) return "Waga prawidłowa";
            else if (bmi < 30m) return "Nadwaga";
            else if (bmi < 35m) return "I st. otyłości";
            else if (bmi < 40m) return "II st. otyłości";
            else if (bmi > 40m) return "Nadwaga skrajna";
            else return "Niepoprawne dane";
        }
    }
}
