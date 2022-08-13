using BankApp.AdminPanel.DataContext;
using BankApp.AdminPanel.ViewModel.Email;
using BankApp.AdminPanel.Views.Email;
using BankApp.Commands;
using BankApp.Core.Domain.Entities;
using BankApp.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace BankApp.AdminPanel.Commands.ChangePasswordCommand
{
    public class ConfirmPasswordCommand : BaseCommand
    {
        private readonly ConfirmPasswordViewModel confirmPasswordViewModel;

        public ConfirmPasswordCommand(ConfirmPasswordViewModel confirmPasswordViewModel)
        {
            this.confirmPasswordViewModel = confirmPasswordViewModel;
        }

        public override void Execute(object parameter)
        {
            PasswordBox passwordBox = parameter as PasswordBox;

            if (passwordBox == null)
                return;


            string password = passwordBox.Password;
            string passwordHash = SecurityUtil.ComputeSha256Hash(password);

            ConfirmPasswordWindow confirmPasswordWindow = new ConfirmPasswordWindow();

            ForgotPasswordWindow forgotPasswordWindow = new ForgotPasswordWindow();
            ForgotPasswordViewModel forgotPasswordViewModel = new ForgotPasswordViewModel(Kernel.DB, forgotPasswordWindow);

            var currentUser = confirmPasswordViewModel.DB.LoginRepository.Get(forgotPasswordViewModel.Username);

            User login = new User()
            {
                Id = currentUser.Id,
                Username = forgotPasswordViewModel.Username,
                PasswordHash = passwordHash
            };

            confirmPasswordViewModel.DB.LoginRepository.Update(login);
            MessageBox.Show("Password succesfully changed");
            confirmPasswordWindow.Close();
        }
    }
}
