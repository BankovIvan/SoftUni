﻿namespace GenericScale
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class EqualityScale<T> where T : IComparable<T>, IEquatable<T>
    {
        private T left;
        private T right;

        public EqualityScale(T left, T right)
        {
            this.left = left;
            this.right = right;
        }   

        public bool AreEqual()
        {
            return left.Equals(right);
        }
    }
}
