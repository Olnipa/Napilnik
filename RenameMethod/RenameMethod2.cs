﻿using System.Linq;

namespace CleanCode
{
    internal class RenameMethod2
    {
        public static int FindIndex(int[] array, int element)
        {
            for (int i = 0; i < array.Length; i++)
                if (array[i] == element)
                    return i;

            return -1;
        }
    }
}
