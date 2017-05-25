//
//  Program.cs
//  Icebox
//
//  Created by Emoin Lam on 24/05/2017.
//  Copyright © 2017 Emoin Lam. All rights reserved.
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Icebox
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new IceboxForm());
            Environment.Exit(0);
        }
    }
}
