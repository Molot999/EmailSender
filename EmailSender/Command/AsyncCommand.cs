using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using EmailSender.Command;
using System.Windows.Input;
using System.Collections.Specialized;

namespace EmailSender.Command
{
    public class AsyncCommand : ICommand
    {
        private readonly Func<object, Task> execute;
        private readonly Predicate<object> canExecute;

        public event EventHandler CanExecuteChanged;
        public void UpdateCanExecute() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        public bool IsWorking { get; private set; }

        public AsyncCommand(Func<object, Task> execute) : this(execute, (obj) => true) { }
        public AsyncCommand(Func<object, Task> execute, Predicate<object> canExecute)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter) => !IsWorking && (canExecute?.Invoke(parameter) ?? true);
        public async void Execute(object parameter)
        {
            IsWorking = true;
            UpdateCanExecute();

            await execute(parameter);

            IsWorking = false;
            UpdateCanExecute();
        }
    }
}
