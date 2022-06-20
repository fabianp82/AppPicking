using AppPicking.Controls;
//using AppPicking.Views.Dashboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPicking.Helpers
{
    public class AppConstant
    {

        public async static Task AddFlyoutMenusDetails()
        {
            AppShell.Current.FlyoutHeader = new FlyoutHeaderControl();
            
            var studentDashboardInfo = AppShell.Current.Items.Where(f => f.Route == nameof(RecepcionPage)).FirstOrDefault();
            if (studentDashboardInfo != null) AppShell.Current.Items.Remove(studentDashboardInfo);

            //var teacherDashboardInfo = AppShell.Current.Items.Where(f => f.Route == nameof(TeacherDashboardPage)).FirstOrDefault();
            //if (teacherDashboardInfo != null) AppShell.Current.Items.Remove(teacherDashboardInfo);

            //var adminDashboardInfo = AppShell.Current.Items.Where(f => f.Route == nameof(AdminDashboardPage)).FirstOrDefault();
            //if (adminDashboardInfo != null) AppShell.Current.Items.Remove(adminDashboardInfo);


            if (App.UserDetails.RoleID != 1000)
            {
                var flyoutItem = new FlyoutItem()
                {
                    Title = "Dashboard Page",
                    Route = nameof(RecepcionPage),
                    FlyoutDisplayOptions = FlyoutDisplayOptions.AsMultipleItems,
                    Items =
                            {
                                new ShellContent
                                {
                                    Icon = Icons.Dashboard,
                                    Title = "Recepcion",
                                    ContentTemplate = new DataTemplate(typeof(RecepcionPage)),
                                },
                                new ShellContent
                                {
                                    Icon = Icons.AboutUs,
                                    Title = "Egreso",
                                    ContentTemplate = new DataTemplate(typeof(EgresoPage)),
                                },
                            }
                };
                if (!AppShell.Current.Items.Contains(flyoutItem))
                {
                    AppShell.Current.Items.Add(flyoutItem);
                    await Shell.Current.GoToAsync($"//{nameof(RecepcionPage)}");
                }

            }
            /*
            if (App.UserDetails.RoleID == (int)RoleDetails.Teacher)
            {
                var flyoutItem = new FlyoutItem()
                {
                    Title = "Dashboard Page",
                    Route = nameof(TeacherDashboardPage),
                    FlyoutDisplayOptions = FlyoutDisplayOptions.AsMultipleItems,
                    Items =
                    {
                                new ShellContent
                                {
                                    Icon = Icons.Dashboard,
                                    Title = "Teacher Dashboard",
                                    ContentTemplate = new DataTemplate(typeof(TeacherDashboardPage)),
                                },
                                new ShellContent
                                {
                                    Icon = Icons.AboutUs,
                                    Title = "Teacher Profile",
                                    ContentTemplate = new DataTemplate(typeof(TeacherDashboardPage)),
                                },
                   }
                };

                if (!AppShell.Current.Items.Contains(flyoutItem))
                {
                    AppShell.Current.Items.Add(flyoutItem);
                    await Shell.Current.GoToAsync($"//{nameof(TeacherDashboardPage)}");
                }
            }

            if (App.UserDetails.RoleID == (int)RoleDetails.Admin)
            {
                var flyoutItem = new FlyoutItem()
                {
                    Title = "Dashboard Page",
                    Route = nameof(AdminDashboardPage),
                    FlyoutDisplayOptions = FlyoutDisplayOptions.AsMultipleItems,
                    Items =
                    {
                                new ShellContent
                                {
                                    Icon = Icons.Dashboard,
                                    Title = "Admin Dashboard",
                                    ContentTemplate = new DataTemplate(typeof(AdminDashboardPage)),
                                },
                                new ShellContent
                                {
                                    Icon = Icons.AboutUs,
                                    Title = "Admin Profile",
                                    ContentTemplate = new DataTemplate(typeof(AdminDashboardPage)),
                                },
                   }
                };

                if (!AppShell.Current.Items.Contains(flyoutItem))
                {
                    AppShell.Current.Items.Add(flyoutItem);
                    await Shell.Current.GoToAsync($"//{nameof(AdminDashboardPage)}");
                }
            }
            */
        }
    }
}
