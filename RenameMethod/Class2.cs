﻿namespace CleanCode
{
    internal class Class2
    {
        public static void CreateNewObject()
        {
            //Создание объекта на карте
        }

        public static void GenerateChance()
        {
            _chance = Random.Range(0, 100);
        }

        public static int GetSalary(int hoursWorked)
        {
            return _hourlyRate * hoursWorked;
        }
    }
}
