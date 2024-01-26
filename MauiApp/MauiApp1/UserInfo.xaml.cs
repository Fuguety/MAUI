using Microsoft.Maui.Controls;
using System;
using System.Linq;
using MauiApp1.Models;

namespace MauiApp1
{
    public partial class UserInfo : ContentPage
    {
        private User selectedUser;

        public UserInfo()
        {
            InitializeComponent();
        }

        private void OnSelectUserClicked(object sender, EventArgs e)
        {
            if (int.TryParse(entryUserCode.Text, out int userCode))
            {
                selectedUser = UserDataManager.GetAllUsers().FirstOrDefault(u => u.Code == userCode);

                if (selectedUser != null)
                {
                    DisplayUserInfo(selectedUser);
                }
                else
                {
                    lblUserInfo.Text = "User not found.";
                }
            }
            else
            {
                lblUserInfo.Text = "Invalid user code. Please enter a valid numeric code.";
            }
        }

        private void DisplayUserInfo(User user)
        {
            lblUserInfo.Text = $"User Information:\n\n" +
                               $"Code: {user.Code}\n" +
                               $"Name: {user.FirstName} {user.LastName}\n" +
                               $"Birth Date: {user.BirthDate.ToShortDateString()}\n" +
                               $"Is Member: {user.IsMember}\n" +
                               $"Gender: {user.Gender}";
        }

        private async void OnModifyUserDataClicked(object sender, EventArgs e)
        {
            if (selectedUser != null)
            {
                // Navegar para a página de modificação de dados do usuário
                await Navigation.PushAsync(new ModifyUserDataPage(selectedUser));
            }
            else
            {
                lblUserInfo.Text = "Please select a user first.";
            }
        }

        private async void OnDeleteUserClicked(object sender, EventArgs e)
        {
            bool userConfirmed = await DisplayAlert("Delete User", "Are you sure you want to delete this user?", "Yes", "No");

            if (userConfirmed)
            {
                UserDataManager.DeleteUser(selectedUser.Code);
                lblUserInfo.Text = "User Deleted.";
            }
        }

        private void OnBackClicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}




