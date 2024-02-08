using EasySaveProject.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace EasySaveProject
{
    public class ProgressViewModel
    {
        private readonly FormatStateStrategyJson _formatStateStrategyJson;
        private readonly State _state;

        public ProgressViewModel(FormatStateStrategyJson formatStateStrategyJson, FormatStateFactory formatStateFactory, WorkListService workListService)
        {
            _formatStateStrategyJson = formatStateStrategyJson;
            _state = new State(formatStateFactory, workListService);
        }

        public void states()
        {
            _state.update();
        }

    }
} 