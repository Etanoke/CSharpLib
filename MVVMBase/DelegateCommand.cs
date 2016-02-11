using System;
using System.Windows.Input;

namespace MVVMBase
{
    class DelegateCommand : ICommand
    {
        public Action<object> ExecuteHandler { get; set; }
        public Func<object, bool> CanExecuteHandler { get; set; }

        public void RaiseCanExecuteChanged()
        {
            var handler = this.CanExecuteChanged;
            if (handler != null)
            {
                handler(this, null);
            }
        }


        #region ICommand メンバー

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            var handler = this.CanExecuteHandler;
            if (handler == null)
            {
                return true;
            } else
            {
                return handler(parameter);
            }
        }

        public void Execute(object parameter)
        {
            var handler = this.ExecuteHandler;
            if (handler != null)
            {
                handler(parameter);
            }
        }

        #endregion

    }
}
