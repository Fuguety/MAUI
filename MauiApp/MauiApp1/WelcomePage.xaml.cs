using Microsoft.Maui.Controls;
using System;
using System.Linq;
using MauiApp1.Models;

namespace MauiApp1
{
    public partial class WelcomePage : ContentPage
    {
        private List<User> users;

        public WelcomePage()
        {
            InitializeComponent();

            // Carregar a lista de usuários do JsonControl
            users = JsonControl.LoadUsers();

            UpdateUserList();
        }

        private void OnAddUserClicked(object sender, EventArgs e)
        {
            // Passe a lista de usuários para a página de adicionar usuário
            Navigation.PushAsync(new AddUserPage(users));
        }

        private async void OnDeleteUserClicked(object sender, EventArgs e)
        {
            if (users.Any())
            {
                // Exibir um popup para selecionar o usuário a ser excluído
                var selectedUser = await DisplayActionSheet("Select User to Delete", "Cancel", null, users.Select(u => $"{u.Code}: {u.FirstName} {u.LastName}").ToArray());

                // Verificar se o usuário clicou em "Cancel"
                if (selectedUser != "Cancel")
                {
                    // Obter o código do usuário selecionado
                    int codeToDelete = int.Parse(selectedUser.Split(':')[0]);

                    // Encontrar e excluir o usuário com o código correspondente
                    User userToDelete = users.FirstOrDefault(u => u.Code == codeToDelete);

                    if (userToDelete != null)
                    {
                        users.Remove(userToDelete);

                        // Atualizar a interface gráfica e salvar as alterações
                        UpdateUserList();
                        JsonControl.SaveUsers(users);
                    }
                }
            }
        }

        // Adiciona este método para navegar para UserControlPage
        private void OnUserControlClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new UserControlPage());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            // Atualizar a interface gráfica com a lista atualizada de usuários
            UpdateUserList();
        }

        public void UpdateUserList()
        {
            string greeting = "Welcome! Current users:\n";

            foreach (var user in users)
            {
                greeting += $"{user.Code}: {user.FirstName} {user.LastName}\n";
            }

            lblGreeting.Text = greeting;
        }
    }
}







