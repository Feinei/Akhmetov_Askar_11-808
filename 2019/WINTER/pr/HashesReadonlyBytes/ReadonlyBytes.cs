using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace hashes
{
    class ReadonlyBytes : IEnumerable
    {
        private byte[] bytes;
        public ReadonlyBytes(params byte[] bytes)
        {
            this.bytes = bytes ?? throw new ArgumentNullException();
        }
        // Длина
        public int Length
        {
            get { return bytes.Length; }
        }
        // Обращение по индексу
        public byte this[int index]
        {
            get
            {
                if (index < 0 || index >= Length) throw new IndexOutOfRangeException();
                return bytes[index];
            }
        }
        // Перевод в строку
        public override string ToString()
        {
            var outString = new StringBuilder();

            outString.Append("[");
            for (var i = 0; i < Length; i++)
            {
                if (i == bytes.Length - 1)
                    outString.Append(bytes[i]);
                else
                    outString.Append(bytes[i] + ", ");
            }
            outString.Append("]");

            return outString.ToString();
        }
        // Сравнение
        public override bool Equals(object obj)
        {
            var byteArray = obj as ReadonlyBytes;
            if (!(obj is ReadonlyBytes) || byteArray.Length != Length)
                return false;

            for (var i = 0; i < Length; i++)
                if (bytes[i] != byteArray[i])
                    return false;
            return true;
        }
        // FNV функция
        int hash = -1;
        public override int GetHashCode()
        {
            unchecked
            {
                if (hash < 0)
                {
                    var prime = 16777619;
                    hash = (int)2166136261;
                    foreach (var elem in bytes)
                        hash = (hash ^ elem) * prime;
                }
                return hash;
            }
        }
      
        public IEnumerator<byte> GetEnumerator()
        {
            for (int i = 0; i < Length; i++)
                yield return bytes[i];
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}