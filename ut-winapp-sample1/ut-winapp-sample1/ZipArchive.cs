using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Compression;
using System.IO;

namespace ut_winapp_sample1
{
    public class ZipArchive
    {
        private IMessageOut _messageOut;

        public ZipArchive(IMessageOut messageOut)
        {
            _messageOut = messageOut;
        }

        public void CreateZip(string srcFilePath, string destFilePath)
        {
            using(var zip = ZipFile.Open(destFilePath, ZipArchiveMode.Create))
            {
                zip.CreateEntryFromFile(srcFilePath, Path.GetFileName(srcFilePath));
            }

            _messageOut.SuccessMessage($"zip圧縮成功 {srcFilePath}->{destFilePath}");
        }
    }
}
