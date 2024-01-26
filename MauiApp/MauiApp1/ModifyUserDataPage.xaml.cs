using Microsoft.Maui.Controls;
using System;
using MauiApp1.Models;

namespace MauiApp1
{
    public partial class ModifyUserDataPage : ContentPage
    {
        private User userToModify;

        public ModifyUserDataPage(User selectedUser)
        {
            InitializeComponent();

            userToModify = selectedUser;

            entryFirstName.Text = userToModify.FirstName;
            entryLastName.Text = userToModify.LastName;
            datePickerBirthDate.Date = userToModify.BirthDate;
            switchIsMember.IsToggled = userToModify.IsMember;
            pickerGender.SelectedItem = userToModify.Gender;
        }

        private void OnSaveChangesClicked(object sender, EventArgs e)
        {
            userToModify.FirstName = entryFirstName.Text;
            userToModify.LastName = entryLastName.Text;
            userToModify.BirthDate = datePickerBirthDate.Date;
            userToModify.IsMember = switchIsMember.IsToggled;
            userToModify.Gender = pickerGender.SelectedItem?.ToString();

            UserDataManager.SaveUsers();

            DisplayAlert("Success", "User data modified successfully.", "OK");

            Navigation.PopAsync();
        }

        private void OnCancelClicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}


