using AviaSalesWPF.Pages;
using AviaSalesWPF.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;


namespace AviaSalesWPF.ViewModels
{
    public class UserNavigationVM : BaseTools
    {
        CurrentPageControl currentPageControl;

        public Page CurrentPage
        {
            get => currentPageControl.Page;
        }
        
        public CommandVM OrderPage { get; set; }


        public UserNavigationVM()
        {
            currentPageControl = new CurrentPageControl();
            currentPageControl.PageChanged += CurrentPageControl_PageChanged;

            OrderPage = new CommandVM(() =>
            {
                currentPageControl.SetPage(new OrderPage());
            });
        }

        private void CurrentPageControl_PageChanged(object sender, EventArgs e)
        {
            Signal(nameof(CurrentPage));
        }
    }
}
