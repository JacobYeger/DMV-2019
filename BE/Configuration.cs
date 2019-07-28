using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public static class Configuration
    {
        public static int CurrentTestNumber = 0;
        public static int MAX_LESSONS_PER_WEEK = 20;
        public static int MIN_NUMBER_OF_LESSONS = 45;
        public static int MAX_AGE_INSTRUCTOR = 60;
        public static int MIN_AGE_TRAINEE = 16;
        public static int TIME_BETWEEN_TESTS = 60;//unclear how to work with this (sixty days i guess??)
        public static string PASSED = "Trainee passed the examination";
        public static string FAILED = "Trainee failed the examination";
    }
}
