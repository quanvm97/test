using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelloXFPrism.ViewModels
{
    public class ViewAViewModel : BindableBase, INavigationAware, IDestructible
    {
        protected INavigationService NavigationService { get; private set; }

        private string _title="View A";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public DelegateCommand NavigateCommand { get; set; }
        
        private async void Navigate()
        {
            //throw new NotImplementedException();
            
            //IActionSheetButton opt1 = ActionSheetButton
        }
        
        public ViewAViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;

            NavigateCommand = new DelegateCommand(Navigate);
        }

        public virtual void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public virtual void OnNavigatedTo(NavigationParameters parameters)
        {
            Title = (string)parameters["id"];
        }

        public virtual void OnNavigatingTo(NavigationParameters parameters)
        {

        }

        public virtual void Destroy()
        {

        }
    }

}
