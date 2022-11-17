﻿using LinqToPgSQL;
using Model;

namespace IHM
{
    public partial class App : Application
    {
        public Manager Manager { get; set; } = new Manager(new PersLinqToPgSQL());
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();

            if(OperatingSystem.IsWindows())
            {
                MainPage = new UI_Windows.MainPage_Windows();
            }

        }

    }
}