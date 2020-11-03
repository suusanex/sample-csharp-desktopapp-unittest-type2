using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;

namespace Test_ut_winapp_sample1
{
    [TestFixture]
    public class ZipArchiveTest
    {
        [SetUp]
        public void SetUp()
        {
            //一時フォルダのパスをランダムに決めて、フォルダを作る
            m_TempDir = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
            Directory.CreateDirectory(m_TempDir);
        }

        [TearDown]
        public void TearDown()
        {
            //一時フォルダを丸ごと消す（試験開始時の条件を揃えるため）
            Directory.Delete(m_TempDir, true);
        }

        private string m_TempDir;

        [Test]
        public void ZipTest1()
        {
            //一時フォルダに、zip圧縮元のファイルを作成する
            var srcFile = Path.Combine(m_TempDir, "SrcFile1.bin");
            File.WriteAllBytes(srcFile, new byte[] { 0x2, 0xFF });

            //同じく一時フォルダに、zipファイル出力先のパスを用意する
            var destFile = Path.Combine(m_TempDir, "DestFile.zip");

            //Factoryのインスタンスを作り、テストインスタンスを作成する（ここでモックも設定させる）
            var fac = new ZipArchiveFactory();
            var target = fac.CreateInstance();

            //テスト対象のメソッドを実行
            target.CreateZip(srcFile, destFile);

            //成功メッセージが表示されたことをテスト
            //ここではIMessageOut.SuccessMessageが呼び出されたことをテスト
            fac.MockIMessageOut.Verify(d => d.SuccessMessage(It.IsAny<string>()), Times.Once);

            //zipファイルが作成されていることをテスト
            Assert.That(File.Exists(destFile), Is.True);


        }

    }
}
