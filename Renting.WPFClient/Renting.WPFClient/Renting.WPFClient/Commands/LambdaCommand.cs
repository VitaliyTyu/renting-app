using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Renting.WPFClient.Commands.Base;

namespace Renting.WPFClient.Commands
{
    internal class LambdaCommand : Command
    {
        private readonly Action<object> _Execute;

        private readonly Func<object, bool> _CanExecute;

        public LambdaCommand(Action<object> Execute, Func<object, bool> CanExecute = null)
        {
            _Execute = Execute ?? throw new ArgumentException(nameof(Execute));
            _CanExecute = CanExecute;
        }

        public override bool CanExecute(object parameter)
        {
            var res = _CanExecute?.Invoke(parameter) ?? true;
            return res;
        }

        public override void Execute(object parameter)
        {
            _Execute(parameter);
        }
    }
}
