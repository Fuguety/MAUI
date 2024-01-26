using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using MauiApp1.Models;

namespace MauiApp1
{
    public partial class AddUserPage : ContentPage
    {
        private List<User> users;

        public AddUserPage(List<User> users)
        {
            InitializeComponent();
            this.users = users;
        }

        private void OnAddUserClicked(object sender, EventArgs e)
        {
            try
            {
                // Obtenha a entrada do usuário e adicione um novo usuário à lista
                string firstName = entryFirstName.Text;
                string lastName = entryLastName.Text;
                DateTime birthDate = datePickerBirthDate.Date;
                string gender = pickerGender.SelectedItem?.ToString(); // Obtenha o valor selecionado do Picker
                bool isMember = switchIsMember.IsToggled;

                User newUser = new User
                {
                    FirstName = firstName,
                    LastName = lastName,
                    BirthDate = birthDate,
                    Gender = gender,
                    IsMember = isMember
                };

                // Adicionar o novo usuário à lista e salvar a lista no arquivo
                users.Add(newUser);
                JsonControl.SaveUsers(users);

                Navigation.PopAsync();

                (Application.Current.MainPage as WelcomePage)?.UpdateUserList();
            }
            catch (Exception ex)
            {
                // Tratar exceções aqui (por exemplo, exibir uma mensagem de erro)
                Console.WriteLine($"Error adding user: {ex.Message}");
            }
        }

        private void OnHomeClicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}





