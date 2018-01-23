using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;

namespace HelloXFPrism.ViewModels
{
    public class ViewModelBase : BindableBase, INavigationAware, IDestructible
    {

        

        protected INavigationService NavigationService { get; private set; }

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private bool _canNavigateProp;

        public bool CanNavigateProp
        {
            get { return _canNavigateProp; }
            set
            {
                SetProperty(ref _canNavigateProp, value);
                // cách 1: tạ sử kiện thay đổi cho NavigationCommand
                NavigateCommand.RaiseCanExecuteChanged();
            }
        }


        public DelegateCommand NavigateCommand { get; set; }

        //public ViewModelBase ()
        //{
        //    NavigateCommand = new DelegateCommand(Navigate, CanNavigate);
        //}

        private void Navigate()
        {
            var p = new NavigationParameters();
            p.Add("id", "Hello from ViewModelBase!");

            NavigationService.NavigateAsync("A", p);
        }

        // cách 1-2: 
        private bool CanNavigate()
        {
            return CanNavigateProp;
        }

        public ViewModelBase(INavigationService navigationService)
        {
            NavigationService = navigationService;

            NavigateCommand = new DelegateCommand(Navigate, CanNavigate);

            // cách 2: dùng OnservesProperty để tạo thay đổi cho NavigateCommand trong DelegateCommand

            //NavigateCommand = new DelegateCommand(Navigate, CanNavigate).ObservesProperty(() => CanNavigateProp);

            // Cách 3: khai báo NavigateCommand 1 đối tượng
            //NavigateCommand = new DelegateCommand(Navigate).ObservesCanExecute(() => CanNavigateProp);
        }

        public virtual void OnNavigatedFrom(NavigationParameters parameters)
        {
            
        }

        public virtual void OnNavigatedTo(NavigationParameters parameters)
        {
            
        }

        public virtual void OnNavigatingTo(NavigationParameters parameters)
        {
            
        }

        public virtual void Destroy()
        {
            
        }
    }
}
