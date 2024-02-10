@startuml
class Program {
    Chart : Chart
    Main(String[]:args)
}
class Chart {
    -_pdfPath : String
    +Key : ChartKey <<g/-s>>
    +PageCount : Int <<g/-s>>
    +Pattern : ChartPattern <<g/-s>>
    +PdfPages : List<Mat> <<g/s>>
    +Chart()
    +ImportPdf(path: String)
}
class ChartPattern {
    -SourceImages : List<List<Mat>>
    -<o> Width : Integer > 0
    -<o> Height : Integer > 0
    -<o> Grid : List<List<*KeySymbols>>
    +ChartPattern(sourceImages: List<List<Mat>>, key:ChartKey)
}
class ChartKey {
    -SourceImage : Mat
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
