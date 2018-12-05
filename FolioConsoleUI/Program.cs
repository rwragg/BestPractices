﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FolioLibrary.Data;

[assembly: log4net.Config.XmlConfigurator(Watch=true)]

namespace FolioConsoleUI
{
    class Program
    {
        private static readonly log4net.ILog log = 
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        
        static void Main(string[] args)
        {
            FolioService.FolioServiceClient fs = new FolioService.FolioServiceClient();
            FolioDTO fd = fs.GetFolioStatus(5191156, 78511);
            
            Console.WriteLine(fd.Status);
            Console.ReadLine();
        }
    }
}