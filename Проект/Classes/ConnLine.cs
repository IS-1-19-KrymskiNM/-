namespace Проект.Classes
{
    internal class ConnLine
    {
        #region строка подключения
        //Определяем параметры подключения
        private const string host = "chuc.caseum.ru";
        private const string port = "33333";
        private const string database = "is_1_19_st9_KURS";
        private const string username = "st_1_19_9";
        private const string password = "21323158";
        //Формируем строку подключения
        public static string connString = $"server={host};port={port};user={username};database={database};password={password};";
        #endregion
    }
}
