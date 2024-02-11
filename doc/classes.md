@startuml
class Program {
    Chart : Chart
    Main(String[]:args)
}
class Chart {
    -pdfPath : String
    +Key : ChartKey <<g/-s>>
    +PageCount : Int <<g/-s>>
    +Pattern : ChartPattern <<g/-s>>
    +PdfPages : List<Mat> <<g/s>>
    +Chart()
    +ImportPdf(path: String)
}
class ChartPattern {
    -unkeyedGrid : List<List<Mat>>
    -keyedGrid : List<List<KeySymbol>>
    +Size : Tuple<int, int> >= (0, 0) <<g/-s>>
    +ChartPattern(symbolImages: List<List<Mat>>, key:ChartKey)
    +KeyGrid(key:ChartKey)
    +GetKeySymbolAt(x: int, y: int) : KeySymbol
}
class ChartKey {
    -<o> Symbols : List<KeySymbol>
    +ChartKey(source:Mat)
    +MatchSymbol(image:Mat) : *KeySymbol
}
class KeySymbol {
    -<o> Image : Mat
    -<o> Color : String
    -<o> Strands : Integer = 2
    -<i/o> Count : Integer[0..1]
    -<o> Brand : String = "DMC"
    +KeySymbol(image:Mat)
}

Chart "1" -l-* Program : < Creates
ChartKey "1..*" -u-* Chart
ChartPattern "1" -u-* Chart
KeySymbol "1..*" -l-o ChartPattern
KeySymbol "1..*" -r-* ChartKey

class Util {
    +validPdfFile(pdfAddress:String) : Boolean
}

Program -l-> Util : Uses
@enduml
