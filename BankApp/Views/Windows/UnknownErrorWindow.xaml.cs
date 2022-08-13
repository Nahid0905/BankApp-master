﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BankApp.AdminPanel.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для UnknownErrorWindow.xaml
    /// </summary>
    public partial class UnknownErrorWindow : Window
    {
        public UnknownErrorWindow(double width, double height, string errorMessage)
        {
            Width = width;
            Height = height;

            WindowStyle = WindowStyle.None;

            InitializeComponent();

            txtErrorMessage.Text = errorMessage;

            StartClosingAnimation();
        }

        private void StartClosingAnimation()
        {
            var anim = new DoubleAnimation(0, TimeSpan.FromSeconds(3));

            anim.Completed += (s, _) => Close();

            BeginAnimation(OpacityProperty, anim);
        }
    }
}
