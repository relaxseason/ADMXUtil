using System;

namespace ADMXUtil
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                if (args.Length != 3)
                {
                    Console.WriteLine("ADMXファイル、ADMLファイル、出力ファイルの順にフルパスを引数に指定してください");
                    return;
                }
                var util = new ADMXUtil();
                var policyList = util.Policies(args[0], args[1]);
                util.WriteCSV(args[2], policyList);
            }
            catch(Exception ex)
            {
                Console.WriteLine("エラーが発生しました。\nMessage:[{0}]\n\nStackTrace:[{1}]"
                    , ex.Message, ex.StackTrace);
            }

        }
    }
}
