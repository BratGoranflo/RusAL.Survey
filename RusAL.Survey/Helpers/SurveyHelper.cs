using RusAL.Survey.Models;

namespace RusAL.Survey.Helpers
{
    public static class SurveyHelper
    {
        public static bool InputPhone(int i, string question, SurveyItem survey)
        {
            int checkInnerCommand = 0;
            bool exitFlag = false;

            Console.WriteLine(question);
            var phone = Console.ReadLine();
            checkInnerCommand = SurveyHelper.ChechInnerCommands(phone, i);
            if (checkInnerCommand >= 0)
            {
                survey.NextQuestion = checkInnerCommand;
                exitFlag = true;
            }
            survey.Phone = phone;
            return exitFlag;
        }


        public static bool InputExp(int i, string question, SurveyItem survey)
        {
            int checkInnerCommand = 0;
            bool exitFlag = false;

            Console.WriteLine(question);
            var experience = Console.ReadLine();
            checkInnerCommand = SurveyHelper.ChechInnerCommands(experience, i);
            if (checkInnerCommand >= 0)
            {
                survey.NextQuestion = checkInnerCommand;
                exitFlag = true;
            }
            survey.Experience = Convert.ToInt32(experience);
            return exitFlag;
        }

        public static bool InputLang(int i, string question, SurveyItem survey)
        {
            int checkInnerCommand = 0;
            bool exitFlag = false;

            while (true)
            {
                try
                {
                    var lang = new string[] { "PHP", "JavaScript", "C", "C++","Java", "C#", "Python", "Ruby" };
                    Console.WriteLine(question);
                    var langString = Console.ReadLine();
                    if (lang.Contains(langString.Trim()))
                    {
                        survey.Language = langString;
                        break;
                    }
                    checkInnerCommand = SurveyHelper.ChechInnerCommands(langString, i);
                    if (checkInnerCommand >= 0)
                    {
                        survey.NextQuestion = checkInnerCommand;
                        exitFlag = true;
                        break;
                    }
                 }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ошибка ввода языка программирования");
                }
            }

            return exitFlag;
        }


        public static bool InputFio(int i, string question, SurveyItem survey)
        {
            int checkInnerCommand = 0;
            bool exitFlag = false;

            Console.WriteLine(question);
            var strValue = Console.ReadLine();
            checkInnerCommand = ChechInnerCommands(strValue, i);
            if (checkInnerCommand >= 0)
            {
                survey.NextQuestion = checkInnerCommand;
                exitFlag = true;
            }
            survey.FIO = strValue;
            return exitFlag;
        }

        public static bool InputDate(int i, string question, SurveyItem survey)
        {
            int checkInnerCommand = 0;
            bool exitFlag = false;

            while (true)
            {
                try
                {
                    Console.WriteLine(question);
                    var dateString = Console.ReadLine();
                    checkInnerCommand = ChechInnerCommands(dateString, i);
                    if (checkInnerCommand >= 0)
                    {
                        survey.NextQuestion = checkInnerCommand;
                        exitFlag = true;
                        break;
                    }
                    var format = "dd.MM.yyyy";
                    DateTime date = DateTime.ParseExact(dateString, format,
                    System.Globalization.CultureInfo.InvariantCulture);
                    survey.BirthDate = date;                    
                    break;

                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ошибка ввода Даты");
                }
                
            }
            return exitFlag;
        }


        // в случае нахождения команды возвращаем номер вопроса
        public static int ChechInnerCommands(string command, int currQuestion)
        {
            var innerCommand1 = "-goto_question";
            var innerCommand2 = "-goto_prev_question";
            var innerCommand3 = "-restart_profile";
            

            if (string.IsNullOrEmpty(command))
            {
                return -1;
            }

            if (command.Trim().Contains(innerCommand1))
            {
                var nextCommand = command.Replace(innerCommand1, "");
                return Convert.ToInt32(nextCommand.Trim()); 
            }

            if (command.Trim().Contains(innerCommand2))
            {                
                return currQuestion -= 1;
            }


            if (command.Trim().Contains(innerCommand3))
            {
                return 0;
            }

            return -1;
        }


        public static string[] GetQustions()
        {
            var qustions = new string[]
            {
                "Введите ФИО",
                "Введите Дату рождения (ДД.ММ.ГГГГ)",
                "Любимый язык программирования (только указанные варианты: PHP, JavaScript, C, C++, Java, C#, Python, Ruby)",
                "Введите опыт программирования на указанном языке (Полных лет)",
                "Введите Мобильный телефон",
            };

            return qustions;

        }
    }
}
