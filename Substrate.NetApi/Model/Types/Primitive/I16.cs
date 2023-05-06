﻿using System;

namespace Substrate.NetApi.Model.Types.Primitive
{
    public class I16 : BasePrim<short>
    {
        public I16()
        { }

        public I16(short value)
        {
            Create(value);
        }

        public override string TypeName() => "i16";

        public override int TypeSize => 2;

        public override byte[] Encode()
        {
            return Bytes;
        }

        public override void CreateFromJson(string str)
        {
            var bytes = Utils.HexToByteArray(str, true);
            Array.Reverse(bytes);
            var result = new byte[TypeSize];
            bytes.CopyTo(result, 0);
            Create(result);
        }

        public override void Create(byte[] byteArray)
        {
            if (byteArray.Length < TypeSize)
            {
                var newByteArray = new byte[TypeSize];
                byteArray.CopyTo(newByteArray, 0);
                byteArray = newByteArray;
            }

            Bytes = byteArray;
            Value = BitConverter.ToInt16(byteArray, 0);
        }

        public override void Create(short value)
        {
            var bytes = new byte[TypeSize];
            BitConverter.GetBytes(value).CopyTo(bytes, 0);
            Bytes = bytes;
            Value = value;
        }

        #region Compare
        public int CompareTo(I16 other)
        {
            return Value.CompareTo(other.Value);
        }
        #endregion

        #region Operators
        public static bool operator >=(I16 self, I16 value)
        {
            return self.Value >= value.Value;
        }

        public static bool operator <=(I16 self, I16 value)
        {
            return self.Value <= value.Value;
        }

        public static bool operator <(I16 self, I16 value)
        {
            return self.Value < value.Value;
        }

        public static bool operator >(I16 self, I16 value)
        {
            return self.Value > value.Value;
        }

        public static I16 operator *(I16 self, I16 value)
        {
            return new I16((short)(self.Value * value.Value));
        }

        public static I16 operator +(I16 self, I16 value)
        {
            return new I16((short)(self.Value + value.Value));
        }

        public static I16 operator -(I16 self, I16 value)
        {
            return new I16((short)(self.Value - value.Value));
        }

        public static I16 operator /(I16 self, I16 value)
        {
            return new I16((short)(self.Value / value.Value));
        }

        public static bool operator ==(I16 self, I16 value)
        {
            return self.Value == value.Value;
        }

        public static bool operator !=(I16 self, I16 value)
        {
            return self.Value != value.Value;
        }
        #endregion
    }
}