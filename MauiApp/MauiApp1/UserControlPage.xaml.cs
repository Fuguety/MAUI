using Microsoft.Maui.Controls;
using System;
using System.Linq;
using MauiApp1.Models;

namespace MauiApp1
{
    public partial class UserControlPage : ContentPage
    {
        public UserControlPage()
        {
            InitializeComponent();
        }

        private void OnSeeUserInfoClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new UserInfo());
        }

        private void OnSeeAllMembersClicked(object sender, EventArgs e)
        {
            var memberUsers = UserDataManager.GetAllUsers().Where(u => u.IsMember).ToList();
            DisplayAlert("All Members", GetMembersListText(memberUsers), "OK");
        }

        private string GetMembersListText(List<User> members)
        {
            string membersListText = "All Members:\n";
            foreach (var member in members)
            {
                membersListText += $"{member.Code}: {member.FirstName} {member.LastName}\n";
            }
            return membersListText;
        }

        private void OnSeeNonMembersClicked(object sender, EventArgs e)
        {
            var nonMemberUsers = UserDataManager.GetAllUsers().Where(u => !u.IsMember).ToList();
            DisplayAlert("Non-Members", GetMembersListText(nonMemberUsers), "OK");
        }

        private void OnBackClicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}


