﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PrismProject.System2
{
    internal class Convert
    {
        public static byte[] ToByteArray(string text)
        {
            return Encoding.ASCII.GetBytes(text);
        }
    }
}
