﻿// The MIT License (MIT)
//
// gitea.net (https://github.com/mkloubert/gitea.net)
// Copyright (c) Marcel Joachim Kloubert <marcel.kloubert@gmx.net>
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to
// deal in the Software without restriction, including without limitation the
// rights to use, copy, modify, merge, publish, distribute, sublicense, and/or
// sell copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER


/*****************************************************************************
 * CREATE A CLASS 'Credentials' in the namespace 'Gitea.API.Sandbox'         *
 *                                                                           *
 * s. below RunAsync()                                                       *
 ****************************************************************************/


using Gitea.API.v1;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Gitea.API.Sandbox
{
    internal class Program
    {
        static Program()
        {
            ServicePointManager.SecurityProtocol = (SecurityProtocolType.Ssl3 |
                                                    SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12);
        }

        private static void Main(string[] args)
        {
            try
            {
                RunAsync().Wait();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.GetBaseException());
            }

            Console.WriteLine();
            Console.WriteLine("===== ENTER =====");
            Console.ReadLine();
        }

        private static async Task RunAsync()
        {
            using (var client = new Client(username: Credentials.User, password: Credentials.Password,
                                           host: Credentials.Host, port: Credentials.Port, isSecure: Credentials.IsSecure))
            {
                var user = await client.Users.GetCurrent();
                if (user != null)
                {
                    var repos = await user.Repositories.GetAll();
                    if (repos != null)
                    {
                    }
                }
            }
        }
    }
}