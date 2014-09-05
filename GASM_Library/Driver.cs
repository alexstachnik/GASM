
namespace Gasm {

  using System.IO;
  using System.Collections.Generic;

  public class Driver {

    static int Main(string[] args)
    {
      string iF="foo.asm";
      string oF="foo.o";
      AsmFile asm;
      using (StreamReader sr=new StreamReader(iF)) {
        Parser P = new Parser(sr,
                              new TranslationUnit{fileName=iF},
                              new ParserOptions{bePermissive=true});
        asm=P.parse();
      }

      using (BinaryWriter bw=new BinaryWriter(File.Open(oF,FileMode.Create))) {
        BinaryFile.writeBinary(asm,bw);
      }

      using (BinaryReader br=new BinaryReader(File.Open(oF,FileMode.Open))) {
        List<BinaryFile.BinInstr> instrs=BinaryFile.readBinary(br);
        for (int i=0;i<instrs.Count;++i) {
          System.Console.WriteLine(instrs[i].op);
        }
      }
      return 0;
    }

  }

}