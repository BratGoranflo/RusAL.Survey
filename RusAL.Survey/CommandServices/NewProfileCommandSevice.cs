using Q101.ConsoleHelper.Abstract;
using RusAL.Survey.Commands.Abstract;
using RusAL.Survey.Models;
using RusAL.Survey.Services.Abstract;
using RusAL.Survey.Helpers;

namespace RusAL.Survey.CommandServices
{
    /// <summary>
    /// Заполнить новую анкету
    /// </summary>
    public class NewProfileCommandSevice : ICommandService
    {
        /// <summary>
        /// Работа с консолью.
        /// </summary>
        private readonly IQ101ConsoleHelper _consoleHelper;

        /// <summary>
        /// Работа с файлами
        /// </summary>
        private readonly IFileSurveyService _fileService;

        public NewProfileCommandSevice(IQ101ConsoleHelper consoleHelper, IFileSurveyService fileService)
        {
            _consoleHelper = consoleHelper;
            _fileService = fileService;
        }

        public void Start(out bool hasErrors, SurveyItem survey, int startQuestion)
        {
            hasErrors = false;
            var exit = false;
            
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Заполните анкету!");

            var qustions = SurveyHelper.GetQustions();            

            Console.ForegroundColor = ConsoleColor.Yellow;

            for (int i = startQuestion; i < qustions.Length; i++)
            {
                if (exit) break;              

                switch (i) {
                    case 0:
                        // ФИО                         
                        exit = SurveyHelper.InputFio(i, qustions[i], survey);                        
                        if (exit) continue;                                               
                        break;

                    case 1:
                        // Дата рождения
                        exit = SurveyHelper.InputDate(i, qustions[i], survey);
                        if (exit) continue;
                        break;

                    case 2:
                        // ЯП
                        exit = SurveyHelper.InputLang(i, qustions[i], survey);
                        if (exit) continue;
                        break;
                        
                    case 3:
                        // Опыт
                        exit = SurveyHelper.InputExp(i, qustions[i], survey);
                        if (exit) continue;
                        break;

                     case 4:
                        // Телефон
                        exit = SurveyHelper.InputPhone(i, qustions[i], survey);
                        if (exit) continue;                        
                        break;
                }

            }
           

        }

    }
}
