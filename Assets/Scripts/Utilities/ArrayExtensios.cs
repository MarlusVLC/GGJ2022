using System;
using DG.Tweening;

namespace Utilities
{
    public static class ArrayExtensions
    {
        public static object[] Rotate(this object[] array)
        {
            object first = array[0];
            Array.Copy(array, 1, array, 0, array.Length-1 );
            array[array.Length - 1] = first;
            return array;
        }
    }
}