using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ut_winapp_sample1
{
    public class MessageOut : IMessageOut
    {
        public void SuccessMessage(string message)
        {
            MessageBox.Show(message);
        }
    }
}
