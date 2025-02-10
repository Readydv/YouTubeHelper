using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouTubeHelper
{
    class Sender
    {
        private Command _command;

        public void SetCommand(Command command)
        {
            _command = command;
        }

        public void Run(string videoUrl)
        {
            _command.Run(videoUrl);
        }

        public void Cancel()
        {
            _command.Cancel();
        }
    }
}
