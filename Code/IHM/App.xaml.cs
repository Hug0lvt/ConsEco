﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Model;
using LinqToPgSQL;

namespace IHM
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public Manager AllInscrits { get; private set; } = new Manager(new LinqToPgSQL.PersLinqToPgSQL());
        //public Manager AllInscrits { get; private set; } = new Manager(new Stub());

    }
}
