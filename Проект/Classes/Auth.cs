using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Проект.Classes
{
    static class  Auth
    {
        //Статичное поле, которое хранит значение статуса авторизации
        public static bool auth = false;
        //Статичное поле, которое хранит значения ID пользователя
        public static string auth_name = null;
        //Статичное поле, которое хранит значения ФИО пользователя
        public static string auth_number = null;
        public static string auth_email = null;
    }
}
