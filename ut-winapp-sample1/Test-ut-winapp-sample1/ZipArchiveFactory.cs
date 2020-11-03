using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using ut_winapp_sample1;

namespace Test_ut_winapp_sample1
{
    public class ZipArchiveFactory
    {
        public Mock<IMessageOut> MockIMessageOut = new Mock<IMessageOut>();

        public ZipArchive CreateInstance()
        {
            var target = new ZipArchive(MockIMessageOut.Object);
            return target;

        }
    }
}
