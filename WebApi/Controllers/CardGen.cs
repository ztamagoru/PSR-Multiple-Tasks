﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

namespace WebApi.Controllers
{
    public class CardGen
    {
        private static RNGCryptoServiceProvider _global =
            new RNGCryptoServiceProvider();

        [ThreadStatic]
        private static Random _local;

        public static double NextDouble()
        {
            Random inst = _local;
            if (inst == null)
            {
                byte[] buffer = new byte[4];
                _global.GetBytes(buffer);
                _local = inst = new Random(
                    BitConverter.ToInt32(buffer, 0));
            }

            return inst.NextDouble();
        }
    }
}
